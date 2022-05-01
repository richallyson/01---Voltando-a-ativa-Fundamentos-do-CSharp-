using System;

namespace Payments
{
    class Program
    {
        // Esse projeto passa por cima de todos os conceitos de OO. 
        // Para não ficar lotado demais, toda vez que eu achar necessário, vou dividir o conteúdo em outros arquivos chamados Parte
        static void Main(string[] args)
        {
            var pag = new Pagamento();
        }
    }

    public class Pagamento
    {
        public DateTime Vencimento;
        private DateTime _dataPagamento;
        public DateTime DataPagamento
        {
            get { return _dataPagamento; }
            set { _dataPagamento = value; }
        }

        // Famigerado metodo construtor
        // Toda vez que você criar um construtor na classe pai, as classes filhas tbm tem que criar um constrtor
        public Pagamento(DateTime dataPagamento)
        {
            Vencimento = DateTime.Now;
            _dataPagamento = dataPagamento;
        }

        // Caso você não queira criar um construtor na classe filha, você tem que criar uma sobrecarga da função construtora do pai
        // Essa função se chama de função parameterless
        // Mas caso você queira sempre receber o parametro no construtor, você deve fazer como mostrado na classe PagamentoCartao
        //public Pagamento() { }

        public void Pagar(string teste)
        {

        }

        // Isso aqui de criar o metodo com o mesmo nome, e com argumentos a mais e trazendo os argumentos antigos...
        // se chama sobrecarga
        // Sobreescrita é quando você usa o virtual na função pai e na filha bota um override
        // E lembrando que para chamar o metodo do pai, é só usar o base.NomeDaFuncao()
        public void Pagar(string teste, DateTime vencimento)
        {

        }
        // O mesmo metodo que o acima, com parametros diferentes
        // Relembrando que se você já passar um valor no argumento, ele n precisa setado quando for chamado, só se quiser
        // Ela vira opcional e sempre tem que vir por final
        public void Pagar(string teste, DateTime vencimento, bool pagarAposVencimento = true)
        {

        }
    }

    public class PagamentoCartao : Pagamento
    {
        public PagamentoCartao(DateTime dataPagamento)
        // Fazendo isso aqui você vai solucionar o problema em relação a criação do construtor, caso a classe pai peça um de forma obrigatoria        
        // Basicamente eu estou fazendo uma herança do construtor base usando o :
        : base(dataPagamento)
        {

        }
    }
}