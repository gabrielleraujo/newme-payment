namespace Newme.Payment.Application.Commands
{
	public abstract class PaymentCommand : Command
	{
        protected PaymentCommand(int purchaseId, double amountToBePaid)
        {
            PurchaseId = purchaseId;
            AmountToBePaid = amountToBePaid;
        }

        public int PurchaseId { get; protected set; }
		public double AmountToBePaid { get; protected set; }

        public override string ToString()
        {
            return $"PurchaseId: {PurchaseId}\nAmount To Be Paid: {AmountToBePaid}";
        }
    }
}