using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;

        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        // OPEN CLOSE PRINCIPLE
        // Basicamente, você deixando os sets como privado, impede que depois de instanciado um objeto...
        // Ele não vai poder ser mudado por outra pessoa, que não seja a própria classe dele
        // Tipo, eu crio um student, e depois quero mudar o nome dele, pegando o First name e alterando diretamente
        // Isso não vai ser possivel. Para que isso possa ser feito, alguma função criada dentro do Studente deve ser chamada
        // Ex: var student = new Student("Richallyson", "Lima", "200047985269", "richas@gmail.com");
        // Ex: student.FirstName = "";
        // Esse cenário do exemplo não vai ser possivel. E isso se chama Open Close Principle
        // A classe está aberta para extensões, mas não para ser alterada por ngm de fora da classe
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        // Se fosse necessário excluir o endereço, ficaria melhor criar uma entidade, com o seu próprio ID
        // Isso ficaria melhor pelo fato de que quando eu fosse excluir esse endereço eu iria percorrer a tebela
        // para achar o ID desse endereço e assim excluir ela
        public Adress Adress { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            _subscriptions.Add(subscription);
            var hasSubscriptionActive = false;
            foreach (var sub in _subscriptions)
            {
                if (sub.Active)
                {
                    hasSubscriptionActive = true;
                    if (_subscriptions.Count > 1 || hasSubscriptionActive == true)
                    {
                        AddNotifications(new Contract()
                            .Requires()
                            .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Você já possui uma assinatura ativa!")
                        );
                    }
                }


            }

            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Você já possui uma assinatura ativa!")
                .AreEquals(0, subscription.Payments.Count, "Student.Subscription.Payments", "Esta assinatura não possui pagamentos.")
            );
        }
    }
}