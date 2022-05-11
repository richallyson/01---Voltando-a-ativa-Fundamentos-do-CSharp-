using System.Collections.Generic;

namespace EstudoLista3.SubscriptionContext
{
    public class User
    {
        public User(string name, string email, string password, decimal wallet)
        {
            // Paramo aqui, onde tenho que criar uma forma do usuário escolher o tipo de subscrição
            // E claro, chamar o pagamento
            Subscription = new List<Subscription>();
            Name = name;
            Email = email;
            Password = password;
            Wallet = wallet;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Wallet { get; set; }
        public List<Subscription> Subscription { get; set; }
    }
}