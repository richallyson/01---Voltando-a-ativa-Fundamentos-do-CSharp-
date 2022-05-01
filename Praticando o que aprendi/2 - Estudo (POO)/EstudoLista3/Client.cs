using System;

namespace EstudoLista3
{
    class Client
    {
        private decimal _debitBalance;
        public decimal DebitBalance
        {
            get { return _debitBalance; }
            set { _debitBalance = value; }
        }
        private decimal _creditBalance;
        public decimal CreditBalance
        {
            get { return _creditBalance; }
            set { _creditBalance = value; }
        }

        //public Payment payment;

        public decimal SetDebit()
        {
            Console.WriteLine("Digite o valor do saldo da sua carteira:");
            var valor = decimal.Parse(Console.ReadLine());
            return DebitBalance = valor;
        }

        public decimal SetCredit()
        {
            Console.WriteLine("Digite o valor do seu crédito:");
            var valor = decimal.Parse(Console.ReadLine());
            return CreditBalance = valor;
        }
    }
}