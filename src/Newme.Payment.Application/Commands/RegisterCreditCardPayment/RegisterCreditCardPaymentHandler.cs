using MediatR;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Newme.Payment.Domain.Entities;
using Newme.Payment.Domain.Repositories;

namespace Newme.Payment.Application.Commands.RegisterCreditCardPayment
{
    public class RegisterCreditCardPaymentCommandHandler : 
        CommandHandler<RegisterCreditCardPaymentCommandHandler>,
        IRequestHandler<RegisterCreditCardPaymentCommand, ValidationResult>
    {
        private readonly IBaseRepository<CreditCard> _repository;

        public RegisterCreditCardPaymentCommandHandler(
            ILogger<RegisterCreditCardPaymentCommandHandler> logger,
            IBaseRepository<CreditCard> repository) : base(logger)
        {
            _repository = repository;
        }
        
        public async Task<ValidationResult> Handle(RegisterCreditCardPaymentCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(RegisterCreditCardPaymentCommandHandler)} starting");

            if (!command.IsValid())
            {
                AddError("Command model is invalid");
                return command.ValidationResult;
            }

            var payment = new CreditCard(
                id: Guid.NewGuid(),
                payerId: command.PayerId, 
                purchaseId: command.PurchaseId, 
                amountToBePaid: command.AmountToBePaid,
                number: command.Number,
                agency: command.Agency,
                numberInstallments: command.NumberInstallments,
                numberInstallmentsPaid: command.NumberInstallmentsPaid,
                installmentValue: command.InstallmentValue,
                totalInterest: command.TotalInterest
            );

            await _repository.AddAsync(payment);

            _logger.LogInformation($"{nameof(RegisterCreditCardPaymentCommandHandler)} successfully completed");

            return ValidationResult;
        }
    }
}
