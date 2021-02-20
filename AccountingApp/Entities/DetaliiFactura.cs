using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingApp.Entities
{
    public class DetaliiFactura: BaseEntity
    {
        public int IdDetaliiFactura { get; set; }
        public int IdLocatie { get; set; }
        [Column(TypeName = "int")]
        public int IdFactura { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string NumeProdus { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Cantitate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PretUnitar { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valoare { get; set; }
    }
}
