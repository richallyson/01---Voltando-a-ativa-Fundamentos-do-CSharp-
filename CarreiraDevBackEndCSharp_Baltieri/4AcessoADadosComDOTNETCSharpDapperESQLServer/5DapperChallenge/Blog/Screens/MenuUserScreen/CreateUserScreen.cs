using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuUserScreen
{
    public static class CreateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= CRIANDO NOVO USUÁRIO =");
            Console.WriteLine("========================");
            Create();
            Console.WriteLine("========================");
            Console.WriteLine("");
            Console.WriteLine("Aperter ENTER para voltar para o menu");
            Console.ReadLine();
            MenuUserScreen.Load();
        }

        private static void Create()
        {
            var repository = new Repository<User>();
            var user = new User();
            Console.Write("Digite o nome do usuário: ");
            user.Name = Console.ReadLine();
            Console.Write("Digite o email do usuário: ");
            user.Email = Console.ReadLine();
            Console.Write("Digite a senha do usuário: ");
            user.PasswordHash = Console.ReadLine();
            Console.Write("Digite a bio do usuário: ");
            user.Bio = Console.ReadLine();
            Console.Write("Digite o endereço da imagem do usuário: ");
            user.Image = Console.ReadLine();
            Console.Write("Digite o slug do usuário: ");
            user.Slug = Console.ReadLine();
            repository.Create(user);

            Console.WriteLine("");
            Console.WriteLine($"Usuário {user.Name} criado com sucesso");
        }
    }
}