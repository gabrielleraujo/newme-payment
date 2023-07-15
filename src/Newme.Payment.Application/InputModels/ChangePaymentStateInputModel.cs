using Newme.Payment.Domain.Entities;

namespace Newme.Payment.Application.InputModels
{
    public class ChangePaymentStatusInputModel
    {
        public ChangePaymentStatusInputModel(
            Guid id,
            EPaymentType type,
            EPaymentStatus status)
        {
            Id = id;
            Type = Type;
            Status = status;
        }

        public Guid Id { get; set; }
        public EPaymentType Type { get; set;}
        public EPaymentStatus Status { get; set; }
    }
}