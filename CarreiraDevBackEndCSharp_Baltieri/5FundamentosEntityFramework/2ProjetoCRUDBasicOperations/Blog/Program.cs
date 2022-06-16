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
            // CRUD
            using (var context = new BlogDataContext())
            {
                // // CREATE
                // var tag = new Tag { Name = "ASP.NET", Slug = "aspnet" };
                // context.Tags.Add(tag);
                // // Se você não chamar o save changes, o Data Context vai apenas salvar a tag na memória
                // // Já com o context.SaveChanges() sendo chamado, ele vai salvar no banco
                // // Esse é o grande diferencial do EF, pois você vai trabalhar tudo em memória, e depois chamar o save changes
                // // E tudo o que tiver sido alterado no DataContext em memoria, ao chamar um save changes ele vai salvar tudo no banco
                // // Supondo que você adicionou 5 Users, atualizou 7 Tags, fez 10 relações, ao final, ele vai fazer tudo duma lapada com o save changes, sem precisar estar sempre indo no banco
                // context.SaveChanges();

                // // UPDATE
                // // Sempre que vc quiser atualizar alguma informação usando EF, não crie um objeto novo com new
                // // Ao invés disso você deve ler ela diretamente do banco. Se usar o new, vai dar erro
                // // Se você já tem essa informação do banco, você deve fazer um processo chamado Rehidratação, que basicamente é ler um item do banco novamente
                // var tag = context.Tags.FirstOrDefault(x => x.Id == 5);

                // // Depois de ter feito a rehidratação, agora você é capaz de alterar o objeto
                // tag.Name = "Unity";
                // tag.Slug = "unity";

                // // Atualizando a tag e salvando as mudanças
                // context.Update(tag);
                // context.SaveChanges();

                // // DELETE
                // // Quase a mesma coisa do Update. Você vai fazer uma rehidratação, pra pegar o item do banco e dps chamar um remove
                // var tag = context.Tags.FirstOrDefault(x => x.Id == 5);
                // context.Remove(tag);
                // context.SaveChanges();

                // READ
                // Se você não botar o ToList() sempre ao fim da "query", ele não vai executar a Query de select, como no caso 1
                // Sem o ToList() ele vai ser apenas uma referência, e em alguns casos você pode precisar apenas dessa referência
                // Já botando ela ao fim, você está forçando ela a dar um select. Ele vai executar o select ali naquela linha
                // Ou seja, a variavel tags vai receber todas as tags existentes no banco
                // Você pode testar tirar o ToList(), e executar o foreach, que mesmo assim ele vai rodar, como visto no caso 2
                // O Select vai acontecer ali quando ele passar em tags dentro do foreach 
                // E claro que a gente pode usar o mesmo exemplo do update e do delete pra pegar algo especifico do banco               

                // Caso 1
                // var tags = context.Tags.ToList();

                // foreach (var tag in tags)
                // {
                //     Console.WriteLine(tag.Name);
                // }

                // Caso 2
                // var tags = context.Tags;

                // foreach (var tag in tags)
                // {
                //     Console.WriteLine(tag.Name);
                // }

                // Caso 3
                // Em alguns cenários você pode precisar incluir filtros dinamicos
                // Um caso, seria achar todas as tags que possuem o nome teste ou que contem o nome teste em seu escopo
                // Nesse cenario abaixo o que iria acontecer? Primeiro ele chegaria no contexto, depois nas tags, e logo depois...
                // executaria um select em todas as tags do banco e depois filtraria isso em memória
                // Porém existe um tremendo problema ai. Se você está trabalhando com lista, lista sempre será o ultimo item
                // Do jeito que o código está ai, em um cenário onde existem 1 milhão de tags, ele iria primeiro carregar 1 milhão...
                // de tags e só depois realizaria o filtro, e com isso, provavelmente o seu banco iria travar ou sua aplicação

                // var tags = context
                //     .Tags
                //     .ToList()
                //     .Where(x => x.Name == "teste");

                // foreach (var tag in tags)
                // {
                //     Console.WriteLine(tag.Name);
                // }

                // O cenário correto é sempre deixar o ToList() por ultimo, pois assim, ele primeiro vai montar uma query com o filtro..
                // e só no final, quando chegar no ToList, ele vai executar a query, fazendo com que voc~e tenha um ganho de performance tremendo

                // var tags = context
                //     .Tags
                //     .Where(x => x.Name == "teste")
                //     .ToList();

                // foreach (var tag in tags)
                // {
                //     Console.WriteLine(tag.Name);
                // }

                // METADADOS, TRACK, ASNOTRACK
                // Quanto a gente da um context.Tags (ou qualquer outro context.Propriedade), o EF trás pra gente um item chamado de metadados
                // Que são informações adicionais a propriedade, no nosso caso, a tabela, e no caso que estamos trabalhando, ao tag
                // Essas informações são informações de estado. Quando você chama o context.Tag, ele vai trazer um metadado com as informações do estado atual...
                // assim como também, trás dados sobre as mudanças que aconteceu, mostrando o estado antigo e o estado novo
                // Porém, se eu não vou atualizar ou remover algo, eu posso simplesmente falar pro EF não trazer metadados
                // Não faz sentido existi metadados de estado em um create sendo que aquela coisa ainda nem existe
                // Assim como também não faz sentido ter metadados em um read, pois ali você vai está só lendo algo e não alterando ou removendo
                // E claro que ao fazer isso, ao dizer pro EF para não se trazer os metadados, teremos um ganho de performance absurdo
                // E para fazer isso usamos o AsNoTracking() logo depois de da propriedade/tabela que iremos trabalhar no context

                // var tags = context
                //     .Tags
                //     .AsNoTracking() // Desabilita os metadados
                //     .ToList(); // Executa a query

                // foreach (var tag in tags)
                // {
                //     Console.WriteLine(tag.Name);
                // }

                // Se vc for fazer um Update ou Delete, não use o AsNoTracking() como feito abaixo
                // Se você coloca o AsNoTracking, ele vai entender que esse objeto que você está trabalhando é novo
                // E em casos onde você tem chaves compostas ou tabelas mais complexas, um erro vai acontecer
                // var tag = context.Tags.AsNoTracking().FirstOrDefault(x => x.Id == 6);
                // tag.Name = "Unity";
                // tag.Slug = "unity";
                // context.Update(tag);
                // context.SaveChanges();

                // FIRST e SINGLE
                // Da mesma forma do ToList(), o  FirstOrDefault() também executa uma query. Basicamente a maioria das funções de lista executam a query
                // Para mais duvidas da uma olhada na documentação do EF
                // Lembrando tbm que o FirstOrDefault() trás algo, mas se esse algo não existir ele retorna como nulo
                // Porém, para ele retornar o nulo, você precisa passar o null safe (?) no objeto como visto no console
                // Se você botar apenas o First, ele vai retornar o objeto da lista, mas caso não exista, vai dar um erro
                // Também temos o Single e o SingleOrDefault
                // A diferença do Single e o SingleOrDefault pro Firs e FirstOrDefault, é que caso exista mais de uma tag com o id6...
                // Ele vai dar erro, pois espera que exista apenas uma tag com aquela id
                // Já o First ou FirstOrDefault vai retornar a primeira tag que achar com aquela id, independente do numero de tags que existam no banco(ou memoria)
                var tag = context.Tags.AsNoTracking().FirstOrDefault(x => x.Id == 6);
                var tag2 = context.Tags.AsNoTracking().First(x => x.Id == 6);
                var tag3 = context.Tags.AsNoTracking().Single(x => x.Id == 6);
                Console.WriteLine(tag?.Name);

            }
        }
    }
}
