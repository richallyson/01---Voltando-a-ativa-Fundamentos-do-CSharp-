using System;
using System.Linq;
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            // // Trabalhando com ORM (Object Relational Mapping) ou seja, trabalhando com Mapeamento

            using var context = new BlogDataContext();

            // var user = new User
            // {
            //     Name = "Monkey D. Luffy",
            //     Email = "luffy@onepiece.jp",
            //     PasswordHash = "123456789",
            //     Bio = "Eu serei o Rei dos Piradas!",
            //     Image = "https://",
            //     Slug = "monkey-d-luffy"
            // };

            // var category = new Category
            // {
            //     Name = "Kaizoku",
            //     Slug = "kaizoku"
            // };

            // // A MAGIA COMEÇA AQUI - Trabalhando com subconjuntos

            // // Percebeu alguma diferença desse objeto criado aqui pro da nossa aula de Dapper?
            // // Na aula de Dapper, nós passavamos o CategoryId e o AuthorId
            // // Aqui fizemos uma abordagem diferente, usando justamente a PROPRIEDADE DE NAVEGAÇÃO
            // // E na Category, referenciamos a categoria criada acima, e no Author, referenciamos o usuário criado acima
            // // Seria impossivel fazer isso se fosse o CategoryId ou o AuthorId, pois ambos são propriedades do tipo int
            // // Já nesse caso, temos a PROPRIEDADE DE NAVEGAÇÃO ligada diretamente a suas chaves estrangeiras
            // // Mas você percebeu que tanto na Categoria quanto no Autor nós não estamos instanciando uma Id?
            // // Bem, esses dois objetos acimas não se encontram no banco de dados, nenhum dos dois foi criado ainda!
            // // E é aqui que a magia acontece. Mesmo referenciando dois objetos que ainda nem existem, o EF é inteligente o suficiente...
            // // para gerenciar tudo isso pra gente.
            // // E bem, na hora de inserir o nosso Post, ele vai ver que ele possui uma dependência, que é justamente a falta de uma Categoria e de um usuário
            // // Sendo assim, ele primeiro vai inserir a categoria que criamos e passamos para ele como atributo, e também o usuário
            // // Depois vai pegar os ids que foram recem criados, como se fosse um SCOPE_IDENTITY do sql
            // // E só assim, vai criar o nosso post, pois já resolveu suas dependências. Ou seja, ele já vai ter as infos dos ids de cada objeto
            // // E tudo isso ele vai fazer de uma forma transacionada, como se fosse um TRANSACTION do sql 
            // // Caso você queira gerênciar essa transação, basta chamar o context.Transaction()
            // var post = new Post
            // {
            //     Category = category,
            //     Author = user,
            //     Title = "Como se tornar o Rei dos Piratas",
            //     Summary = "Bem, primeiro você deve...",
            //     Body = "Para se tornar o rei vc deve...",
            //     Slug = "como-se-tornar-o-rei",
            //     CreateDate = DateTime.Now,
            //     LastUpdateDate = DateTime.Now
            // };

            // // E o melhor de tudo é que você insere o post direto, sem precisar tem que inserir a categoria em Categories e o user em Users
            // context.Posts.Add(post);

            // // E o mais massa de tudo é que tudo isso é feito apenas com um hit. Não é preciso ele ir diversas vezes no banco pra inseir...
            // // primeiro a categoria, depois o usuário e só dps o post. Não, aqui vai tudo de uma vez
            // context.SaveChanges();

            // INCLUDE
            // Agora vamos listar os nossos posts de uma forma mais diferenciada e legal
            // A forma como criamos a nossa query através das funções do EF, deve seguir a mesma logistica e ordem que as funções de SQL
            // No nosso caso aqui, o Order sempre vem ao final, enquanto o Where vem antes dele, e dai por diante
            // O que iremos aprender aqui é uma forma de filtrar algo por alguma coisa determinada
            // No nosso contexto, vamos supor que eu gostaria de trazer os posts apenas de um certo autor.
            // Para isso eu iria precisar de seu Id, sendo assim, fica muito mais fácil você pegar esse autor diretamente pelo seu Id
            // E nesse caso usariamos o AuthorId da Classe Post, como mostrado abaixo no .Where(x => x.AuthorId == 1)
            // Caso você precisa usar o x.Author.Id, você deve primeiro dar um select nesse autor, através de um inner join
            // Apenas dessa forma você vai conseguir trazer a informação dele
            // Pois apesar do Author ser uma propriedade de navegação do Post, ele não se refere especificamente ao autor da Tabela autor
            // Já usando o AuthorId, você está referenciando diretamente a propriedade que é do Post, sendo assim, não precisa trazer ngm, não precisa fazer um inner join
            // Sendo assim você vai ter um ótimo ganho de performance, pois você vai estar deixando de fazer um join
            // Essa função/query abaixo iria retornar todos os posts de um certo autor
            // Mas caso você queira usar outra informação que não seja o Id, você vai ter que usar um join, pois apenas o Id possui referência em post
            // Por exemplo: .Where(x => x.Author.Slug == "algo") nesse contexto a classe Post não possui a propriedade Slug de Autor, sendo assim, se faz necessário um join
            // Para o nosso caso não iremos trabalhar com a função de baixo, serve apenas como amostra
            // var posts = context
            //     .Posts
            //     .AsNoTracking() // Como é apenas uma leitura, bote o AsNoTracking, não iremos persistir isso no banco em momento algum
            //     .Where(x => x.AuthorId == 1)
            //     .OrderByDescending(x => x.LastUpdateDate)
            //     .ToList(); // Se lembra né? ToList() sempre ao final, pois ela é uma função responsável por realizar a query

            // foreach (var post in posts)
            // {

            //     Console.WriteLine($"{post.Title} escrito por {post.Author?.Id}");
            // }

            // Iremos trabalhar com essa função, e mostrar como se faz um Join em autor para trazer ele
            // E para isso iremos usar o .Include(x => x.Author)
            // Ele vem sempre antes do Where, pois é como se fosse o Inner Join ou outros Joins
            // Então, quando eu boto o .Include(x => x.Author), ele vai fazer uma query de inner join para mim, sendo assim, trazendo o Autor pra gente
            // É por isso que as notações são tão importantes. Isso só vai ser possivel se você ligar o AuthorId como uma chave estrangeira, e criar a PROPRIEDADE DE NAVEGAÇÃO dessa Tabela que você deseja trazer
            // E no nosso caso, ele vai trazer todos os posts de todos os autores

            // var posts = context
            //     .Posts
            //     .AsNoTracking() // Como é apenas uma leitura, bote o AsNoTracking, não iremos persistir isso no banco em momento algum
            //     .Include(x => x.Author)
            //     .OrderByDescending(x => x.LastUpdateDate)
            //     .ToList(); // Se lembra né? ToList() sempre ao final, pois ela é uma função responsável por realizar a query

            // foreach (var post in posts)
            // {
            //     // Se você está lendo um subconjunto da sua entidade, use sempre o null safe (?) na tabela que você deseja trazer, pois ele pode vir nulo.
            //     // Sem isso, caso você não tenha feito o join, vai dar um erro. Com o null type, vai passar, porém não vai imprimir essa tabela que você pediu
            //     // O null safe basicamente vai fazer um if pra gente. Se o Autor existir exiba seu nome, se não existir não exibe nada
            //     // O EF não preenche de forma automatica as coisas para gente. Ele espera que você diga algo para algo acontecer
            //     // No nosso caso desse WriteLine abaixo, ele vai esperar que você dê um inner join para trazer o Autor para você
            //     Console.WriteLine($"{post.Title} escrito por {post.Author?.Name}");
            // }

            // // Pra testar o SQLPROVIDER, o Relatório/Log
            // var posts = context
            //     .Posts
            //     .AsNoTracking()
            //     .Include(x => x.Author)
            //     .Include(x => x.Category)
            //     // Uma diquinha nova. Imagina que a categoria tem uma tag, como eu faria para chamar a tag dessa categoria?
            //     // Basta usar o .ThenInclude() Ele vai pegar um item do filho
            //     // Como sabemos, quando fazemos funções dentro do corpo de uma função como o x=> x.Algo, esse x esta se referenciando ao pai
            //     // No caso do nosso segundo include, estamos fazendo um join para trazer o seu filho, o Category que é uma propriedade de navegação do Post
            //     // E nesse caso aqui, quando você bota o ThenInclude abaixo, o x vai representar esse filho que foi pego
            //     // Nesse nosso caso, a gente não criou a lista de Tags pra categoria, mas já fica explicado como funcionaria caso a gente precisasse
            //     // Porém, sempre que puder evitar o ThenInclude(), evite. Pois ele é um SUBSELECT, e como vimos na parte de SQL que ele não é muito performatico ou legal
            //     //.ThenInclude(x => x.Tags.Name)
            //     .OrderByDescending(x => x.LastUpdateDate)
            //     .ToList();

            // foreach (var post in posts)
            // {
            //     Console.WriteLine($"{post.Title} escrito por {post.Author?.Name} na categoria {post.Category.Name}");
            // }

            // ALTERANDO UM SUBCONJUNTO
            // Esse código aqui n precisa ser explicado, com tudo que foi mostrado acima, ele meio que já fica autoexplicativo
            // Eu basicamente to alterando o nosso autor através do post, e para isso eu devo trazer esses subconjuntos com o include

            var posts = context
                .Posts
                //.AsNoTracking() Precisamos do Tracking pois iremos persistir no banco, alterar algo
                .Include(x => x.Author)
                .Include(x => x.Category)
                .OrderByDescending(x => x.LastUpdateDate)
                .FirstOrDefault(); // Aqui eu vou pegar o primeiro item. Ele basicamente vai fazer um TOP 1

            posts.Author.Name = "Nika, The Sun God";
            context.Posts.Update(posts);
            context.SaveChanges();
        }
    }
}
