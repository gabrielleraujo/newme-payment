using FluentValidation.Results;
using MediatR;

namespace Newme.Payment.Application.Commands.RegisterDebitCardPayment
{
    public class RegisterDebitCardPaymentCommand : RegisterCardPaymentCommand, IRequest<ValidationResult>
    {
        public RegisterDebitCardPaymentCommand(
            Guid payerId, 
            Guid purchaseId, 
            double amountToBePaid,
            string number,
            string code,
            DateTime expiration) : base(payerId, purchaseId, amountToBePaid, number, code, expiration)
        {
        }

        // public override bool IsValid() 
        // {
        //     ValidationResult = new RegisterCreditPaymentCommandValidation().Validate(this);
        //     return ValidationResult.IsValid;
        // }
    }
}
