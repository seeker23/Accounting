using AccountingApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingApp.Models
{
    public class DetaliiFacturaReadOrCreate
    {
        public int IdDetaliiFactura { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int IdLocatie { get; set; }

        public int IdFactura { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string NumeProdus { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public decimal Cantitate { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public decimal PretUnitar { get; set; }

        public decimal Valoare { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string NumeClient { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string NumarFactura { get; set; }
    }
}
