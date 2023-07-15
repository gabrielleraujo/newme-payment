namespace Newme.Payment.Application.InputModels
{
	public abstract class RegisterCardPaymentInputModel : RegisterPaymentInputModel
	{
        public RegisterCardPaymentInputModel(
			Guid payerId,
			Guid purchaseId, 
			double amountToBePaid,
			string number,
			string agency) : base(payerId, purchaseId, amountToBePaid)
        {
			Number = number;
			Agency = agency;
        }

        public string Number { get; set; }
		public string Agency { get; set; }
	}
}