using System.Collections.Generic;
using Balta.ContentContext.Enums;

namespace Balta.ContentContext
{
    public class Course : Content
    {
        public Course(string title, string url) : base(title, url)
        {
            Modules = new List<Module>();
        }

        public string Tag { get; set; }
        public IList<Module> Modules { get; set; }
        // Se der numero quebrado, sempre arredondar pra cima
        public int DurationInMinutes { get; set; }
        public EContentLevel Level { get; set; }

    }
}