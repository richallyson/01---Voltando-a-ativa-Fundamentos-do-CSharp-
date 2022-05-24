using System.Collections.Generic;

namespace DataAcessDapper.Models
{
    public class Career
    {
        public Career()
        {
            CareerItems = new List<CareerItem>();
        }
        public System.Guid Id { get; set; }
        public string Title { get; set; }
        public IList<CareerItem> CareerItems { get; set; }
    }
}