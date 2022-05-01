using System;
using System.Collections.Generic;

namespace EstudoLista3
{
    class Supermarket
    {
        public List<Product> Products { get; set; }
        public DateTime OpenWorkingTime { get; set; }
        public DateTime CloseWorkingTime { get; set; }
        public List<ShopCashiers> Cashiers { get; set; }

    }
}