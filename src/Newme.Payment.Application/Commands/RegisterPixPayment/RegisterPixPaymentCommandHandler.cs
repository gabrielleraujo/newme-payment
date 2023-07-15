using MediatR;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Newme.Payment.Domain.Entities;
using Newme.Payment.Domain.Repositories;

namespace Newme.Payment.Application.Commands.RegisterPixPayment
{
    public class RegisterPixPaymentCommandHandler : 
        CommandHandler<RegisterPixPaymentCommandHandler>,
        IRequestHandler<RegisterPixPaymentCommand, ValidationResult>
    {
        private readonly IBaseRepository<Pix> _repository;

        public RegisterPixPaymentCommandHandler(
            ILogger<RegisterPixPaymentCommandHandler> logger,
            IBaseRepository<Pix> repository) : base(logger)
        {
            _repository = repository;
        }
        
        public async Task<ValidationResult> Handle(RegisterPixPaymentCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(RegisterPixPaymentCommandHandler)} starting");

            if (!command.IsValid())
            {
                AddError("Command model is invalid");
                return command.ValidationResult;
            }

            var payment = new Pix(
                id: Guid.NewGuid(),
                payerId: command.PayerId, 
                purchaseId: command.PurchaseId, 
                amountToBePaid: command.AmountToBePaid,
                copyPaste: command.CopyPaste,
                dueDate: command.DueDate
            );

            await _repository.AddAsync(payment);

            _logger.LogInformation($"{nameof(RegisterPixPaymentCommandHandler)} successfully completed");

            return ValidationResult;
        }
    }
}
