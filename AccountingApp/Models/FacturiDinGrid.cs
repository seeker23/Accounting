using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingApp.Models
{
    public class FacturiDinGrid
    {
        public int IdFactura { get; set; }
        public int IdLocatie { get; set; }
        public string NumarFactura { get; set; }
        public DateTime DataFactura { get; set; }
        public string NumeClient { get; set; }
        public string NumeProdus { get; set; }
        public decimal Cantitate { get; set; }
        public decimal PretUnitar { get; set; }
        public decimal Valoare { get; set; }
    }
}
