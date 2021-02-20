using AccountingApp.Entities;
using AccountingApp.TypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingApp.Context
{
    public class AccountingContext:DbContext
    {
        public AccountingContext(DbContextOptions<AccountingContext> options) : base(options)
        {
        }
        public DbSet<Facturi> Facturi { get; set; }
        public DbSet<DetaliiFactura> DetaliiFactura { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("ACCOUNTING");
            modelBuilder.ApplyConfiguration(new FacturiTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DetaliiFacturaTypeConfiguration());
        }


    }
}
