namespace EstudoLista3.SubscriptionContext
{
    public class User
    {
        public User(string name, string password, decimal wallet)
        {
            Name = name;
            Password = password;
            Wallet = wallet;
        }

        public string Name { get; set; }
        public string Password { get; set; }
        public decimal Wallet { get; set; }
    }
}