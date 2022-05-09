using System;
using System.Collections.Generic;
using System.Linq;
using Balta.ContentContext;
using Balta.SubscriptionContext;

namespace Balta
{
    class Program
    {
        static void Main(string[] args)
        {
            var articles = new List<Article>();
            articles.Add(new Article("Artigo sobre POO", "orientacao-objetos"));
            articles.Add(new Article("Artigo sobre C#", "csharp"));
            articles.Add(new Article("Artigo sobre .NET", "dotnet"));

            // foreach (var article in articles)
            // {
            //     Console.WriteLine(article.Id);
            //     Console.WriteLine(article.Title);
            //     Console.WriteLine(article.Url);
            // }

            var courses = new List<Course>();
            var coursePOO = new Course("Fundamentos de POO", "fundamentos-poo");
            var courseCsharp = new Course("Fundamentos de C#", "fundamentos-csharp");
            var courseAspNet = new Course("Fundamentos de ASP.NET", "fundamentos-aspnet");
            courses.Add(coursePOO);
            courses.Add(courseCsharp);
            courses.Add(courseAspNet);

            var careers = new List<Career>();
            var careerDotNet = new Career("Especialista .NET", "especialista-dotnet");
            var careerItem3 = new CareerItem(3, "Programação Orientada a Objetos", "", null);
            var careerItem = new CareerItem(1, "Comece por aqui!", "", courseCsharp);
            var careerItem2 = new CareerItem(2, "Aprenda .NET", "", courseAspNet);
            careerDotNet.Items.Add(careerItem2);
            careerDotNet.Items.Add(careerItem);
            careerDotNet.Items.Add(careerItem3);
            careers.Add(careerDotNet);

            foreach (var career in careers)
            {
                Console.WriteLine(career.Title);
                foreach (var item in career.Items.OrderBy(x => x.Order))
                {
                    Console.WriteLine($"{item.Order} - {item.Title}");
                    // Null Check = Com a interrogação ele já checa automaticamente se o objeto é nulo
                    // Serve para tratar o system null reference exception
                    // Se o objeto não existir, ele não vai escrever nada na tela
                    Console.WriteLine(item.Course?.Title);
                    Console.WriteLine(item.Course?.Level);

                    foreach (var notification in item.Notifications)
                    {
                        Console.WriteLine($"{notification.Property} - {notification.Message}");
                    }
                }
            }

            var payPalSub = new PaypalSubscription();
            var student = new Student();
            student.CreateSubscription(payPalSub);

        }
    }
}
