using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DataAcessDapper.Models;
using Microsoft.Data.SqlClient;

namespace DataAcessDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433; Database=balta;User ID=sa;Password=1q2w3e4r@#$";

            using (var connection = new SqlConnection(connectionString))
            {
                // UpdateCategory(connection);                
                // CreateCategory(connection);
                // CreateManyCategories(connection);
                // DeleteManyCategories(connection, "2398a209-7a8a-4805-aea7-c6f4a8db6196", "dd0d0723-02cd-4c67-987d-b6fdf9f3456b");
                // UpdateManyCategories(connection, "ad914c09-b965-43fd-9b5d-a7f5c22e7dfe", "25d510c8-3108-44c2-86c5-924d9832aa8c");
                // ListCategories(connection);
                // GetCategory(connection, "25d510c8-3108-44c2-86c5-924d9832aa8c");
                // ExecuteProcedure(connection);
                // ExecuteReadProcedure(connection);
                // ExecuteScalar(connection);
                // ReadView(connection);
                // OneToOne(connection);
                // OneToMany(connection);
                // QueryMultiple(connection);
                // SelectIn(connection);
                // Like(connection, "api");
                Transaction(connection);
            }
        }

        static void ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");

            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }

        static void GetCategory(SqlConnection connection, string id)
        {
            var getCategorySql = connection.Query<Category>(@"SELECT [Id], [Title] FROM [Category] WHERE [Id] = @Id", new
            {
                Id = id
            });
            foreach (var item in getCategorySql)
            {
                if (id == item.Id.ToString())
                {
                    Console.WriteLine($"{item.Id} - {item.Title}");
                }
            }
        }

        static void CreateCategory(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = @"Acesso à dados com .NET, C#, Dapper e SQL Server";
            category.Url = "acesso-a-dados-com-dotnet-csharp-dapper-e-sqlserver";
            category.Summary = "Dapper para SQL Server";
            category.Order = 8;
            category.Description = "Categoria destinada ao uso de Dapper para SQL Server";
            category.Featured = false;

            var insertSql = @"INSERT INTO
                    [Category] 
                VALUES(
                    @Id, 
                    @Title, 
                    @Url, 
                    @Summary, 
                    @Order, 
                    @Description, 
                    @Featured)";

            var rows = connection.Execute(insertSql, new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });

            Console.WriteLine($"{rows} - Linhas inseridas");
        }

        static void UpdateCategory(SqlConnection connection)
        {
            var updateQuery = "UPDATE [Category] SET [Title] = @Title WHERE [Id] = @Id";

            var rows = connection.Execute(updateQuery, new
            {
                Id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
                Title = "Frontend 2022"
            });

            Console.WriteLine($"{rows} - Registros atualizados");
        }

        static void DeleteCategory(SqlConnection connection, string id)
        {
            var deleteCategorySql = @"DELETE FROM [Category] WHERE [Id] = @Id";
            connection.Execute(deleteCategorySql, new
            {
                Id = id
            });

            Console.Write($"{deleteCategorySql} - Categoria foi excluida");
        }

        // O ExecuteMany vai realizar diversas ações, no nosso caso abaixo, vamos adicionar diversas categorias de uma vez
        static void CreateManyCategories(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = @"Acesso à dados com .NET, C#, Dapper e SQL Server";
            category.Url = "acesso-a-dados-com-dotnet-csharp-dapper-e-sqlserver";
            category.Summary = "Dapper para SQL Server";
            category.Order = 8;
            category.Description = "Categoria destinada ao uso de Dapper para SQL Server";
            category.Featured = false;

            var category2 = new Category();
            category2.Id = Guid.NewGuid();
            category2.Title = @"Amazon AWS";
            category2.Url = "amazon";
            category2.Summary = "Categoria destinada a serviços AWS";
            category2.Order = 9;
            category2.Description = "AWS Cloud";
            category2.Featured = true;

            // O insert permanece o mesmo
            var insertSql = @"INSERT INTO
                    [Category] 
                VALUES(
                    @Id, 
                    @Title, 
                    @Url, 
                    @Summary, 
                    @Order, 
                    @Description, 
                    @Featured)";

            // E no Execute, ao invés de criar apenas um objeto, iremos criar uma array de objetos, passando o que a gente quer
            // Ou seja, iremos passar um array de itens, e o Dapper é inteligente o suficiente a ponto de fazer essa inserção para a gente
            var rows = connection.Execute(insertSql, new[]{
                new
                {
                    category.Id,
                    category.Title,
                    category.Url,
                    category.Summary,
                    category.Order,
                    category.Description,
                    category.Featured
                },
                new
                {
                    category2.Id,
                    category2.Title,
                    category2.Url,
                    category2.Summary,
                    category2.Order,
                    category2.Description,
                    category2.Featured
                }
            });

            Console.WriteLine($"{rows} - Linhas inseridas");
        }

        static void DeleteManyCategories(SqlConnection connection, string id1, string id2)
        {
            var deleteCategoriesSql = @"DELETE FROM [Category] WHERE [Id] = @Id";
            var rows = connection.Execute(deleteCategoriesSql, new[]
            {
                new{Id = id1},
                new{Id = id2}
            });

            Console.WriteLine($"{rows} - Categorias foram excluida");
        }

        static void UpdateManyCategories(SqlConnection connection, string id1, string id2)
        {
            var updateQuery = "UPDATE [Category] SET [Title] = @Title WHERE [Id] = @Id";

            var rows = connection.Execute(updateQuery, new[]{
                new {Id = id1, Title = "Amazon AWS 2022"},
                new {Id = id2, Title = "Fullstack 2022"}
            });

            Console.WriteLine($"{rows} - Registros atualizados");
        }

        // Executando Stored Procedure
        static void ExecuteProcedure(SqlConnection connection)
        {
            // Para ficar mais coerente, sempre use os mesmos parametros criados no banco
            // No banco foi criada uma procedure que espera como parametro exatamente um @StudentId
            // Quando se coloca o CommandType visto na varievel rows, você não precisa declarar o comando como na variavel sql abaixo que foi comentada
            //var sql = "EXEC [spDeleteStudent] @StudentId";
            // Ao invés disso, pode apenas chamar o nome da procedure, sem botar o EXEC, e sem passar o paremetro. O parametro ele já vai mapear automaticamente
            var procedure = "[spDeleteStudent]";
            // Caso tivesse mais parametros, era só colocar após separando com uma virgula
            var pars = new { StudentId = "1e5bf176-36b2-4240-970c-4f5613f85056" };
            // Na Stored Procedure, você deve definir o command type como parametro quando for dar o execute, como fizemos no ADO.NET
            var rows = connection.Execute(procedure, pars, commandType: CommandType.StoredProcedure);

            if (rows <= 1)
            {
                Console.WriteLine($"{rows} - Linha afetada");
            }
            else
                Console.WriteLine($"{rows} - Linhas afetadas");

        }

        // Lendo uma Stored Procedure
        static void ExecuteReadProcedure(SqlConnection connection)
        {
            // É o mesmo processo do Execute, só que ao invés disso, usar um query
            var procedure = "[spGetCoursesByCategory]";
            var pars = new { CategoryId = "09ce0b7b-cfca-497b-92c0-3290ad9d5142" };
            var courses = connection.Query(procedure, pars, commandType: CommandType.StoredProcedure);

            // Lembrando que no ListCategories, a gente passou o tipo pro Query, que era um Category, que foi a classe criada em Models
            // Nesse caso aqui iremos usar mesmo o Query como um dynamic, que é o seu tipo básico
            // Mas muito cuidado, na hora de digitar as coisas que você quer imprimir, lembrar de sempre escrever as propriedades do curso como está no banco de dados
            // Não temos as propriedades de curso em tempo de compilação, apenas em tempo de execução. Ou seja, essa é uma tipagem anomina
            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Title}");
            }

        }

        // O Execute Scalar permite que a gente execute algo e retorne um valor diferente de um int
        // Como vemos acima, temos um retorno de um inteiro mostrando quantas linhas foram afetadas pelas execuções
        // No nosso caso, a gente vai inserir um item no banco, e ter o retorno do Id do item gerado
        // Você pode ter qualquer coisa como retorno, contanto que exista dentro da tabela
        // Em vários cenários onde a gente usa um int ao invés do guid, a gente não tem controle da geração desse id
        // Ou em um cenário onde você deseja gerar o id direto do sqlserver
        // Ou mesmo em um cenário onde você vai pegar o ultimo id gerado, onde existe uma concorrência de pessoas inserindo dados no banco, você pode acabar pegando o id de outro item que não era o que você desejava
        // E como a gente precisa saber qual id que foi gerado, do qual é um id gerado no banco, a gente usa o ExecuteScalar nesse cenário

        static void ExecuteScalar(SqlConnection connection)
        {
            // Ao invés de passar o Id direto na categoria, vou passar no insert usando um NEWID()
            var category = new Category();
            category.Title = @"Acesso à dados com .NET, C#, Dapper e SQL Server";
            category.Url = "acesso-a-dados-com-dotnet-csharp-dapper-e-sqlserver";
            category.Summary = "Dapper para SQL Server";
            category.Order = 8;
            category.Description = "Categoria destinada ao uso de Dapper para SQL Server";
            category.Featured = false;

            // O OUTPUT inserted. [propriedade] retorna pra gente a saída da categoria inserida. Basicamente vai servir como um "SELECT" pra gente
            var insertSql = @"
                INSERT INTO
                    [Category] 
                OUTPUT inserted. [Id]
                VALUES(
                    NEWID(), 
                    @Title, 
                    @Url, 
                    @Summary, 
                    @Order, 
                    @Description, 
                    @Featured)";

            // É necessário tipar o ExecuteScalar com o retorno que a gente deseja
            var id = connection.ExecuteScalar<Guid>(insertSql, new
            {
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });

            Console.WriteLine($"O ID do item inserido é: {id}");
        }

        // Executando uma View, que é básicamente um select nesse contexto, então á quase a mesma coisa que a função ListCategories, criada acima
        static void ReadView(SqlConnection connection)
        {
            var sql = "SELECT * FROM [vwCourses]";
            // Vamo deixar a query anonima, como a gente fez no ReadProcedure, então cuidado quando for chamar os campos
            var courses = connection.Query(sql);

            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }

        // MAPEAMENTO
        // A partir daqui iremos entrar em alguns conteúdos mais avançados, especificamente o Mapeamento ou Mapping

        // Primeiro iremos começar com o relacionamento um para um. Lembra do INNER JOIN? Pois é. Vamos usar aqui
        // É necessário criar os modelos que serão usados aqui. Podemos até fazer de forma anomima, porém isso pode ficar confuso pro Dapper, e futuramente ocasionar muitos erros
        static void OneToOne(SqlConnection connection)
        {
            // No mundo real a gente n usa o asterisco no SELECT kkkkk ELe ta aparecendo aqui só pra exemplo mesmo
            var sql = @"SELECT * FROM [CareerItem] INNER JOIN [Course] ON [CareerItem].[CourseId] = [Course].[Id]";

            // Aqui iremos aprender a popular um objeto dentro do outro em uma Query. Se você for em Models, verá que o CareerItem tem um Curso como propriedade
            // E como fazemos isso? Como na nossa query iremos fazer para povoar um objeto que está dentro de outro?
            // Se colocarmos a query apenas como um tipo CareerItem, não poderemos chamar as própriedades de Course, pois a Query vai retorar apenas um CareerItem
            // Mesmo que dentro do CareerItem tenha um curso, você deve trazer também o Course como tipo da query
            // E para fazer isso, iremos segregar a query, colocar mais itens
            // Sendo assim, podemos dizer que temos um CareerItem, e também um Course. E que o resultado final da junção desses dois, está dentro de um CareerItem
            // Ou seja, primeiro você define os dois tipos de objetos que você quer retornar, e como ultimo argumento, você declara o objeto que contem os outros dois objetos anteriores. Do qual será o retorno final
            // Query(ObjetoPai, ObjetoFilho, ObjetoRetornado)
            var items = connection.Query<CareerItem, Course, CareerItem>(
                sql,
                // E dentro desse cenário, depois de passar a instrução SQL na query, devemos dizer pra ele qual função iremos usar (pois ele vai percorrer todos esses itens) para explicar como ele vai carregar um Course dentro de um CareerItem
                // Iremos criar uma lambda expression que o seu retorno é um objeto
                // Essa é a função que iremos utilizar paraexplicar como o CareerItem vai carregar um Course dentro dele
                // Caso isso lhe deixe confuso, sobre a forma dessa função, recomendo ir no Youtube e pesquisar sobre lambda expressions
                (careerItem, course) =>
                {
                    careerItem.Course = course;
                    return careerItem;
                    // E como passo final, devemos dizer onde um objeto se difere do outro, e isso faremos usndo o splitOn
                    // Se o Id se repetir, o nome do campo Id, é melhor você usar um ALIAS ou vai ser uma bagunça
                    // Lembrando que essa é a forma de se mapear um para um dentro do Dapper. Por detrás dos panos muita coisa acontece, e que não vem ao caso da gente saber aqui
                    // Não coloque o campo do split entre chaves. Diferente das querys ou execute do sql que eceitam as chaves, ele vai dar um erro
                }, splitOn: "Id");

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Title} - Curso: {item.Course.Title}");
            }
        }

        // Agora iremos mostrar como se faz um relacionamento um para muitos
        static void OneToMany(SqlConnection connection)
        {
            // Aqui não tem muito o que comentar, é apenas uma Quuery que retorna a carreira e os itens da carreira
            // Se você for em Modes/Career.cs, pode ver que no como atributo de Career, temos uma lista de CareerItems
            // E é justamente isso que iremos fazer, listar todos os itens de carreira presente no curso. Um para muitos
            var sql = @"
            SELECT 
                [Career].[Id],
                [Career].[Title],
                [CareerItem].[CareerId],
                [CareerItem].[Title] 
            FROM 
                [Career] INNER JOIN [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
            ORDER BY
                [Career].[Title]           
            ";

            // Foi necessário externalizar a lista que iremos imprimir futuramente
            // Pois caso isso não fosse feito, ele sempre iria criar uma carreira nova, com um item de carreira dentro dele
            // E não iria conseguir linkar uma carreira e diversos itens de carreira
            // Se dentro da função lambda do query fizessemos assim antes do retorno: career.CareerItems.Add(careerItems)...
            // Esse seria o cenário onde não conseguiriamos assemelhar uma carreira a diversos itens
            // Com essa lista de carreiras criada fora do items, podemos comparar sempre se o id do career do query é igual ao id do careers da nossa lista
            var careers = new List<Career>();
            // Esse passo é a mesma coisa do OneToOne. Query(ObjetoPai, ObjetoFilho, ObjetoRetornado)
            // O Dapper não é tão inteligente no quesito de se trabalhar com One To Many. Abaixo não existe muito o que explicar, se você chegou até aqui...
            // Passando por todos os códigos que eu disponibilizei, você vai entender bem o que está acontecendo
            // E claro, estudado xD
            var items = connection.Query<Career, CareerItem, Career>(
                sql,
                (career, careerItem) =>
                {
                    // Nesse código, basicamente iremos impedir que o nome da carreira se repita diversas vezes
                    // Se você der um query no banco de dados com o sql acima, vai ver que a cada vez que vc chama um item da carreira, o nome da carreira também é printado
                    // Ou seja, o nome da carreira vai se repetir diversas vezes, pois uma carreira possui diversos itens de carreira
                    // Sendo assim, nesse código, iremos ver se o car é nulo. E claro, que na sua primeira iteração ele será nulo, pois nada foi gerado, sendo assim ele vai cair no if
                    // Já na sua segunda iteração ele já não vai ser mais nulo, pois o car já tem uma carreira que foi guardada na lista criada logo acima
                    // Sendo assim ele vai entrar no else, e adicionar apenas o item de carreira. 
                    // E dai por diante. Esse processo vai se repetir, para cada carreira existente, para que assim, nossa query não fique poluida com muita informação desnecessária
                    var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();
                    if (car == null)
                    {
                        car = career;
                        car.CareerItems.Add(careerItem);
                        careers.Add(car);
                    }
                    else
                    {
                        car.CareerItems.Add(careerItem);
                    }
                    return career;
                }, splitOn: "CareerId");

            foreach (var career in careers)
            {
                Console.WriteLine($"{career.Title}");
                foreach (var item in career.CareerItems)
                {
                    Console.WriteLine($" - {item.Title}");
                }
            }
        }

        // Não existe relacionamento de muitos para muitos
        // Na relação do SQL Server a gente move as chaves estrangeiras para uma tabela associativa. São dois SELECTs. E é assim que funciona o muitos para muitos no SQL Serve
        // Não existe uma forma especifica como fizemos no um para um e no um para muitos

        // Vamos aprender a fazer um QueryMultiple, que é basicamente uma forma de você fazer diversas queries de uma vez
        // Imagina um cenário onde você tem um blog, que tem um post, e esse post tem uma categoria, e essa categoria tem muitos posts. Basicamente é nesse tipo de cenário que trabalhamos o muitos para muitos
        // O Dapper tem uma função chamada de MultiSelect, então podemos executar multiplos selects dentro de uma query só
        // E sim, dentro daqui você pode aplicar o OneToOne, OneToMany, qualquer query que você deseja realizar
        static void QueryMultiple(SqlConnection connection)
        {
            var query = @"SELECT * FROM [Category]; SELECT * FROM [Course]";
            using (var multi = connection.QueryMultiple(query))
            {
                var categories = multi.Read<Category>();
                var courses = multi.Read<Course>();

                foreach (var item in categories)
                {
                    Console.WriteLine(item.Title);
                }

                foreach (var item in courses)
                {
                    Console.WriteLine(item.Title);
                }
            }
        }

        // O Select in basicamente é como se fosse uma forma de retornar apenas as coisas que você passa pro parametro no IN
        static void SelectIn(SqlConnection connection)
        {
            var query = "SELECT * FROM [Career] WHERE [Id] IN @Id";
            var items = connection.Query<Career>(query, new
            {
                // Uma coisa interessante, é que quando botamos algo como array, significa que iremos executar aquele campo multiplas vezes
                // Se eu transformo o new acima em uma array, ele iria executar a query multiplas vezes
                // Mas como o new abaixo é que foi tipado como array, apenas esse campo vai ser executado mais de uma vez. Como se fosse um for percorrendo algo
                Id = new[]
                {
                    "01ae8a85-b4e8-4194-a0f1-1c6190af54cb",
                    "92d7e864-bea5-4812-80cc-c2f4e94db1af"
                }
            });

            foreach (var item in items)
            {
                Console.WriteLine(item.Title);
            }

        }

        // Lembra do LIKE que estudamos nos fundamentos de sql server? Aquele que você usa a porcentagem para exemplificar o que deseja?
        // É exatamente o que iremos fazer agora

        static void Like(SqlConnection connection, string term)
        {
            // Lembrando que algo dentro das porcentagens é contem, se você usa uma porcentagem a esquerda é começa com, e a direita, é tudo que termina com
            // Contém = %teste%; Começa com %teste; Termina com = teste%
            // A diferença é que aqui a gente não vai fazer isso direto no parametro
            // Nunca concatene dentro da query. Lembra do problema do SqlInjection? Psé, é um prato cheio para isso
            var query = "SELECT * FROM [Course] WHERE [Title] LIKE @exp";
            var items = connection.Query<Course>(query, new
            {
                exp = $"%{term}%"
            });

            foreach (var item in items)
            {
                Console.WriteLine(item.Title);
            }

        }

        // Trabalhando com Transactions
        // Lembra do Transaction? Aquele comando que começa com BEGIN TRANSACTION e finaliza ou com um ROLLBACK OU COMMIT?
        // É esse ai mesmo
        static void Transaction(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = @"Minha categoria que não quero salvar";
            category.Url = "i-dont-want-to-save-this";
            category.Summary = "Dont save!";
            category.Order = 10;
            category.Description = "Why are you trying to save this?";
            category.Featured = false;

            var insertSql = @"INSERT INTO
                    [Category] 
                VALUES(
                    @Id, 
                    @Title, 
                    @Url, 
                    @Summary, 
                    @Order, 
                    @Description, 
                    @Featured)";


            connection.Open();

            // Aqui é como se a gente tivesse botando o BEGIN TRANSACTION na começo do código
            using (var transaction = connection.BeginTransaction())
            {
                // Ao final do execute você tem que passar a transação
                var rows = connection.Execute(insertSql, new
                {
                    category.Id,
                    category.Title,
                    category.Url,
                    category.Summary,
                    category.Order,
                    category.Description,
                    category.Featured
                }, transaction);

                // Se fizer um Rollback, ele vai desfazer essa transação
                // E lembrando que o Rollback é sempre bom para se usar em um contexto de teste, onde você deseja saber se uma ação vai ser realizada
                // Apesar de ele não realizar a ação, ele vai retornar se houve alteração, mas ao fim vai chamar o rollback e desfazer essa alteração
                transaction.Rollback();
                // Se deixarmos o Commit, ele vai salvar as alterações da transação
                //transaction.Commit();

                // Se você não colocar nada, nem rollback nem commit, ele não vai colocar nada, vai funcionar como o rollback. Mas né, melhor colocar tudo descrito bonitinho pra evitar buchos

                Console.WriteLine($"{rows} - Linhas inseridas");

            }


        }
    }
}
