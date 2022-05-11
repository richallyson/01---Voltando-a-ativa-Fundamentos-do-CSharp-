using System;
using EstudoLista3.ContentContext;
using EstudoLista3.SubscriptionContext;

namespace EstudoLista3.PaymentContext
{
    public class DebitCardPayment : Payment
    {
        public DebitCardPayment(User user, Plans plans)
        : base(user, plans)
        {
            if (user.Wallet <= plans.Price)
            {
                Console.WriteLine("Saldo insuficiente!");
                return;
            }
            else
            {
                user.Wallet -= plans.Price;
                Console.WriteLine("Pagamento realizado com sucesso!");
            }
        }
        public DebitCardPayment(User user, Service service)
        : base(user, service)
        {
            if (user.Wallet <= service.Price)
            {
                Console.WriteLine("Saldo insuficiente!");
                return;
            }
            else
            {
                user.Wallet -= service.Price;
                Console.WriteLine("Pagamento realizado com sucesso!");
            }
        }
    }
}