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
        static void Main(string[] args)
        {
            // DICAS DE PERFORMANCE
            using var context = new BlogDataContext();

            // // EAGER LOADING e LAZY LOADING
            // // Desde que começamos a trabalhar com o EF, nós estamos usando o EAGER LOADING. Mas o que é isso?
            // // Bem, como a gente já ta utilizando isso, desde o começo mesmo sem saber, primeiro eu vou explicar o outro conceito, o LAZY LOADING
            // // Vale ressaltar que ambos são conceitos de performance do EF

            // // Lazy Loading
            // // Bem, agora vamos explicar o que acontece no cenário do Lazy Loading
            // // Primeiro, vá nos nossos modelos, na classe Post, e depois veja que alteramos a lista de tags para virtual, sendo assim fazendo com que ele possa ser sobrescrito depois (Ela está comentada)
            // // A partir do momento que você adiciona o virtual as tags, você está habilitando um carregamento preguiçoso no EF, um lazy loading
            // // Desse modo, quando a gente faz isso, quando criamos uma variavel: var posts = context.Posts; // Ele não vai trazer as tags pra gnt
            // // Porém, como sabemos, o EF já não trás outra tabela dentro de uma tabela por padrão, mas vamos supor que a gente queira iterar sobre as tags
            // // Então, iremos fazer da seguinte forma:

            // var posts = context.Posts;
            // foreach (var post in posts)
            // {
            //     foreach (var tag in post.Tags)
            //     {

            //     }
            // }

            // // Então, o que vai acontecer nesse cenário? A gente não mandou carregar as tags dentro da nossa query na var posts, porém, fizemos um foreach chamando elas
            // // Porém, como a gente botou o virtual na propriedade tag em post, ele vai conseguir carregar as tags aqui dentro
            // // E isso basicamente é um Lazy Loading. Ele carregou os posts, e apenas quando a gente precisar ele vai carregar as tags. Então, equanto você não chamar o post.Tags, ele não vai carregar as tags
            // // ISso funciona tanto para um quanto para muitos objetos, e ele só vai chamar essas tags quando houver um carregamento
            // // Mas pq o LAZY LOADING não é legal?
            // // Bem, quando a gente chama os posts, como fizemos na var posts, ele vai fazer um SELECT * FROM [Post], e não vai aplicar um inner join, para trazer junto consigo as tags
            // // O que significa que quando a gente chegar no segundo foreach, para chamar as tags, ele vai fazer outro SELECT, para buscar as tags
            // // Sendo assim, dentro da mesma conexão ele vai executar vários selects, que é algo que a gente já sabe que é menos otimizado, menos performatico
            // // Seria muito mais performatico realizar um select só, com o inner join, já trazendo as tags pra gente. E é ai que a gente volta pro...

            // // Eager Loading
            // // O Eager Loading é o modo padrão do EF, que é justamente como a gente sempre fez, sem criar propriedades usando o virtual
            // // Se a gente rodar o código acima usando o Eager Loading, sem o virtual na propriedade, ele vai dar erro, pois ele não vai conseguir carregar as tags pro padrão, ele não traz as tags por padrão
            // // Ou seja, quando chegasse no foreach que traz as tags, ele iria retornar null, justamente pq a gente não quer que elas sejam carregadas dessa forma
            // // No caso mais performático, usando o Eager, a gente faz como é feito abaixo, explicitando quando a gente quer carregar subitens ou não, dentro do nosso select
            // // Como vemos no código abaixo, essa é forma mais perfomática de se trazer um subitem quando se deseja
            // // Dessa forma ele já vai fazer o select pra gente com o inner join, trazendo todas as tags referente aos posts que alocamos pra variavel
            // // E lembrando que a gente sempre tem que botar o .ToList() para executar a nossa query, mas no nosso exemplo não vamos botar
            // // E essa é a diferença entre usar o Eager Loading e o Lazy Loading. Talvez em algum contexto você tenha que usar o Lazy, porém, já sabendo que ele vai ser menos performatico

            // var posts2 = context.Posts.Include(x => x.Tags);

            // // E uma outra dica de performance que o Balta da, é o uso do Select();
            // // Do qual, nesse caso, a gente vai chamar apenas os itens que a gente quer, e não trazer toda a lista de Posts
            // // Ou seja, sempre abuse das funções do EF para fazer logo a sua query de uma vez, sem ficar dividindo ela, quando for o caso, para que assim você tenha mais perfomance

            // var posts3 = context.Posts.Include(x => x.Tags).Select(x => new
            // {
            //     Id = x.Id == 1
            // });

            // // Agora vá para o Skip, Take e Paginação de dados, e depois volta aqui pra ver como a gente chama a função de páginação
            // // Depois de ter lido tudo sobre, a gente vai chamar a função e passar os valores de skip e take caso queira. Se não forem passados, ele vai usar os valores padrões que setamos no método
            // // E depois a gente vai criamdo o resto da páginação que a gente deseja, como foi explicado no texto abaixo que em seu começo tem um asterisco *
            // var posts4 = GetPosts(context, 0, 25);
            // var posts5 = GetPosts(context, 25, 25);
            // var posts6 = GetPosts(context, 50, 25);
            // var posts7 = GetPosts(context, 75, 25);

            // // THENINCLUDE
            // // Vamos supor que a gente queira saber o perfil desse autor que a gente deu um Include, a suas roles
            // // Para isso a gente usa o ThenInclude(), que a partir do momento que é usada, vai trazer os dados referentes ao que você chamou anteriormente, que no nosso caso, foi o Autor
            // // E depois disso pode continuar fazendo quantos Includes ou ThenIncludes vc quisesse
            // // Mas eai, o ThenInclude é performático pra gente? Vai nós trazer beneficios nos quesitos de performance??? 
            // // Não kk, pois por debaixo dos panos, ele vai executar um subselect, vai fazer um select dentro de um select, e como já vimos acima, usar diversos selects não é performático
            // // Principalmente em um cenário onde a gente tem muitos dados. Evite fazer isso se puder, pois em alguns cenários você vai ter que usar o ThenInclude() de qualquer forma
            // // Então, se em algum cenário você precisar muito usar ele, é recomendado que as vezes você faça uma Query manual e mapeei ela manualmente
            // // Dessa forma a gente vai melhorar a nossa performance. Ou seja, sempre pense muito antes de usar o ThenInclude, e sempre que for possivel, faça a query manual e mapeei ela manualemten
            // // Outra coisa sobre o ThenInclude, é que ele é infinito, você pode ir fazendo ThenIncludes e sempre ir trazendo dados sobre o que está acima
            // // Caso a gente queira, poderiamos fazer outro ThenInclude abaixo das Roles e pegar algum dado das roles, e assim sucessivamente
            // // Porém, da mesma forma, iriam ser feito mais subselects, sendo assim, pesando mais o nosso programa

            // var posts8 = context.Posts.Include(x => x.Author)
            //     .ThenInclude(x => x.Roles)
            // .Include(x => x.Category)
            // .ToList();

            // MAPEANDO QUERIES PURAS E VIEWS
            // E bem, como falamos acima no caso do ThenInclude, em cenários onde as coisas ficam muito complexas, seria melhor fazer a query manual e mapear ela manualmente
            // E é justamente sobre isso que a gente vai falar neste topico
            // Caso o que a gente queira fazer algo que fique muito complexo, no cenário onde a gente usa as expressões (x=> x), o famoso x função, você pode mapear uma query
            // Então, vamos supor que você queira trazer todos os posts somando as tags que tem em cada post, e você não está conseguindo fazer isso da forma tradicional que a gente faz (como nas funções acima)
            // Quando a gente fala de somar, fala especificamente do SUM, a função do SQL. E vamos supor que você está perdeido de como pode ser feito pelo EF (como eu estou agr kk)
            // O que você pode fazer? Escrever uma query no SQLServer que faça isso. Se liga que na pasta de Models tem um arquivo novo chamado PostWithTagsCount. Vai lá da uma olhada nele
            // Depois de ver a classe, fica a pergunta. O que a gente faz com ela? O que vamos fazer agr? A gente pode escreve uma query pra esse item
            // Recomendo fazer essa query no Azure Data, pois ele é feito pra isso, e já tem as sintaxes que facilitam a nossa vida na hr de escrever uma query
            // Mas antes de fazer essa query, vai no BlogDataContext, e adiciona o DbSet dela, e também ler o que tem lá pois é importante. Depois volta pra cá
            // E depois de ter ajeitado o DbSet, a gente faz a mesma coisa de como sempre fazemos, chamamos isso através de uma váriavel
            // E a partir desse momento, vamos ter todas as funções que a gente sempre usou pra fazer os nossos selects

            var posts9 = context.PostWithTagsCount.ToList();
            foreach (var post in posts9)
            {
                Console.WriteLine($"O post {post.Name} possui {post.Count} tags");
            }

        }

        // SKIP, TAKE E PÁGINAÇÃO DE DADOS
        // A maioria dos bancos de dados crescem de uma forma absurda. De forma rápida ele começa a ter muita informação
        // Imagine que você está trabalhando em um banco de dados que tem um milhão de posts. 
        // Agora imagine um cenário onde você da um select e tem como retorno esses um milhão de posts. O que aconteceria?
        // Bem, se você executar isso em produção, provavelmente vai travar o seu banco de produção, a sua aplicação, pois são muitas informações sendo lidas de uma vez
        // E isso acontece pois ele está carregando TODOS esses itens na memória
        // E bem, o que a gente pode fazer para evitar isso? A gente cria mais dois parametros no método chamados de SKIP E TAKE
        // Em alguns casos a gente faz o uso dos Optional Parameters, que basicamente é quando você já seta o valor do parametro dentro da construção do método
        // Skip significa pular e Take, significa pegar. E essa adição desses parametros vai fazer pra gente a Paginação dos nossos resultados pra gente, dentro do EF
        // *A gente usa o Skip e o Take para pular e pegar resultado. No caso da função abaixo, vai funcionar assim: pula 0 e pega 25, depois, pula 25 e pega 25, pula 50 e pega 25, pula 75 e pega 25, e assim por diante
        // E dessa forma a gente evita que o nosso programa trave, evita de trazer um milhão de informações ao mesmo tempo. Através da Páginação de dados
        // E claro que esse valor escolhido pro Take, não precisa ser especificamente 25, até 1000 é um tamanho bom de informações para se trazer. Porém o 25 é um numero plenamente saudavel
        // E com os parametros skip e take colocados, a gente passa eles como atributo para as funções Skip() e Take() na hora da gente fazer a nossa Query


        public static List<Post> GetPosts(BlogDataContext context, int skip = 0, int take = 25)
        {
            var posts = context.Posts.AsNoTracking().Skip(skip).Take(take).ToList();
            return posts;
        }
    }
}
