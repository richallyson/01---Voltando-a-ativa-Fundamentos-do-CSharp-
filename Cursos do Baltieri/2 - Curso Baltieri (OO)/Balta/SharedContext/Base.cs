using System;
using Balta.NotificationContext;

namespace Balta.SharedContext
{
    public abstract class Base : Notifiable
    {
        public Base()
        {
            Id = Guid.NewGuid();
            // SPOF  = Single point of failure
            // Quantos menos pontos de falhar melhor
            // Aqui toda classe que vai herdar content, já vai setar um id automatico
        }

        public Guid Id { get; set; }

    }
}