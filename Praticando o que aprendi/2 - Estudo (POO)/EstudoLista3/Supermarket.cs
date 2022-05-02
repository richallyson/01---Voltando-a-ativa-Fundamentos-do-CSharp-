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

        public Supermarket(List<Product> products, DateTime openWorkingTIme, DateTime closeWorkingTime, List<ShopCashiers> cashiers)
        {
            Products = products;
            OpenWorkingTime = openWorkingTIme;
            CloseWorkingTime = closeWorkingTime;
            Cashiers = cashiers;
        }

        public void SetSupermarket()
        {
            var Products = new List<Product>();
            //var guid = Guid.NewGuid();
            //Products.Add(new Product(guid, "Macarrão", DateTime.Now));
            var Cachiers = new List<ShopCashiers>();
            var supermarket = new Supermarket(Products, DateTime.Now, DateTime.Now, Cachiers);
            int supermarketListLenght = supermarket.Products.Count;
        }        
    }
}