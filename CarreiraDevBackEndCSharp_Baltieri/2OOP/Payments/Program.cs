using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Payments
{
    class Program
    {
        static void Main(string[] args)
        {
            //IList<Payments> payments = new List<Payments>();
            //IEnumerable<Payments> payments = new List<Payments>();
            //ICollection<Payments> payments = new List<Payments>();
            var payments = new List<Payments>();
            payments.Add(new Payments(1));
            payments.Add(new Payments(2));
            payments.Add(new Payments(3));
            payments.Add(new Payments(4));
            payments.Add(new Payments(5));
            payments.Add(new Payments(6));

            foreach (var p in payments)
            {
                Console.WriteLine(p.Id);
            }

            // var paidPayments = new List<Payments>();
            // paidPayments.AddRange(payments);

            // O where retorna um IEnumerable
            // Ele aceita expressões como parametro
            // Caso queira retornar apenas um item, substitua o Where por First
            var payment = payments.First(x => x.Id == 3);
            //var payment = payments.Where(x => x.Id == 3);

            // Remover algo de uma lista
            // No caso eu passei aquele objeto que tem o ID 3 que foi retornado pelo first
            // Também temos o RemoveRange que remove uma sequencia de listas de uma lista
            payments.Remove(payment);

            // ANY Retorna um booleano se for encontrado
            var exist = payments.Any(x => x.Id == 3);

            // Count retorna quantos itens tem na lista dado uma expressão
            var exists = payments.Count(x => x.Id == 3);
            // Mas o count tbm pode ser usado de outras formas, como para pegar o tamanho de uma lista
            // Abaixo ele vai retornar um inteiro que é equivalente ao tamanho da lista
            var listRange = payments.Count();

            // Também temos o Skip que pula um item da lista
            var skip = payments.Skip(1);

            // Também temos o Take que retorna quantos itens da lista eu quero. Pega quantos itens da lista eu quero
            // Abaixo ele vai pegar apenas os 3 primeiros elementos da lista
            var take = payments.Take(3);

            // E o Skip e o Take podem ser usados juntos
            foreach (var pay in payments.Skip(1).Take(3))
            {
                Console.WriteLine(pay.Id);
            }

            // Converte a lista para um Enumerable
            payments.AsEnumerable();

            // Converte o Enumerable para uma lista
            payments.ToList();

            // Converte para um array, seja enumerable ou lista
            payments.ToArray();


        }
    }

    public class Payments
    {
        public int Id { get; set; }

        public Payments(int id)
        {
            Id = id;
        }
    }

}