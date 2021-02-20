using AccountingApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingApp.TypeConfigurations
{
    public class DetaliiFacturaTypeConfiguration : IEntityTypeConfiguration<DetaliiFactura>
    {
        public void Configure(EntityTypeBuilder<DetaliiFactura> builder)
        {
            builder.ToTable("DETALII_FACTURA");
            builder.HasKey(x => new { x.IdDetaliiFactura, x.IdLocatie });
        }
    }
}
