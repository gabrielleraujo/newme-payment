using FluentValidation.Results;
using Newme.Payment.Application.InputModels;

namespace Newme.Payment.Application.Services
{
    public interface IPaymentService
    {
        Task<ValidationResult> RegisterCreditCardPayment(RegisterCreditCardPaymentInputModel inputModel);
        Task<ValidationResult> RegisterDebitCardPayment(RegisterDebitCardPaymentInputModel inputModel);
        Task<ValidationResult> RegisterPixPayment(RegisterPixPaymentInputModel inputModel);
        Task<ValidationResult> ChangeStatus(ChangePaymentStatusInputModel inputModel);
    }
}
