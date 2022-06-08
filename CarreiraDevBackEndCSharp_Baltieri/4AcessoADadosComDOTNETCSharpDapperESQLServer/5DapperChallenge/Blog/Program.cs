using System;
using Blog.Models;
using Blog.Repositories;
using Blog.Screens.MenuCategoryScreen;
using Blog.Screens.MenuPostScreen;
using Blog.Screens.MenuPostTagScreen;
using Blog.Screens.MenuTagScreen;
using Blog.Screens.MenuUserRoleScreen;
using Blog.Screens.MenuUserScreen;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$";
        static void Main(string[] args)
        {
            Database.Connection = new SqlConnection(CONNECTION_STRING);
            Database.Connection.Open();

            Load();

            Console.WriteLine("");
            Console.WriteLine("Aperte qualquer tecla para encerrar a gestão");
            Console.ReadKey();
            Database.Connection.Close();
        }

        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("==          BLOG          ==");
            Console.WriteLine("============================");
            Console.WriteLine("Digite a ação que deseja realizar:");
            Console.WriteLine("1 - Gestão de Usuários");
            Console.WriteLine("2 - Gestão de Posts");
            Console.WriteLine("3 - Gestão de Categorias");
            Console.WriteLine("4 - Gestão de Tags");
            Console.WriteLine("5 - Vincular usuário a um perfil");
            Console.WriteLine("6 - Vincular um post a uma tag");
            Console.WriteLine("7 - Sair");
            Console.WriteLine("");
            Console.Write("Digite a sua escolha: ");
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1: MenuUserScreen.Load(); break;
                case 2: MenuPostScreen.Load(); break;
                case 3: MenuCategoryScreen.Load(); break;
                case 4: MenuTagScreen.Load(); break;
                case 5: MenuUserRoleScreen.Load(); break;
                case 6: MenuPostTagScreen.Load(); break;
                case 7: Environment.Exit(0); break;
                default: Load(); break;
            }
        }

    }
}
