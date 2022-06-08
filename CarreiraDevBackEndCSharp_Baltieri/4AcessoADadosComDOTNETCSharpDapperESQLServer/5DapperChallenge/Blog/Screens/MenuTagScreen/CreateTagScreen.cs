using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuTagScreen
{
    public static class CreateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= CRIANDO UMA NOVA TAG = ");
            Console.WriteLine("=========================");
            Create();
            Console.WriteLine("=========================");
            Console.WriteLine("");
            Console.WriteLine("Aperter ENTER para voltar para o menu");
            Console.ReadLine();
            MenuTagScreen.Load();
        }

        private static void Create()
        {
            var repository = new Repository<Tag>();
            var tag = new Tag();
            Console.Write("Digite o nome da tag:");
            tag.Name = Console.ReadLine();
            Console.Write("Digite o slug da tag:");
            tag.Slug = Console.ReadLine();
            repository.Create(tag);

            Console.WriteLine("");
            Console.WriteLine($"Tag {tag.Name} adicionada com sucesso!");
        }
    }
}