using System;
using EstudoLista3.ContentContext;
using EstudoLista3.SharedContext;
using EstudoLista3.SubscriptionContext;

namespace EstudoLista3.PaymentContext
{
    public abstract class Payment : Base
    {
        protected Payment(User user, Plans plans)
        {
            PaymentTime = DateTime.Now;
            User = user;
            Plans = plans;
        }

        protected Payment(User user, Service service)
        {
            PaymentTime = DateTime.Now;
            User = user;
            Service = service;
        }

        public DateTime PaymentTime { get; set; }
        public User User { get; set; }
        public Service Service { get; set; }
        public Plans Plans { get; set; }
    }
}