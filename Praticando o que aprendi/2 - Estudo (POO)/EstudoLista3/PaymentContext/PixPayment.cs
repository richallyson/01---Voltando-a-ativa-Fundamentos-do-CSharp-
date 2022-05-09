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
            Service service,
            Plans plans,
            string pixKey,
            string Message = "")
        : base(user, service, plans)
        {
            PixKey = pixKey;
            if (user.Wallet < service.Price || user.Wallet < plans.Price)
            {
                AddNotification(new Notification("Compra", "Sua compra não foi autorizada. Saldo insuficiente!"));
            }
        }

        public string PixKey { get; set; }
        public string Message { get; set; }

    }
}