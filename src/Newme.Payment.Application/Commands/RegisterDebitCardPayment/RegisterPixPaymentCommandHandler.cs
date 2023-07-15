using MediatR;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Newme.Payment.Domain.Entities;
using Newme.Payment.Domain.Repositories;

namespace Newme.Payment.Application.Commands.RegisterDebitCardPayment
{
    public class RegisterDebitCardPaymentCommandHandler : 
        CommandHandler<RegisterDebitCardPaymentCommandHandler>,
        IRequestHandler<RegisterDebitCardPaymentCommand, ValidationResult>
    {
        private readonly IBaseRepository<DebitCard> _repository;

        public RegisterDebitCardPaymentCommandHandler(
            ILogger<RegisterDebitCardPaymentCommandHandler> logger,
            IBaseRepository<DebitCard> repository) : base(logger)
        {
            _repository = repository;
        }
        
        public async Task<ValidationResult> Handle(RegisterDebitCardPaymentCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(RegisterDebitCardPaymentCommandHandler)} starting");

            if (!command.IsValid())
            {
                AddError("Command model is invalid");
                return command.ValidationResult;
            }

            var payment = new DebitCard(
                id: Guid.NewGuid(),
                payerId: command.PayerId, 
                purchaseId: command.PurchaseId, 
                amountToBePaid: command.AmountToBePaid,
                number: command.Number,
                agency: command.Agency
            );

            await _repository.AddAsync(payment);

            _logger.LogInformation($"{nameof(RegisterDebitCardPaymentCommandHandler)} successfully completed");

            return ValidationResult;
        }
    }
}
