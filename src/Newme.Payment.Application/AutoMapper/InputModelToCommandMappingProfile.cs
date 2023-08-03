using AutoMapper;
using Newme.Payment.Application.Commands.ChangePaymentStatus;
using Newme.Payment.Application.Commands.RegisterCreditCardPayment;
using Newme.Payment.Application.Commands.RegisterDebitCardPayment;
using Newme.Payment.Application.Commands.RegisterPixPayment;
using Newme.Payment.Application.InputModels;
using Newme.Payment.Domain.Entities;

namespace Newme.Payment.Application.AutoMapper
{
    public class InputModelToCommandMappingProfile : Profile
    {
        public InputModelToCommandMappingProfile()
        {
            CreateMap<RegisterPixPaymentInputModel, RegisterPixPaymentCommand>()
                .ConstructUsing(x => new RegisterPixPaymentCommand(
                    x.PayerId,
                    x.PurchaseId,
                    x.AmountToBePaid,
                    x.CopyPaste,
                    x.DueDate
                ));

            CreateMap<RegisterDebitCardPaymentInputModel, RegisterDebitCardPaymentCommand>()
                .ConstructUsing(x => new RegisterDebitCardPaymentCommand(
                    x.PayerId,
                    x.PurchaseId,
                    x.AmountToBePaid,
                    x.Number,
                    x.Code,
                    x.Expiration
                ));

            CreateMap<RegisterCreditCardPaymentInputModel, RegisterCreditCardPaymentCommand>()
                .ConstructUsing(x => new RegisterCreditCardPaymentCommand(
                    x.PayerId,
                    x.PurchaseId,
                    x.AmountToBePaid,
                    x.Number,
                    x.Code,
                    x.Expiration,
                    x.NumberInstallments,
                    x.NumberInstallmentsPaid,
                    x.InstallmentValue,
                    x.TotalInterest
                ));

            CreateMap<ChangePaymentStatusInputModel, ChangePaymentStatusCommand<Pix>>()
                .ConstructUsing(x => new ChangePaymentStatusCommand<Pix>(
                    x.Id,
                    x.Status
                ));
            CreateMap<ChangePaymentStatusInputModel, ChangePaymentStatusCommand<CreditCard>>()
                .ConstructUsing(x => new ChangePaymentStatusCommand<CreditCard>(
                    x.Id,
                    x.Status
                ));
            CreateMap<ChangePaymentStatusInputModel, ChangePaymentStatusCommand<DebitCard>>()
                .ConstructUsing(x => new ChangePaymentStatusCommand<DebitCard>(
                    x.Id,
                    x.Status
                ));
        }
    }
}