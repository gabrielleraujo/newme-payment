using Newtonsoft.Json;

namespace Newme.Payment.Application.Subscribers.Events
{
    public class PurchaseRefundAsExchangeVoucherReceivedEvent
    {
        [JsonProperty("id")]
        public Guid Id { get; private set; }

        [JsonProperty("purchase_id")]
        public Guid PurchaseId { get; private set; }

        [JsonProperty("buyer_id")]
        public Guid BuyerId { get; private set; }

        [JsonProperty("total_price")]
        public double TotalPrice {get; private set; }
    }
}