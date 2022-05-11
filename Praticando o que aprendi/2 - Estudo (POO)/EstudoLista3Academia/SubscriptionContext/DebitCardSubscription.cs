using EstudoLista3.PaymentContext;

namespace EstudoLista3.SubscriptionContext
{
    public class DebitCardSubscription : Subscription
    {
        public DebitCardSubscription(DebitCardPayment debitCardSub)
        {
            DebitCardSub = debitCardSub;
        }

        public DebitCardPayment DebitCardSub { get; set; }
    }
}