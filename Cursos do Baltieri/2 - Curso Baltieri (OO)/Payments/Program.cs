using System;

namespace Payments
{
    class Program
    {
        static void Main(string[] args)
        {
            var pag = new Pagamento();
        }

        // === MODIFICADORES DE ACESSO ===
        // Os modificadores são o public, internal, protected e private        
        // Internal = Pode ser acessivel dentro do mesmo namespace

        // Public = pode ser acessado em qualquer lugar
        public class Pagamento
        {
            // Private = Só vai ser visivel dentro da classe
            private DateTime Vencimento;

            // Caso você não defina o modificador de acesso de algo, ele como padrão vem private, como na variavel teste.            
            protected int Test;

            // Protected = Só pode ser acessado pelas classes filhas
            protected void Pagar()
            {

            }
        }

        public class PagamentoBoleto : Pagamento
        {
            // Para acessar algo protected da classe pai, você precisa antes botar o base.
            void Teste()
            {
                base.Pagar();
            }
        }
    }
}
