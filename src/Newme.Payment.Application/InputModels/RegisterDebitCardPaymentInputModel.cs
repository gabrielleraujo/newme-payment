namespace Newme.Payment.Application.InputModels
{
	public class RegisterDebitCardPaymentInputModel : RegisterCardPaymentInputModel
	{
        public RegisterDebitCardPaymentInputModel(
			Guid payerId,
			Guid purchaseId, 
			double amountToBePaid,
			string number,
			string code,
			DateTime expiration) : base(payerId, purchaseId, amountToBePaid, number, code, expiration)
        {
        }
	}
}