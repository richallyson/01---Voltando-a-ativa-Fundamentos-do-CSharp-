using System.Collections.Generic;
using EstudoLista3.NotificationContext;

namespace EstudoLista3.ContentContext
{
    public class Plans : Content
    {
        public Plans(string title, string url, decimal price) : base(title, url)
        {
            if (Services == null)
                AddNotification(new Notification("Serviço", "Não existe nenhum serviço disponível"));
            Services = new List<PlansItem>();
            Price = price;
        }
        public IList<PlansItem> Services { get; set; }
        public decimal Price { get; set; }
    }
}