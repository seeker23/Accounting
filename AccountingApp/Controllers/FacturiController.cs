using AccountingApp.Context;
using AccountingApp.Models;
using AccountingApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingApp.Services;

namespace AccountingApp.Controllers
{
    public class FacturiController : Controller
    {
        private readonly FacturiService _facturiService;

        public FacturiController(FacturiService facturiService)
        {
            _facturiService = facturiService;
        }
        public IActionResult Index()
        {
            return View(_facturiService.ReturnDataToGrid());
        }
        public IActionResult AddOrEdit(int idFactura = 0,int idLocatie=0)
        {
            if (idFactura == 0)
                return View(new DetaliiFacturaReadOrCreate());
            else
            {
                return View(_facturiService.ReturnDataToEdit(idFactura, idLocatie));
            }               
        }

        [HttpPost]
        public IActionResult AddorEdit([Bind("IdFactura,IdLocatie,NumarFactura,NumeClient,NumeProdus,Cantitate,PretUnitar")] DetaliiFacturaReadOrCreate detaliiFactura)
        {
            if (ModelState.IsValid)
            {
                if (detaliiFactura.IdFactura == 0)
                {
                    _facturiService.Insert(detaliiFactura);
                }
                else
                {
                    _facturiService.Update(detaliiFactura);
                }

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Delete(int idFactura, int idLocatie)
        {
            _facturiService.Delete(idFactura,idLocatie);
            return RedirectToAction(nameof(Index));
        }

    }
}
