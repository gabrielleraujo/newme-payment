namespace Newme.Payment.Application.Commands
{
    public abstract class RegisterPaymentCommand : Command
    {
        protected RegisterPaymentCommand(Guid payerId, Guid purchaseId, double amountToBePaid)
        {
            PayerId = payerId;
            PurchaseId = purchaseId;
            AmountToBePaid = amountToBePaid;
        }

        public Guid PayerId { get; protected set; }
        public Guid PurchaseId { get; protected set; }
		public double AmountToBePaid { get; protected set; }

        public override string ToString()
        {
            return $"PayerId {PayerId} - PurchaseId: {PurchaseId} - Amount To Be Paid: {AmountToBePaid}";
        }
    }
}
