using MediatR;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Newme.Payment.Domain.Entities;
using Newme.Payment.Domain.Repositories;
using Newme.Payment.Infrastructure.Messaging;
using Newme.Payment.Application.Subscribers.Events;

namespace Newme.Payment.Application.Commands.ChangePaymentStatus
{
    public class ChangePaymentStatusCommandHandler<T> : 
        CommandHandler<ChangePaymentStatusCommandHandler<T>>,
        IRequestHandler<ChangePaymentStatusCommand<T>, ValidationResult> where T : PaymentBase
    {
        private readonly IBaseRepository<T> _repository;
        private readonly IMessageBusServer _messageBus;

        public ChangePaymentStatusCommandHandler(
            ILogger<ChangePaymentStatusCommandHandler<T>> logger,
            IBaseRepository<T> repository,
            IMessageBusServer messageBus) : base(logger)
        {
            _repository = repository;
            _messageBus = messageBus;
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

            var payment = await _repository.GetByIdAsync(command.Id);

            var sentEvent = new PaymentResolvedPurchaseOrderSentEvent(
                id: Guid.NewGuid(),
                purchaseId: payment.PurchaseId,
                buyerId: payment.PayerId,
                paymentId: payment.Id,
                isPaymentAuthorized: command.Status == EPaymentStatus.AuthorizedPayment,
                totalPrice: payment.AmountToBePaid
            );

            _messageBus.Publish(sentEvent, PaymentResolvedPurchaseOrderSentEvent.Name);

            _logger.LogInformation($"{nameof(ChangePaymentStatusCommandHandler<T>)} successfully completed");

            return ValidationResult;
        }
    }
}
