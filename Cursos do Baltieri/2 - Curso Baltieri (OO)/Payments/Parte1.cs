using System;

namespace Payments
{
    class Parte1
    {
        // Nesta parte 1 nós estudamos o conceito de objetos, classes, encapsulamento e abstração
        static void Main(string[] args)
        {
            // === OBJETO ===
            // Um objeto é composto de 3 items: propriedades, metodos e eventos;
            // Propriedades definem as caracteristicas do objeto (prop)
            // Os métodos são as funcionalidades e ações que o objeto conseguem realizar
            // Os eventos são coisas que o objeto pode receber depois de realizar alguma ação

            // === Diferença entre classes e objetos ===
            // Um objeto sempre vai ser um tipo de referência
            // A classe é um molde para o objeto
            // Lembra do struct? Pois é. É basicamente a mesma coisa, porém, o struct é bom para se trabalhar com tipos de valor
            // O struct armazena o valor em si - memória stack
            // Já a classe é para se trabalhar com tipos de referência  
            // A classe armazena apenas o endereço - memória heap
            // Um objeto é um elemento que é instanciado a a partir da criação de uma classe
            var pag = new Pagamento();

            Console.WriteLine("Hello World!");
        }

        // === ENCAPSULAMENTO ===
        // O conceito de trazer tudo o que um pagamento pode realizar, se chama encapsulamento
        // Lembra que os objetos são criados a partir das classes que são seus moldes? Psé
        // Dentro das classes iremos conter as própriedades, metódos e eventos que o objeto vai possuir
        // Isso se chama de encapsulamento
        class Pagamento
        {
            // As váriareis são todas as propriedades
            DateTime Vencimento;
            // As funções são os métodos
            void Pagar()
            {
                ConsultarSaldoDoCartao();
            }

            // === ABSTRAÇÃO ===
            // Esse metódo foi criado para falar sobre o conceito de abstração
            // Abastração nada mais é do quê alcançar um resultado, sem que necessariamente você precise saber como aconteceu
            // Por exemplo, quando você leva seu carro para o concerto, ele vai voltar para você consertado
            // Você não sabe o que aconteceu na mecanica, etc. Mas ele voltou consertado
            // Isso foi uma abstração do conserto do qual você precisou
            // A mesma coisa serve aqui para baixo. Não seria interessante outras partes do programa saber o saldo do cartão do cliente
            // Sendo assim, esse é um metodo abstrato que vai acontecer ali por trás, sem que precise ser mostrado
            // Ao pagar vc precisa ter saldo, é consultado esse saldo, e retornado para o pagar, porém essa função, como está private, só pode ser usada aqui no contexto dessa classe
            // Algumas coisas na programação não faz sentido serem mostradas. No ato de pagar, alguns metodos vão ser chamados...
            // E esses metodos não precisam ser mostrados ou acessados, pois não fazem sentido no contexto atual. Afinal são informações vitais de clientes
            private void ConsultarSaldoDoCartao()
            {

            }

            // E os eventos os eventos 
            //event AoPagar();
        }
    }
}
