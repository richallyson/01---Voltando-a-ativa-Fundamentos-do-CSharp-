using System;
using EstudoLista3.NotificationContext;

namespace EstudoLista3.SharedContext
{
    public class Base : Notifiable
    {

        public Base()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}