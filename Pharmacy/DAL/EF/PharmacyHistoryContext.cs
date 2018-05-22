using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;

namespace Pharmacy.DAL.EF
{
    internal class PharmacyHistoryContext : HistoryContext
    {
        public PharmacyHistoryContext(DbConnection existingConnection, string defaultSchema) : base(existingConnection, defaultSchema)
        { 
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("public");

        }
    }
}
