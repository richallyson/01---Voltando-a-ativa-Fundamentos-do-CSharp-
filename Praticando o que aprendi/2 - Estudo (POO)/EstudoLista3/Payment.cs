using System;
using System.Threading;

namespace EstudoLista3
{
    public class Payment
    {
        public DateTime PaymentDate { get; set; }
        public decimal Value { get; set; }

        public Payment(decimal value)
        {
            Value = value;
        }
        internal virtual void Pagamento(Client client, decimal value)
        {
            if (client.DebitBalance >= value)
            {
                client.DebitBalance -= value;
                Console.WriteLine("O seu pagamento foi realizado com sucesso!");
            }
            else
                Console.WriteLine("Saldo insuficiente!");
        }
    }
    public class CardPayment : Payment
    {
        public CardPayment(decimal value) : base(value)
        {
            Value = value;
        }
        internal override void Pagamento(Client client, decimal value)
        {
            //base.Pagamento(client, value);
            Console.WriteLine("Seu pagamento vai ser no débito ou no crédito?");
            Console.WriteLine("1 - Para crédito");
            Console.WriteLine("2 - Para débito");
            Console.WriteLine("0 - Para desistir da compra");
            var escolha = int.Parse(Console.ReadLine());

        start:
            switch (escolha)
            {

                case 0: Environment.Exit(0); break;
                case 1:
                    if (client.DebitBalance >= value)
                    {
                        client.DebitBalance -= value;
                        Console.WriteLine("O seu pagamento foi realizado com sucesso!");
                        Console.WriteLine($"Você pagou {value} na compra e seu saldo agora é de {client.DebitBalance}");
                    }
                    break;
                case 2:
                    if (client.CreditBalance >= value)
                    {
                        client.CreditBalance -= value;
                        Console.WriteLine("O seu pagamento foi realizado com sucesso!");
                    }
                    break;
                default:
                    Console.WriteLine("Você não escolheu nenhuma opção viavél.");
                    Thread.Sleep(2000);
                    goto start;
            }

        }

    }
}