using AccountingApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingApp.TypeConfigurations
{
    public class FacturiTypeConfiguration : IEntityTypeConfiguration<Facturi>
    {
        public void Configure(EntityTypeBuilder<Facturi> builder)
        {
            builder.ToTable("FACTURI");
            builder.HasKey(x => new { x.IdFactura, x.IdLocatie });
        }
    }
}
