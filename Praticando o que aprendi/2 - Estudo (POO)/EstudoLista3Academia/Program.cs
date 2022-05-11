using System;
using System.Collections.Generic;
using System.Linq;
using EstudoLista3.ContentContext;
using EstudoLista3.PaymentContext;
using EstudoLista3.SubscriptionContext;

namespace EstudoLista3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criando um usuário
            var user1 = new User("Francisco", "frcisco@gmail.com", "teste", 70.52m);

            // Criado os serviços existentes na academia
            var services = new List<Service>();
            var serviceMarcialArts = new Service("Artes Marcias", "artes-marciais", 60.50m);
            var serviceSwimming = new Service("Natação", "natacao", 80.00m);
            var serviceAc1 = new Service("Academia - 3x na semana", "academia-tresdia", 50.00m);
            var serviceAc2 = new Service("Academia - Todos os dias da semana", "academia-todososdias", 60.00m);
            var nutritionist = new Service("Nutrição", "nutricao", 120.00m);
            var crossfit = new Service("Crossfit", "crossfit", 80.00m);
            services.Add(serviceAc1);
            services.Add(serviceAc2);
            services.Add(serviceMarcialArts);
            services.Add(serviceSwimming);
            services.Add(nutritionist);
            services.Add(crossfit);

            // Criando os planos
            var plans = new List<Plans>();
            var basicPlan = new Plans("Plano básico", "plano-basico", 170.00m);
            var planItem1 = new PlansItem(1, "Começando na Academia", "Adaptação anatômica", 30, serviceAc1);
            var planItem2 = new PlansItem(3, "Hora de botar pra render!", "Depois da adaptação anatômica, chega a hora de inciar a hipertrofia", 30, serviceAc2);
            var planItem3 = new PlansItem(2, "Consulta com nutricionista", "Alimentação é 75% do trabalho", 1, nutritionist);
            basicPlan.Items.Add(planItem1);
            basicPlan.Items.Add(planItem2);
            basicPlan.Items.Add(planItem3);
            plans.Add(basicPlan);

            // foreach (var plan in plans)
            // {
            //     foreach (var item in plan.Items.OrderBy(x => x.Order))
            //     {
            //         Console.WriteLine(item.Order);
            //         Console.WriteLine(item.Title);
            //         Console.WriteLine(item.Description);
            //         Console.WriteLine(item.Duration);
            //     }
            // }

            // Gerando subscrição 
            var pixSub = new PixSubscription(new PixPayment(user1, Guid.NewGuid().ToString(), "Vamo testar", basicPlan));
            var debiCardSub = new DebitCardSubscription(new DebitCardPayment(user1, serviceAc1));
        }
    }
}
