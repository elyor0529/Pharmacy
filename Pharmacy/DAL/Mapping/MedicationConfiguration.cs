using System.Data.Entity.ModelConfiguration;
using Pharmacy.DAL.Models;

namespace Pharmacy.DAL.Mapping
{
    public class MedicationConfiguration : EntityTypeConfiguration<Medication>
    {
        public MedicationConfiguration()
        {
            ToTable("medications", "public");
        }
    }
}