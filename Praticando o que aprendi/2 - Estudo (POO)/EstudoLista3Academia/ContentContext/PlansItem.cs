using System.Collections.Generic;
using EstudoLista3.SharedContext;

namespace EstudoLista3.ContentContext
{

    public class PlansItem : Base
    {
        public PlansItem(int order, string title, string description, int duration, Service serviceType)
        {
            Order = order;
            Title = title;
            Description = description;
            Duration = duration;
            ServiceType = serviceType;
        }

        public int Order { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public Service ServiceType { get; set; }
    }
}