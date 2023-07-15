using System.ComponentModel.DataAnnotations;

namespace Newme.Payment.Domain.Entities
{
    public abstract class Entity
    {
        protected Entity(Guid id)
        {
            Id = id;
            CreateDate = DateTime.Now;
            UpdateDate = null;
        }

        public Guid Id { get; private set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}