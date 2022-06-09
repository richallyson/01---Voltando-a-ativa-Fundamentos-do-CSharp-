using System;

namespace Blog.Screens.MenuCategoryScreen
{
    public static class MenuCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= GESTÃO DE CATEGORIA = ");
            Console.WriteLine("========================");
            Console.WriteLine("1 - Criar uma Categoria");
            Console.WriteLine("2 - Listar Categorias");
            Console.WriteLine("3 - Atualizar Categoria");
            Console.WriteLine("4 - Deletar Categoria");
            Console.WriteLine("5 - Listar quantidade de posts pro categoria");
            Console.WriteLine("6 - Listar todos os posts de uma categoria");
            Console.WriteLine("7 - Voltar ao menu principal");
            Console.WriteLine("");
            Console.Write("Digite a sua escolha: ");
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1: CreateCategoryScreen.Load(); break;
                case 2: ListCategoryScreen.Load(); break;
                case 3: UpdateCategoryScreen.Load(); break;
                case 4: DeleteCategoryScreen.Load(); break;
                case 5: ListCategoriesWithPostQuantityScreen.Load(); break;
                case 6: ListPostsOfACategoryScreen.Load(); break;
                case 7: Program.Load(); break;
                default: Load(); break;
            }
        }
    }
}