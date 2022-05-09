using System;
using EstudoLista3.ContentContext;
using EstudoLista3.SubscriptionContext;

namespace EstudoLista3.PaymentContext
{
    public class DebitCardPayment : Payment
    {
        public DebitCardPayment(User user, Service service, Plans plans)
        : base(user, service, plans)
        {

        }
        

    }
}