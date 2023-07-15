using MediatR;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Newme.Payment.Domain.Entities;
using Newme.Payment.Domain.Repositories;

namespace Newme.Payment.Application.Commands.ChangePaymentStatus
{
    public class ChangePaymentStatusCommandHandler<T> : 
        CommandHandler<ChangePaymentStatusCommandHandler<T>>,
        IRequestHandler<ChangePaymentStatusCommand<T>, ValidationResult> where T : PaymentBase
    {
        private readonly IBaseRepository<T> _repository;

        public ChangePaymentStatusCommandHandler(
            ILogger<ChangePaymentStatusCommandHandler<T>> logger,
            IBaseRepository<T> repository) : base(logger)
        {
            _repository = repository;
        }
        
        public async Task<ValidationResult> Handle(ChangePaymentStatusCommand<T> command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(ChangePaymentStatusCommandHandler<T>)} starting");

            if (!command.IsValid())
            {
                AddError("Command model is invalid");
                return command.ValidationResult;
            }
            await _repository.UpdateAsync(command.Id, command.Status, x => x.Status);

            _logger.LogInformation($"{nameof(ChangePaymentStatusCommandHandler<T>)} successfully completed");

            return ValidationResult;
        }
    }
}
