namespace Newme.Payment.Infrastructure.Persistence.Mappers
{
    public static class MongoMapper
    {
        public static void Configure()
        {
            EntityMapper.Map();
            PaymentMapper.Map();
            CardMapper.Map();
            CreditCardMapper.Map();
            DebitCardMapper.Map();
            PixMapper.Map();
            ExchangeVouncherMapper.Map();
            StatusMapper.Map();
        }
    }
}