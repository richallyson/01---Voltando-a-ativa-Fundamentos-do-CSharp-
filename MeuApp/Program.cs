using System;

namespace MeuApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // var texto = "testando";
            // Console.WriteLine(texto);

            // int inteiro = int.Parse("100");
            // Console.WriteLine(inteiro);

            // string txt = Convert.ToString("150");
            // float real = 100.0f;
            // int numero = int.Parse(real.ToString());
            // float real = 99.8f;
            // inteiro = Convert.ToInt32(real);
            // Console.WriteLine(real);
            // Console.WriteLine(Convert.ToBoolean(1));

            // string valor = "Nosyy";

            // switch (valor)
            // {
            //     case "manel": Console.WriteLine("Não é o nome certo"); break;
            //     case "francisco": Console.WriteLine("Não é o nome certo"); break;
            //     case "richas": Console.WriteLine("Não é o nome certo"); break;
            //     case "Nosy": Console.WriteLine("Acertou mizeria"); break;
            //     case "Ueliton": Console.WriteLine("Não é o nome certo"); break;
            //     case "Vontade": Console.WriteLine("Não é o nome certo"); break;
            //     default: Console.WriteLine("Não encontrei"); break;

            // }

            // bool? buleano = null;

            // switch (buleano)
            // {
            //     case true: Console.WriteLine("Verdadeiro"); break;
            //     case false: Console.WriteLine("Falso"); break;
            //     default: Console.WriteLine("Null"); break;

            // }

            // for (var i = 0; i <= 5; i++)
            // {
            //     Console.WriteLine(i);
            // }

            // var valor = 0;

            // // while (valor <= 5)
            // // {
            // //     Console.WriteLine(valor);
            // //     valor++;
            // // }

            // do
            // {
            //     Console.WriteLine(valor);
            //     valor++;
            // } while (valor <= 5);

            // MeuMetodo();
            // string nome = RetornaNome("Nosy ", "Lima", 200, true, 27.42);
            // Console.WriteLine(nome);

            // //Tipo de valor
            // int x = 25;
            // int y = x;
            // Console.WriteLine(x);
            // Console.WriteLine(y);

            // x = 32;
            // Console.WriteLine(x);
            // Console.WriteLine(y);

            //Tipo de referência
            // var arr = new string[2];
            // arr[0] = "Item 1";

            // var arr2 = arr;
            // Console.WriteLine(arr[0]);
            // Console.WriteLine(arr2[0]);

            // arr[0] = "Item2";
            // Console.WriteLine(arr[0]);
            // Console.WriteLine(arr2[0]);       

            Product mouse = new Product();

            mouse.Id = 1;
            mouse.Name = "Razer";
            mouse.Price = 720.52;

            Console.WriteLine(mouse.Id);
            Console.WriteLine(mouse.Name);
            Console.WriteLine(mouse.Price);

            //Mesmas merda da parada de cima
            var teclado = new Product(2, "Multilixo", 2.99, EProductType.Product);
            var internet = new Product(3, "Brisa", 99.99, EProductType.Service);

            Console.WriteLine(teclado.Id);
            Console.WriteLine(teclado.Name);
            Console.WriteLine(teclado.Price);
            Console.WriteLine(teclado.Type);
            Console.WriteLine((int)teclado.Type);


        }

        //     static void MeuMetodo()
        //     {
        //         Console.WriteLine("C# é legal");
        //     }

        //     // Caso você precisa criar um parametro que n precise de referência/opcional, sete um valor a ele, como feito ali na idade. 
        //     //Assim ele não quebra o código caso você já use aquela função para outras coisas em versões anteriores
        //     static string RetornaNome(
        //         string nome,
        //         string sobrenome,
        //         int idade = 30,
        //         bool teste = false,
        //         double num = 30.0)
        //     {
        //         return nome + sobrenome + " tem ";
        //     }

    }

    struct Product
    {
        public Product(int id, string name, double price, EProductType type)
        {
            Id = id;
            Name = name;
            Price = price;
            Type = type;
        }

        public int Id;
        public string Name;
        public double Price;
        public EProductType Type;

        public double PriceInDolar(double dolar)
        {
            return Price * dolar;
        }
    }

    enum EProductType
    {
        Product = 1,
        Service = 2
    }
}

