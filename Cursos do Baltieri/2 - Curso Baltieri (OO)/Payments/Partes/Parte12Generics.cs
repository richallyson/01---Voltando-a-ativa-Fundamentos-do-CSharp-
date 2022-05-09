// using System;

// namespace Payments
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             var person = new Person();
//             var payment = new Payment();
//             var subscription = new Subscription();
//             var context = new DataContext<Person, Payment, Subscription>();
//             context.Save(person);
//             context.Save(payment);
//             context.Save(subscription);
//         }
//     }

//     // Criando tipos genericos
//     // O contexto usado é que, imagina que eu quero salvar algo para o servidor, mas não quero ter que ficar recriando função
//     public class DataContext<P, PA, S>
//         // O where limita o tipo que vai ser recebido quando o tipo generico for instanciada
//         where P : Person
//         where PA : Payment
//         where S : Subscription
//     {
//         public void Save(P entity)
//         {

//         }

//         public void Save(PA entity)
//         {

//         }

//         public void Save(S entity)
//         {

//         }
//     }

//     public class Person { }
//     public class Payments { }
//     public class Subscription { }

// }