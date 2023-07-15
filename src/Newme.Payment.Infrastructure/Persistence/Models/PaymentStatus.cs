using Newme.Payment.Domain.Extensions;
using Newme.Payment.Domain.Entities;

namespace Newme.Payment.Infrastructure.Persistence.Models
{
    public class PaymentStatus
    {
        private PaymentStatus() {}
        public PaymentStatus(EPaymentStatus status)
        {
            Id = Guid.NewGuid();
            Status = status;
            Description = status.GetEnumDescription();
        }

        public Guid Id { get; set; }
        public EPaymentStatus Status { get; private set; }
        public string Description { get; private set; }
    }
}