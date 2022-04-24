using System;

namespace EstudoLista1
{
    class Program
    {
        static void Main(string[] args)
        {
            // double cotacaoDolar = 4.70;

            // Console.WriteLine("Digite um valor em dolar:");
            // Console.WriteLine("");

            // double valor = double.Parse(Console.ReadLine());

            // Console.WriteLine($"O seu valor de dolares em real é: {valor * cotacaoDolar}");

            Vendendor vendedor1 = new Vendendor(1, 10, 150.00, 10);
            Console.WriteLine("Escreva o preço da peça:");
            vendedor1.PrecoUnitario = double.Parse(Console.ReadLine());
            Console.WriteLine("Escreva a quantidade de peças vendidas:");
            vendedor1.QtdVendida = int.Parse(Console.ReadLine());

            Console.WriteLine($"Você vendeu {vendedor1.QtdVendida} peças, e isso lhe da R$ {(vendedor1.PrecoUnitario * 0.05) * vendedor1.QtdVendida} de comissão");

        }
    }

    struct Vendendor
    {
        public Vendendor(int id, int cdPeca, double precoUnitario, int qtdVendida)
        {
            Id = id;
            CdPeca = cdPeca;
            PrecoUnitario = precoUnitario * 0.05;
            QtdVendida = qtdVendida;

            //Console.WriteLine($"Você vendeu {QtdVendida} peças, e isso lhe da R$ {PrecoUnitario * QtdVendida} de comissão");
        }

        public int Id;
        public int CdPeca;
        public double PrecoUnitario;
        public int QtdVendida;
    }
}