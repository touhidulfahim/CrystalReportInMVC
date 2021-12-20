using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using CrystalReportApp.Core.Entities;

namespace CrystalReportApp.Infrastructure.Gateway
{
    public class CrystalReportAppDbContext:DbContext
    {
        public CrystalReportAppDbContext():base("CrystalReportAppConnection")
        {
            
        }


        public DbSet<PersonModel> PersonEntity { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
