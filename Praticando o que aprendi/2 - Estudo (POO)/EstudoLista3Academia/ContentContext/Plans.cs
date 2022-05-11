using System.Collections.Generic;
using EstudoLista3.NotificationContext;

namespace EstudoLista3.ContentContext
{
    public class Plans : Content
    {
        public Plans(string title, string url, decimal price) : base(title, url)
        {
            if (Items == null)
                AddNotification(new Notification("Serviço", "Não existe nenhum serviço disponível"));
            Items = new List<PlansItem>();
            Price = price;
        }
        public IList<PlansItem> Items { get; set; }
        public decimal Price { get; set; }
    }
}