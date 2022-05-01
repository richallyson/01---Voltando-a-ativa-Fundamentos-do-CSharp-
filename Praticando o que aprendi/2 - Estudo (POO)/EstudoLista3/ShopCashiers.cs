using System;

namespace EstudoLista3
{

    class ShopCashiers
    {
        public string Name { get; set; }
        public DateTime EnterTime { get; set; }
        public DateTime OutTime { get; set; }


        public ShopCashiers(string name, DateTime enterTime, DateTime outTime)
        {
            Name = name;
            EnterTime = enterTime;
            OutTime = outTime;
        }
    }
}