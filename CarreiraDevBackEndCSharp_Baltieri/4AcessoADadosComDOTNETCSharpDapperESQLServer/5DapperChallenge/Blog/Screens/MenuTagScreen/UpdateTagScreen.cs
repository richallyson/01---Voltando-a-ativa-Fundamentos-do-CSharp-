using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuTagScreen
{
    public static class UpdateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= ATUALIZANDO UMA TAG = ");
            Console.WriteLine("=========================");
            Update();
            Console.WriteLine("=========================");
            Console.WriteLine("");
            Console.WriteLine("Aperter ENTER para voltar para o menu");
            Console.ReadLine();
            MenuTagScreen.Load();
        }

        private static void Update()
        {
            var repository = new Repository<Tag>();
            var tag = new Tag();
            Console.Write("Digite a id da tag que deseja atualizar: ");
            tag.Id = int.Parse(Console.ReadLine());
            Console.Write("Digite o nome da tag: ");
            tag.Name = Console.ReadLine();
            Console.Write("Digite o slug da tag: ");
            tag.Slug = Console.ReadLine();
            repository.Update(tag);

            Console.WriteLine("");
            Console.WriteLine($"Tag {tag.Id} foi atualizada com sucesso");
        }
    }
}