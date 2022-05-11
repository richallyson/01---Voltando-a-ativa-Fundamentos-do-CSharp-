using System;
using EstudoLista3.PaymentContext;

namespace EstudoLista3.SubscriptionContext
{
    public class PixSubscription : Subscription
    {
        public PixSubscription(PixPayment pixPaymentSub)
        {
            PixPaymentSub = pixPaymentSub;
        }

        public PixPayment PixPaymentSub { get; set; }
    }
}