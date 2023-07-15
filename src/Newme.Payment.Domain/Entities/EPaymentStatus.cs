using System.ComponentModel;

namespace Newme.Payment.Domain.Entities
{
    public enum EPaymentStatus
    {
        [Description("Aguardando a validaçãp do pagamento")]
        PaymentValidation,

        [Description("Pagamento autorizado.")]
        AuthorizedPayment,

        [Description("Pagamento rejeitado.")]
        UnauthorizedPayment
    }
}