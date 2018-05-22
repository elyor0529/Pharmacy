using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.DAL.EF;
using Pharmacy.DAL.Mapping;
using Pharmacy.DAL.Models;

namespace Pharmacy.DAL
{
    public class PharmacyEntities : DbContext
    {
        static PharmacyEntities()
        {
            Database.SetInitializer(new PharmacyInitializer());
        }

        public PharmacyEntities()
            : base("DefaultConnection")
        {
        }

        public DbSet<Medication> Blogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new MedicationConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
