﻿namespace Newme.Payment.Application.InputModels
{
	public class RegisterCreditCardPaymentInputModel : RegisterCardPaymentInputModel
	{
        public RegisterCreditCardPaymentInputModel(
			Guid payerId,
			Guid purchaseId, 
			double amountToBePaid,
			string number,
			string agency,
			int numberInstallments,
			int numberInstallmentsPaid,
			double installmentValue,
			double totalInterest) : base(payerId, purchaseId, amountToBePaid, number, agency)
        {
			NumberInstallments = numberInstallments;
			NumberInstallmentsPaid = numberInstallmentsPaid;
			InstallmentValue = installmentValue;
			TotalInterest = totalInterest;
        }

        public int NumberInstallments { get; set; }
		public int NumberInstallmentsPaid { get; set; }
		public double InstallmentValue { get; set; }
		public double TotalInterest { get; set; }
	}
}