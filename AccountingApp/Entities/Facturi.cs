using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingApp.Entities
{
    public class Facturi: BaseEntity
    {
        public int IdFactura { get; set; }
        public int IdLocatie { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string NumarFactura { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataFactura { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string NumeClient { get; set; }
    }
}
