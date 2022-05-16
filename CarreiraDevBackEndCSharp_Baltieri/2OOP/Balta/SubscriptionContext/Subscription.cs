using System;
using Balta.SharedContext;

namespace Balta.SubscriptionContext
{
    public class Subscription : Base
    {
        public Plan Plan { get; set; }
        public DateTime? EndTime { get; set; }
        public bool IsInactive => EndTime <= DateTime.Now;
    }
}