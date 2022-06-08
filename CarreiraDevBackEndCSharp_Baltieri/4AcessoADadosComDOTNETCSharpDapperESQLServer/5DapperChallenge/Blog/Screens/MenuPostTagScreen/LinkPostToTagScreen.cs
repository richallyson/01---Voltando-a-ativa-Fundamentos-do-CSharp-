using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuPostTagScreen
{
    public static class LinkPostToTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= VINCULANDO UM POST A UMA TAG =");
            Console.WriteLine("================================");
            LinkPostToTags();
            Console.WriteLine("================================");
            Console.WriteLine("");
            Console.WriteLine("Aperter ENTER para voltar para o menu");
            Console.ReadLine();
            MenuPostTagScreen.Load();
        }

        private static void LinkPostToTags()
        {
            var repository = new Repository<PostTag>();
            var postTag = new PostTag();
            Console.Write("Digite o id do post: ");
            postTag.PostId = int.Parse(Console.ReadLine());
            Console.Write("Digite o id da tag: ");
            postTag.TagId = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            repository.Create(postTag);
            Console.WriteLine($"A tag {postTag.TagId} foi vinculada ao post {postTag.PostId}");
        }
    }
}