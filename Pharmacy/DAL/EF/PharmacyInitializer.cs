using System.Data.Entity;

namespace Pharmacy.DAL.EF
{
    internal class PharmacyInitializer : DropCreateDatabaseIfModelChanges<PharmacyEntities>
    {
        public PharmacyInitializer()
        {
                
        }

        protected override void Seed(PharmacyEntities context)
        {
        }

    }
}
