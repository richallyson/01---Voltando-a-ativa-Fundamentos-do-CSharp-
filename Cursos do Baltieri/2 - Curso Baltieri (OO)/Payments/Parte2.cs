using System;

namespace Payments
{
    class Parte2
    {
        // Nesta parte 2 vimos Herança e Polimorfismo. Pensei em botar mais coisas, porém esses dois conteúdos...
        // Já são densos o suficiente para se ver. Caso esteja vendo isso, treine bastante essa parte!
        static void Main(string[] args)
        {
            var pag = new Pagamento();
            //=== HERANÇA ===
            var pagamentoBoleto = new PagamentoBoleto();
            // Podemos ver que conseguimos acessar tudo o que foi herdado da classe pai
            pagamentoBoleto.Pagar();
            pagamentoBoleto.Vencimento = DateTime.Now;
            pagamentoBoleto.NumerBoleto = "teste";
            var pagamentoTeste = new Pagamento();
            pagamentoBoleto.ToString();
            Console.WriteLine("Hello World!");
        }

        class Pagamento
        {
            public DateTime Vencimento;

            // Esse virtual é referente ao conteúdo de polimorfismo que pode ser visto na função PagamentoCartaoCredito
            public virtual void Pagar()
            {

            }

            // Um exemplo do uso do polimorfismo fazendo um override no ToString()
            // Dentro dessa classe, tada vez que eu chamar o ToString(), ao invés de ele retornar o que um ToString()...
            // deveria retornar, ele vai retornar o que foi proposto abaixo com o override
            public override string ToString()
            {
                return "Meu teste";
            }

        }
        //=== HERANÇA ===
        // Existe um conceito em OO que se chama herança. Que é bem literal em seu nome
        // Como vemos abaixo, criamos a classe PagamentoBoleto. E um pagamento de boleto possui as mesmas caracteristiscas que a de um pagamento
        // Sendo assim, para não precisar repetir informação de uma classe para outra, nós usamos a herança
        // A herança faz com que a classe criada, herde as propriedades, metodos e eventos da classe pai/mãe
        // Lembrando que ele herda apenas tudo o que é public ou protected (Testei com protected e não deu) .
        // Podemos ver o exemplo prático na main
        // O CSharp não tem capacidade de fazer heranças multiplas, como no exemplo abaixo comentado
        // class PagamentoCartao : Pagamento, PagamentoBoleto
        class PagamentoBoleto : Pagamento
        {
            public string NumerBoleto;
        }

        // === POLIMORFISMO ===
        // Como sabemos um pagamento pode ter diversas regras, seja cartão, boleto, dinheiro fisíco, etc
        // O polimorfismo vem justamente para caso uma classe filha necessite, mudar algumas coisas dentro dela
        // A função Pagar() na classe pai, vem com a palavra virtual nela. Essa palavra faz com que, caso eu queira...
        // as funções filhas podem sobrescrever a função para aplicar as suas próprias regras
        // Para isso, se usa o override, como visto abaixo 
        class PagamentoCartaoCredito : Pagamento
        {
            public string Numero;

            public override void Pagar()
            {
                // Regras do pagamento com cartão
            }
        }
    }
}
