using System;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            // === EXCEPTIONS ===
            // var arr = new int[3];

            // // Como já sabemos, o indice de uma array é fixo. No for abaixo vai ocorrer um erro.
            // // Pois nossa array só possui um indice de 3 e eu estou forçando o for a percorrer 10 vezes
            // // Esse vai ser o erro apresentado System.IndexOutOfRangeException: Index was outside the bounds of the array

            // for (int i = 0; i < 10; i++)
            // {
            //     Console.WriteLine(arr[i]);
            // }

            // // Imagina um cenário onde essa mensagem de erro é apresentada para um cliente.
            // // Esse cliente vai ficar extremamente confuso, pois (caso não seja da área) não sabe do que se trata
            // // Para isso, nós iremos trabalhar agr com os Exceptions, que são funções que captam esse erro...
            // // e retornam algo legivel para o cliente, ou mesmo realizar alguma ação 
            // // Sem falar que quando se é apresentado um unhandled exception, o programa para e o usuário deve reiniciar a aplicação, sistema, etc

            // === TRY/CATCH ===

            // // Agora iremos testar o tratamento de exceção na prática. É assim que funciona o seu escopo

            // // Basicamente você vai botar o código dentro do try, e caso de um erro de exceção, ele vai rodar o catch, apresentando o que você deseja
            // // Lembrando que não é bom botar todo o seu código dentro de um try, é muito mais saudavel dividir ele por blocos de código

            // var arr = new int[3];

            // try
            // {
            //     for (int i = 0; i < 10; i++)
            //     {
            //         Console.WriteLine(arr[i]);
            //     }
            // }

            // // No catch iremos capturar a exceção e realizar alguma ação com ela
            // // Podemos usar isso para criar um log ou outras n possibilidades
            // // É recomendando sempre capturar o exception e nunca ignorar ele, pois isso em projetos grandes pode virar uma grande bagunça
            // catch (Exception ex)
            // {
            //     Console.WriteLine(ex.Message);
            //     Console.WriteLine(ex.InnerException);
            //     Console.WriteLine("Ops, algo eu errado...");
            // }

            // === TRATANDO ERROS ===

            // var arr = new int[3];

            // try
            // {
            //     for (int i = 0; i < 10; i++)
            //     {
            //         Console.WriteLine(arr[i]);
            //     }
            // }

            // // Existem diversos tipos de erro, como vimos antes o erro que iremos ver nesse exemplo é o IndexOutOfRangeException
            // // Porém existem outros diversos que podem ser vistos na documentação do CSharp
            // // O interessante é que podemos ter diversos catchs e em cada um podemos capturar um tipo de erro especifico
            // // No catch abaixo estamos capturando um erro de indice. Ou seja, caso exista esse erro, ele vai ser satisfeito e entrar no escopo do catch
            // // E bem, como sabemos que o erro vai ser o de indice, ao ver que é isso mesmo, ele vai rodar apenas o catch abaixo, e ignorar os próximos
            // catch (IndexOutOfRangeException ex)
            // {
            //     Console.WriteLine(ex.Message);
            //     Console.WriteLine(ex.InnerException);
            //     Console.WriteLine("O indice não foi encontrado na lista.");
            // }

            // // Esse catch é um catch genérico, o Exception sendo passado nos parenteses é um tipo básico, que pode se adaptar a todo erro
            // // Porém, é mais interessante trabalhar com especificidades
            // // Sempre trate da exception mais especifica para a generica, pois caso nós trocassemos esse catch pelo catch de cima
            // // ele iria satisfazer a condição e não rodar mais o catch de baixo
            // catch (Exception ex)
            // {
            //     Console.WriteLine(ex.Message);
            //     Console.WriteLine(ex.InnerException);
            //     Console.WriteLine("Ops, algo eu errado...");
            // }

            // === DISPARANDO EXCEÇÔES ===

            // Agora iremos aprender como disparar exceções
            // Se liga na função que foi criada logo abaixo do escopo da main. E dps volta aqui


            // var arr = new int[3];

            // try
            // {
            //     // Comentei esse for, pois caso ele seja rodado, vai dar um erro, e já vai parar o programa
            //     // não chegando nem a rodar a nossa função Salvar abaixo
            //     // for (int i = 0; i < 10; i++)
            //     // {
            //     //     Console.WriteLine(arr[i]);
            //     // }

            //     Salvar("");
            // }

            // catch (IndexOutOfRangeException ex)
            // {
            //     Console.WriteLine(ex.Message);
            //     Console.WriteLine(ex.InnerException);
            //     Console.WriteLine("O indice não foi encontrado na lista.");
            // }

            // // Esse catch foi criado pois sem ele, a mensagem apresentada seria diferente do que esperariamos para esse tipo de erro            
            // catch (ArgumentNullException ex)
            // {
            //     Console.WriteLine(ex.Message);
            //     Console.WriteLine(ex.InnerException);
            //     Console.WriteLine("Falha ao cadastrar texto.");
            // }

            // // Podemos ver que tanto o erro que disparamos através da função, quanto essa exceção foi chamada
            // catch (Exception ex)
            // {
            //     Console.WriteLine(ex.Message);
            //     Console.WriteLine(ex.InnerException);
            //     Console.WriteLine("Ops, algo eu errado...");
            // }

            // === CUSTOM EXCEPTIONS ===

            try
            {
                Salvar("");
            }

            // Da mesma forma como fizemos com as outras, vamos criar um catch para capturar a excessão que criamos na classe abaixo
            // Se isso não for feito, ele vai cair no exception generico
            catch (MinhaException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.QuandoAconteceu);
                Console.WriteLine("Exceção customizada");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                Console.WriteLine("Ops, algo eu errado...");
            }

            // === FINALLY ===

            try
            {
                Salvar("aaaaaaaaaaaaaa");
            }

            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                Console.WriteLine("O indice não foi encontrado na lista.");
            }

            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                Console.WriteLine("Falha ao cadastrar texto.");
            }

            catch (MinhaException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.QuandoAconteceu);
                Console.WriteLine("Exceção customizada");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                Console.WriteLine("Ops, algo eu errado...");
            }

            // O Finally sempre vai rodar, independende de ter erro ou não
            // Um ótimo cenário pro finally seria quando acontece um erro em algum arquivo. 
            // Sabemos que o programa para no erro, porém se algum arquivo estiver aberto, ele não vai ser fechado, pois o programa para no erro
            // Usando o finally, você poderia garantir que esse arquivo seria fechado de qualquer forma
            // Também pode ser usado para fechar conexão com o banco de dados caso o arquivo dê erro e não feche, e por ai vai
            finally
            {
                Console.WriteLine("Finalizando!");
            }
        }

        // === DISPARANDO EXCEÇÔES ===
        // Essa função criou uma nova exceção que vai ser disparada dentro do contexto criado
        // Ou seja, se o texto for nulo ou vazio, ele vai jogar essa exceção pra gente
        // Agora vamos voltar para dentro do escopo da main para testar
        // private static void Salvar(string texto)
        // {
        //     if (string.IsNullOrEmpty(texto))
        //         // Se lembra que eu falei acima que o exception é o tipo mais genérico...
        //         // Pois é. Sempre procure ser o mais especifico possivel, como na linha abaixo desse outro texto de código comentado
        //         //throw new Exception("O texto não pode ser nulo ou vazio");

        //         // O ArgumentNullException faz muito mais sentido nesse contexto do quê o Exception generico
        //         throw new ArgumentNullException("O texto não pode ser nulo ou vazio");
        // }

        // === CUSTOM EXCEPTIONS ===

        private static void Salvar(string texto)
        {
            if (string.IsNullOrEmpty(texto))

                // Aqui, ao invés de chamarmos a exceção do sistema, chamamos a exceção que foi criada por nós na classe abaixo
                throw new MinhaException(DateTime.Now);
        }

        // Bem, isso aqui é uma herança, mas n iremos entrar nessa discussão agora, pois é algo para se ver a frente em OO
        // Aqui estamos criando uma custom exception
        public class MinhaException : Exception
        {
            // Como eu disse, não vale a pena explicar isso aqui agora, pois é conteúdo de OO (Orientação a Objeto)
            // isso aqui abaixo é um construtor que toda classe precisa para setar seus parametros
            public MinhaException(DateTime date)
            {
                QuandoAconteceu = date;
            }

            public DateTime QuandoAconteceu { get; set; }
        }

    }
}
