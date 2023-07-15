namespace Newme.Payment.Application.InputModels
{
	public class RegisterDebitCardPaymentInputModel : RegisterCardPaymentInputModel
	{
        public RegisterDebitCardPaymentInputModel(
			Guid payerId,
			Guid purchaseId, 
			double amountToBePaid,
			string number,
			string agency) : base(payerId, purchaseId, amountToBePaid, number, agency)
        {
        }
	}
}