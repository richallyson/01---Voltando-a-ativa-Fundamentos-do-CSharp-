using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // DICAS DE PERFORMANCE
            using var context = new BlogDataContext();

            // TRACKING E ASNOTRAKING
            // Quanto mais queries sql a gente faz pelo EF, menos performatico vai ser o nosso programa
            // Por exemplo, quando a gente faz um update em algum campo usando o comando: UPDATE [Tabela] SET [Campo]  = VALOR WHERE [Id] = X
            // Sendo assim, quanto mais campos temos dentro desse comando, mais tempo se leva para a query ser executada
            // Agora imagina um cenário onde a gente precisa atualizar campos que estão dentro de conjuntos de valores
            // Como por exemplo, quando a gente criou um autor dentro de um post. Caso a gente quisesse alterar esse autor, não existiria a possibilidade de fazer um inner join no update
            // Sendo assim, o EF vai uma outra query de update nesse campo de outra tabela. E tudo isso impacta na nossa performance. Quanto mais queries, quanto mais campos, menos performance
            // E o nosso amigo EF, para otimizar essas situações, ele utiliza algo chamado de TRACKING
            // O TRACKING funciona da seguinte forma: toda vez que a gente lê um ou mais objetos do banco, ele traz consigo metadados (metadata) sobre essas leituras
            // E esses dados são informações a mais que o EF utiliza para fazer um Update, Insert ou Delete, de forma mais otimizada
            // Essas informações permite que o EF saiba quais campos foram alterados 
            // Vamos imaginar que criamos uma entidade que ela tem 200 campos, um tabelão, e a gente deseja alterar apenas um campo. Como o EF vai modelar essa query pra gente? Como ela iria fazer um update?
            // Com o Tracking ativado, o EF vai alterar pra gente apenas aquele campo que a gente deseja, sem ter que alterar os outros. Caso o Tracking esteja desativado, ele vai alterar toda a tabela
            // Pois com com o Tracking desativado, ele n vai possuir os metatados sobre aquela tabela, sendo assim, não sabe como estão no momento o estado daqueles campos
            // O Tracking é feito de forma automática, dentro de todas as queries de um CRUD, para desativar a gente utiliza o AsNoTracking como já vimos em modulos anteriores
            // E essa desativação é feita quando vamos fazer queries simples, como as de leitura, pois nesses casos a gente não deseja alterar dado algum, apenas apresentar eles
            // Sendo assim, quando for rolar alguma alteração de algo em uma tabela, o tracking tem que estar ativado para ter mais perfdormance.
            // Quando a gente vai fazer apenas leitura, não se precisa de fato trazer os metadados juntos dessa leitura, sendo assim, para que haja uma melhor performance, trabalhamos com o AsNoTracking

            var users = context.Users; // Com tracking
            var userQuery = context.Users.FirstOrDefault(x => x.Id == 1); // Query com tracking para caso deseje realizar alguma ação que vai mudar a tabela
            var users2 = context.Users.AsNoTracking(); // Sem tracking
            var usersQuery2 = context.Users.AsNoTracking().FirstOrDefault(x => x.Id == 1); // Query sem tracking para caso deseje apenas ler o dado

            // ASYNC E AWAIT - Necessário aprender bem pois vamos usar muito no próximo curso, que é o de ASP.NET
            // Tudo o que a gente fez até agora, desde o nosso curso de Fundamentos até esse presente curso de EF, foi feita de forma sincrona. Tudo é feito em um passo de cada vez
            // No código acima é tudo feito dessa forma. Onde primeiro abrimos uma conexão, e depois realizamos selects. Um é feito após o outro, como em uma fila
            // E bem, agora vamos explicar esse conceito de async e await.
            // E como exemplo para isso, iremos mudar a nossa função principal, transformando ela em uma tarefa. Antes a função main estava assim: static void Main(string[] args)
            // E agora ela vai ficar assim: static async Task Main(string[] args). Esse conceito de metodo Task não é algo próprio do EF, mas sim do dotnet
            // E bem, o que é uma Task? Como o nome diz, é uma tarefa, do qual permite que a gente executa as coisas em paralelo dentro do nosso método.
            // Se o seu método estiver como uma tarefa, outros métodos podem chamar ele, e aguardar a execução dele para realizar algo ou processar ele em paralelo
            // Mas para que de fato o metodo se torne assincrono (ou seja, rode de forma paralela), a gente precisa botar o ASYNC antes do Task
            // E a partir do momento que um metodo se torna assincrono, tudo o que tem dentro dele pode ser executado por partes
            // Como por exemplo: a maioria dos métodos contidos, pós a gente setar os DbSets, eles possuem um sufixo chamado de Async
            // A nossa variavel UserQuery (vista acima) antes nos retornava diretamente um User. Para ver isso, basta deixar o mouse acima do nome da variável
            // Mas a partir do momento que a gente coloca um Async, ele passa a retornar uma Tarefa de um User. Mas bem, o que isso significa?
            // Significa que o que vier abaixo dele, no nosso caso um Console.WriteLine, não vai esperar o metodo acima (que realizar uma busca no banco) ele ser exacutado para prosseguir com a execução do nosso método main
            // Porém, podemos perceber que temos funções dentro do nosso método, como a propria instanciação do DataContext, que não são assincronas. Elas por estarem dentro de uma task async não vão se tornar async também
            // Para isso é necessário definir que o que estiver dentro do método é assincrono.

            var userQueryAsync = context.Users.FirstOrDefaultAsync(x => x.Id == 1); // Metodo assincrono
            Console.WriteLine("Teste");

            // E qual a vantagem disso? Bem, vamos supor que a gente queira fazer diversas buscas no banco, onde a gente queira trazer todos os categories e posts
            // Usando o Async a gente vai fazer ambas as buscas em paralelo, sem que uma espere pela outra para ser realizada, e sem que o nosso programa pare apenas para realizar isso
            // A execução do método vai continuar enquanto em paralelo essas buscas são realizadas

            var post = context.Posts.ToListAsync();
            var category = context.Categories.ToListAsync();

            // Mas caso a gente precise aguardar alguma coisa para só então realizar algo? É ai que entra o AWAIT
            // Botando o sufixo AWAIT como visto abaixo, a gente diz pro nosso programa que se deve aguardar ser realizada aquela ação, para só então continuar a nossa execução
            // Mas isso não transformaria tudo novamente para algo sincrono? Não. Mesmo a gente dando o await nessas nossas duas buscas abaixo, elas vão ser feitas de forma paralela
            // E quando as duas forem realizadas, o programa continua. Isso traz um ótimo ganho de performance pra gente, pelo fato do paralelismo

            var post2 = await context.Posts.ToListAsync(); // Maneira mais comum de ser feita
            var category2 = await context.Categories.ToListAsync();

            // Outra forma de fazer a mesma coisa. Como as nossas buscas viraram tasks a partir do momento que usamos o Async dentro do método de procura, a gente pode fazer isso:

            var post3 = context.Posts.ToListAsync();
            post3.Wait(); // Pode passar algo dentro dessa função para caso queira realizar alguma configuração diferente

            // Retornando valores de uma função async (Feita na função abaixo)

            var getPost = await GetPosts(context);

            // Fim do conteúdo nessa parte, agora vá para Blog2


        }

        // E como que a gente faz pra retornar valores desses métodos async e await?
        // Bem, a Task permite que ela seja de um tipo, ou seja, ela é um tipo genérico.
        // Dentro da Task a gente passa o que deseja retornar depois que a tarefa for realizada
        // No nosso caso, desejamos retornar uma lista de Post. Da qual essa lista é um IEnumerable
        // Dentro da Task primeiro passamos o tipo da lista, e dentro do tipo da lista chamamos o post
        // Para facilitar a nossa vida, passamos um DataContext já como parametro
        // E na hora do retorno, botamos o await da mesma forma como fizemos acima nas nossas buscas, para que ele rode de forma assincrona junto com as outras coisas dentro de onde ele for chamado

        public static async Task<IEnumerable<Post>> GetPosts(BlogDataContext context)
        {
            return await context.Posts.ToListAsync();
        }
    }
}
