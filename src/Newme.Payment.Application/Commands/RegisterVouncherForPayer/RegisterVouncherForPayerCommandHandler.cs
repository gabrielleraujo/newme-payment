using MediatR;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Newme.Payment.Domain.Entities;
using Newme.Payment.Domain.Repositories;

namespace Newme.Payment.Application.Commands.RegisterVouncherForPayer
{
    public class RegisterVouncherForPayerCommandHandler : 
        CommandHandler<RegisterVouncherForPayerCommandHandler>,
        IRequestHandler<RegisterVouncherForPayerCommand, ValidationResult>
    {
        private readonly IBaseRepository<ExchangeVouncher> _repository;

        public RegisterVouncherForPayerCommandHandler(
            ILogger<RegisterVouncherForPayerCommandHandler> logger,
            IBaseRepository<ExchangeVouncher> repository) : base(logger)
        {
            _repository = repository;
        }
        
        public async Task<ValidationResult> Handle(RegisterVouncherForPayerCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(RegisterVouncherForPayerCommandHandler)} starting");

            if (!command.IsValid())
            {
                AddError("Command model is invalid");
                return command.ValidationResult;
            }

            var exchangeVouncher = new ExchangeVouncher(
                id: Guid.NewGuid(),
                payerId: command.Event.BuyerId,
                balance: command.Event.TotalPrice
            );

            await _repository.AddAsync(exchangeVouncher);

            _logger.LogInformation($"{nameof(RegisterVouncherForPayerCommandHandler)} successfully completed");

            return ValidationResult;
        }
    }
}
