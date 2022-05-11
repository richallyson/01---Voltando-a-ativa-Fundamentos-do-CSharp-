using System;
using EstudoLista3.ContentContext;
using EstudoLista3.NotificationContext;
using EstudoLista3.SubscriptionContext;

namespace EstudoLista3.PaymentContext
{
    public class PixPayment : Payment
    {
        public PixPayment(
            User user,
            string pixKey,
            string Message = "",
            Plans plans = null)
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

            PixKey = pixKey;
        }

        public PixPayment(
                    User user,
                    string pixKey,
                    string Message = "",
                    Service service = null)
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

            PixKey = pixKey;
        }

        public string PixKey { get; set; }
        public string Message { get; set; }
    }
}