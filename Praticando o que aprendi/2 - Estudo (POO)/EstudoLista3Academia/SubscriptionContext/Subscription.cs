using System;
using EstudoLista3.SharedContext;

namespace EstudoLista3.SubscriptionContext
{
    public abstract class Subscription : Base
    {
        public DateTime? EndTime { get; set; }
        public bool IsInactive => EndTime <= DateTime.Now;
    }
}