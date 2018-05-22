namespace Pharmacy.DAL.Models
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
