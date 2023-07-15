namespace Newme.Payment.Application.InputModels
{
    public abstract class RegisterPaymentInputModel
    {
        public RegisterPaymentInputModel(Guid payerId, Guid purchaseId, double amountToBePaid)
        {
            PayerId = payerId;
            PurchaseId = purchaseId;
            AmountToBePaid = amountToBePaid;
        }

        public Guid PayerId { get; set; }
        public Guid PurchaseId { get; set; }
		public double AmountToBePaid { get; set; }
    }
}
