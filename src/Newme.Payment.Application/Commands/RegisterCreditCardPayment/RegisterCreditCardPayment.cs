using FluentValidation.Results;
using MediatR;

namespace Newme.Payment.Application.Commands.RegisterCreditCardPayment
{
    public class RegisterCreditCardPaymentCommand : RegisterCardPaymentCommand, IRequest<ValidationResult>
    {
        public RegisterCreditCardPaymentCommand(
            Guid payerId, 
            Guid purchaseId, 
            double amountToBePaid,
            string number,
            string code,
            DateTime expiration,
            int numberInstallments,
			int numberInstallmentsPaid,
			double installmentValue,
			double totalInterest) : base(payerId, purchaseId, amountToBePaid, number, code, expiration)
        {
			NumberInstallments = numberInstallments;
			NumberInstallmentsPaid = numberInstallmentsPaid;
			InstallmentValue = installmentValue;
			TotalInterest = totalInterest;
            Expiration = Expiration;
        }

        public int NumberInstallments { get; private set; }
		public int NumberInstallmentsPaid { get; private set; }
		public double InstallmentValue { get; private set; }
		public double TotalInterest { get; private set; }

        // public override bool IsValid() 
        // {
        //     ValidationResult = new RegisterCreditCardPaymentCommandValidation().Validate(this);
        //     return ValidationResult.IsValid;
        // }
    }
}
