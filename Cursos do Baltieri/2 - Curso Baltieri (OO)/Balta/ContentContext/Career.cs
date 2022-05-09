using System.Collections.Generic;

namespace Balta.ContentContext
{
    public class Career : Content
    {
        public Career(string title, string url) : base(title, url)
        {
            Items = new List<CareerItem>();
        }
        public IList<CareerItem> Items { get; set; }
        // Sempre que tiver apenas uma linha de retorno, pode se fazer o retorno da forma como abaixo
        // Isso se chama Expression Body
        public int TotalCourses => Items.Count;

    }
}