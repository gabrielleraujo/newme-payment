namespace Newme.Payment.Application.InputModels
{
	public class RegisterPixPaymentInputModel : RegisterPaymentInputModel
	{
        public RegisterPixPaymentInputModel(
			Guid payerId,
			Guid purchaseId, 
			double amountToBePaid,
			string copyPaste,
			DateTime dueDate) : base(payerId, purchaseId, amountToBePaid)
        {
			CopyPaste = copyPaste;
			DueDate = dueDate;
        }

        public string CopyPaste { get; set; }
		public DateTime DueDate { get; set; }
	}
}