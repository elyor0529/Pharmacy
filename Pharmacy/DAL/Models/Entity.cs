using System;
using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.DAL.Models
{
    public abstract class BaseEntity
    {
        public DateTime? CreatedDate { get; set; }

        public DateTime? ModefiedDate { get; set; }

    }

    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual T Id { get; set; }

    }

    public abstract class Entity : Entity<long>
    {
    }

}
