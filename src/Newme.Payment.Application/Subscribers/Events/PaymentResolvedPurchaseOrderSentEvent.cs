using Newtonsoft.Json;

namespace Newme.Payment.Application.Subscribers.Events
{
    public class PaymentResolvedPurchaseOrderSentEvent
    {
        public PaymentResolvedPurchaseOrderSentEvent(Guid id, Guid purchaseId, Guid buyerId, Guid paymentId, bool isPaymentAuthorized, String buyerName, String buyerEmail, double totalPrice)
        {
            Id = id;
            PurchaseId = purchaseId;
            BuyerId = buyerId;
            PaymentId = paymentId;
            IsPaymentAuthorized = isPaymentAuthorized;
            BuyerName = buyerName;
            BuyerEmail = buyerEmail;
            TotalPrice = totalPrice;
        }

        [JsonProperty("id")]
        public Guid Id { get; private set; }

        [JsonProperty("purchase_id")]
        public Guid PurchaseId { get; private set; }

        [JsonProperty("buyer_id")]
        public Guid BuyerId { get; private set; }

        [JsonProperty("payment_id")]
        public Guid PaymentId { get; private set; }

        [JsonProperty("is_payment_authorized")]
        public bool IsPaymentAuthorized {get; private set; }

        [JsonProperty("buyer_name")]
        public String BuyerName { get; private set; }

        [JsonProperty("buyer_email")]
        public String BuyerEmail { get; private set; }

        [JsonProperty("total_price")]
        public double TotalPrice {get; private set; }
    }
}