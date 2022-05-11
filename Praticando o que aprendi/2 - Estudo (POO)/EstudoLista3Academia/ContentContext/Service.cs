using EstudoLista3.SharedContext;

namespace EstudoLista3.ContentContext
{
    public class Service : Content
    {
        public Service(string title, string url, decimal price) : base(title, url)
        {
            Price = price;
        }
        public decimal Price { get; set; }
    }
}