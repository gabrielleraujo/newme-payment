namespace Newme.Payment.Domain.Entities
{
    public abstract class PaymentBase : Entity
    {
        protected PaymentBase(Guid id,
            Guid payerId,
            Guid purchaseId,
            double amountToBePaid) : base(id)
        {
            PayerId = payerId;
            PurchaseId = purchaseId;
            AmountToBePaid = amountToBePaid;
            Status = EPaymentStatus.PaymentValidation;
        }

        public Guid PayerId { get; private set; }
        public Guid PurchaseId { get; private set; }
        public double AmountToBePaid { get; private set; }
        public EPaymentStatus Status { get; internal set; }

        public abstract double CalculateDiscount();
    }
}