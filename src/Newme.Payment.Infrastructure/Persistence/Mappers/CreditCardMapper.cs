using MongoDB.Bson.Serialization;
using Newme.Payment.Domain.Entities;

namespace Newme.Payment.Infrastructure.Persistence.Mappers
{
    public static class CreditCardMapper
    {
        public static void Map()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(CreditCard)))
            {
                BsonClassMap.RegisterClassMap<CreditCard>(classMap =>
                {
                    classMap.AutoMap();
                    classMap.SetIgnoreExtraElements(true);
                    classMap.MapMember(p => p.NumberInstallments).SetElementName("number_installments");
                    classMap.MapMember(p => p.NumberInstallmentsPaid).SetElementName("number_installments_paid");
                    classMap.MapMember(p => p.InstallmentValue).SetElementName("installment_value");
                    classMap.MapMember(p => p.TotalInterest).SetElementName("total_interest");
                });
            }
        }
    }
}