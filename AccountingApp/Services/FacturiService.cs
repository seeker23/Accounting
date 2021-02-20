using AccountingApp.Entities;
using AccountingApp.IRepositories;
using AccountingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingApp.Services
{
    public class FacturiService
    {
        private IRepository<Facturi> _facturiRepository;
        private IRepository<DetaliiFactura> _detaliiFacturaRepository;

        public FacturiService(IRepository<Facturi> facturiRepository, IRepository<DetaliiFactura> detaliiFacturaRepository)
        {
            _facturiRepository = facturiRepository;
            _detaliiFacturaRepository = detaliiFacturaRepository;
        }

        public bool Insert(DetaliiFacturaReadOrCreate detaliiFactura)
        {
            try
            {
                var factura = new Facturi()
                {
                    IdLocatie = detaliiFactura.IdLocatie,
                    NumarFactura = detaliiFactura.NumarFactura,
                    DataFactura = DateTime.Now,
                    NumeClient = detaliiFactura.NumeClient
                };
                _facturiRepository.Insert(factura);

                int latestIdFactura = _facturiRepository.Table.Where(x => x.IdLocatie == detaliiFactura.IdLocatie).Max(x => x.IdFactura);

                int latestIdDetaliiFactura = _detaliiFacturaRepository.Table.Where(x => x.IdLocatie == detaliiFactura.IdLocatie).Any() ? _detaliiFacturaRepository.Table.Where(x => x.IdLocatie == detaliiFactura.IdLocatie).Max(x => x.IdDetaliiFactura) + 1 : 1;

                var detFactura = new DetaliiFactura()
                {
                    IdDetaliiFactura = latestIdDetaliiFactura,
                    IdLocatie = detaliiFactura.IdLocatie,
                    IdFactura = latestIdFactura,
                    NumeProdus = detaliiFactura.NumeProdus,
                    PretUnitar = detaliiFactura.PretUnitar,
                    Cantitate = detaliiFactura.Cantitate,
                    Valoare = detaliiFactura.PretUnitar * detaliiFactura.Cantitate
                };

                _detaliiFacturaRepository.Insert(detFactura);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

        }

        public bool Update(DetaliiFacturaReadOrCreate detaliiFactura)
        {
            try
            {
                var factura = new Facturi()
                {
                    IdFactura = detaliiFactura.IdFactura,
                    IdLocatie = detaliiFactura.IdLocatie,
                    NumarFactura = detaliiFactura.NumarFactura,
                    DataFactura = DateTime.Now,
                    NumeClient = detaliiFactura.NumeClient
                };
                _facturiRepository.Update(factura);

                int latestIdDetaliiFactura = _detaliiFacturaRepository.Table.Where(x => x.IdLocatie == detaliiFactura.IdLocatie && x.IdFactura == detaliiFactura.IdFactura).Max(x => x.IdDetaliiFactura);

                var detFactura = new DetaliiFactura()
                {
                    IdDetaliiFactura = latestIdDetaliiFactura,
                    IdFactura = detaliiFactura.IdFactura,
                    IdLocatie = detaliiFactura.IdLocatie,
                    NumeProdus = detaliiFactura.NumeProdus,
                    PretUnitar = detaliiFactura.PretUnitar,
                    Cantitate = detaliiFactura.Cantitate,
                    Valoare = detaliiFactura.PretUnitar * detaliiFactura.Cantitate
                };

                _detaliiFacturaRepository.Update(detFactura);

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;      
            }
        }
        
        public  bool Delete(int idFactura, int idLocatie)
        {
            try
            {
                var detaliiFactura = _detaliiFacturaRepository.Table.Where(x=>x.IdFactura == idFactura && x.IdLocatie == idLocatie).FirstOrDefault();
                _detaliiFacturaRepository.Delete(detaliiFactura);

                var factura = _facturiRepository.Table.Where(x => x.IdFactura == idFactura && x.IdLocatie == idLocatie).FirstOrDefault();
                _facturiRepository.Delete(factura);
 
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public DetaliiFacturaReadOrCreate ReturnDataToEdit(int idFactura ,int idLocatie)
        {
            var facturi = _facturiRepository.Table.Where(x => x.IdFactura == idFactura && x.IdLocatie == idLocatie).FirstOrDefault();
            var detaliifactura = _detaliiFacturaRepository.Table.Where(x => x.IdFactura == idFactura && x.IdLocatie == idLocatie).FirstOrDefault();

            return new DetaliiFacturaReadOrCreate()
            {
                IdDetaliiFactura = detaliifactura.IdDetaliiFactura,
                IdLocatie = detaliifactura.IdLocatie,
                IdFactura = detaliifactura.IdFactura,
                NumeProdus = detaliifactura.NumeProdus,
                PretUnitar = detaliifactura.PretUnitar,
                Cantitate = detaliifactura.Cantitate,
                Valoare = detaliifactura.PretUnitar * detaliifactura.Cantitate,
                NumarFactura = facturi.NumarFactura,
                NumeClient = facturi.NumeClient

            };
        }

        public List<FacturiDinGrid> ReturnDataToGrid()
        {
            var facturi = _facturiRepository.Table;
            var detaliifactura = _detaliiFacturaRepository.Table;

            var grid = from f in facturi
                       join df in detaliifactura on new { f.IdFactura, f.IdLocatie } equals new { df.IdFactura, df.IdLocatie }
                       select new FacturiDinGrid
                       {
                           IdFactura = f.IdFactura,
                           IdLocatie = f.IdLocatie,
                           NumarFactura = f.NumarFactura,
                           DataFactura = f.DataFactura,
                           NumeClient = f.NumeClient,
                           NumeProdus = df.NumeProdus,
                           Cantitate = df.Cantitate,
                           PretUnitar = df.PretUnitar,
                           Valoare = df.Valoare
                       };
            return grid.ToList();
        }

    }
}
