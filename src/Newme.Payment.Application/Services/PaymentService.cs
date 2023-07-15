using FluentValidation.Results;
using Newme.Payment.Application.InputModels;
using Newme.Payment.Application.Commands.RegisterCreditCardPayment;
using AutoMapper;
using MediatR;
using Newme.Payment.Application.Commands.RegisterDebitCardPayment;
using Newme.Payment.Application.Commands.RegisterPixPayment;
using Newme.Payment.Application.Utils;

namespace Newme.Payment.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PaymentService(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ValidationResult> RegisterCreditCardPayment(RegisterCreditCardPaymentInputModel inputModel)
        {
            return await _mediator.Send(_mapper.Map<RegisterCreditCardPaymentCommand>(inputModel));
        }

        public async Task<ValidationResult> RegisterDebitCardPayment(RegisterDebitCardPaymentInputModel inputModel)
        {
            return await _mediator.Send(_mapper.Map<RegisterDebitCardPaymentCommand>(inputModel));
        }

        public async Task<ValidationResult> RegisterPixPayment(RegisterPixPaymentInputModel inputModel)
        {
            return await _mediator.Send(_mapper.Map<RegisterPixPaymentCommand>(inputModel));
        }

        public async Task<ValidationResult> ChangeStatus(ChangePaymentStatusInputModel inputModel)
        {
            var command = _mapper.Map(
                inputModel, 
                typeof(ChangePaymentStatusInputModel), 
                PaymentType.ChangePaymentStatusCommand[inputModel.Type]);

            var response = await _mediator.Send(command);
            return (ValidationResult)response!;
        }
    }
}
