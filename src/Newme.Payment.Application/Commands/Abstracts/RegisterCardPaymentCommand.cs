namespace Newme.Payment.Application.Commands
{
	public abstract class RegisterCardPaymentCommand : RegisterPaymentCommand
	{
        protected RegisterCardPaymentCommand(
			Guid payerId,
			Guid purchaseId, 
			double amountToBePaid,
			string number,
			string code,
			DateTime expiration) : base(payerId, purchaseId, amountToBePaid)
        {
			Number = number;
			Code = code;
			expiration = expiration;
        }

        public string Number { get; protected set; }
		public string Code { get; protected set; }
		public DateTime Expiration { get; protected set; }
	}
}