using System;
using EstudoLista3.ContentContext;
using EstudoLista3.SharedContext;
using EstudoLista3.SubscriptionContext;

namespace EstudoLista3.PaymentContext
{
    public abstract class Payment : Base
    {
        protected Payment(User user, Service service = null, Plans plans = null)
        {
            PaymentTime = DateTime.Now;
            User = user;
            Service = service;
            Plans = plans;
        }

        public DateTime PaymentTime { get; set; }
        public User User { get; set; }
        public Service Service { get; set; }
        public Plans Plans { get; set; }
    }
}