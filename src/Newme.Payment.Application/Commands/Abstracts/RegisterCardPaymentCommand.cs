namespace Newme.Payment.Application.Commands
{
	public abstract class RegisterCardPaymentCommand : RegisterPaymentCommand
	{
        protected RegisterCardPaymentCommand(
			Guid payerId,
			Guid purchaseId, 
			double amountToBePaid,
			string number,
			string agency) : base(payerId, purchaseId, amountToBePaid)
        {
			Number = number;
			Agency = agency;
        }

        public string Number { get; protected set; }
		public string Agency { get; protected set; }
	}
}