namespace Newme.Payment.Application.InputModels
{
	public abstract class RegisterCardPaymentInputModel : RegisterPaymentInputModel
	{
        public RegisterCardPaymentInputModel(
			Guid payerId,
			Guid purchaseId, 
			double amountToBePaid,
			string number,
			string code,
			DateTime expiration) : base(payerId, purchaseId, amountToBePaid)
        {
			Number = number;
			Code = code;
			Expiration = expiration;
        }

        public string Number { get; set; }
		public string Code { get; set; }
		public DateTime Expiration { get; set; }
	}
}