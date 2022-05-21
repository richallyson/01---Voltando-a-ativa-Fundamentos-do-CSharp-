using System;
using Microsoft.Data.SqlClient;

namespace DataAcess
{
    class Program
    {
        // ADO.NET = Vamos conhecer o básico dele, mas sem se aprofundar
        // Como você vai ver, vai ser bastante código para fzr pouca coisa, sendo assim, não é tão produtivo
        // Ele é extremamente performatico, porém no dia a dia, é usado o dapper, entity, etc
        // Porém é sempre importante saber o que roda por de trás dos panos do dapper, entity, ou qualquer outro framework de acesso a dados
        static void Main(string[] args)
        {
            // CONNECTION
            // Para se conectar do nosso programa CSharp para o nosso banco de dados, precisamos de uma Connection String
            // A primeira coisa que precisamos informar para ele é qual servidor que a gente vai conectar, também sua porta; database; user; senha
            const string connectionString = "Server=localhost,1433; Database=balta;User ID=sa;Password=1q2w3e4r@#$";
            // E para se conectar ao banco de dados precisamos de um pacote chamado Microsoft.Data.SqlClient
            // Para instalar o pacote é só digitar dotnet add package [nome do pacote]. Que é exatamente como descrito acima
            // Outra coisa importante, adicione a versão do curso que é a 2.1.3, para isso, basta adicionar o --version 2.1.3 a final do comando de adicionar pacote
            // E depois de instalado, basta adicionar ele com um using

            // Uma conexão com o banco funciona da seguinte forma: você abre a conexão, executa o que quer e fecha a conexão
            // Existem limites de slots de conexão, então é uma boa prática sempre abrir uma conexão, realizar algo e sair
            // Pois dessa forma vc n vai criar um gargalo que impede outras pessoas de acessarem o banco, assim como tbm evita de crashar o servidor
            // Apesar do garbage collector depois de um tempo perceber que ela está aberta e fechar pra você, é sempre bom vc fazer isso par aotimizar as coisas
            // Se você não for usar mais essa conexão futuramente, você pode dar um connectio.Dispose(). Assim ele vai destruir o objeto e fechar a conexão
            // Mas caso ainda vá usar o objeto use o connectio.Close(), pois assim futuramente você pode novamente usar o connection.Open()
            // E para isso a melhor forma de abrir e fechar uma conexão sem ter que ficar digitando open e close, é usando um using, caso não precise da connection aberta pro um longo periodo de tempo

            using (var connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Conectado");

                // Como ler as informações do banco - Vamos fazer um select e selecionar o Id e o Title da categoria
                connection.Open();
                // Para isso usaremos o SqlCommand
                // Ele é usando também dentro de um using, pois pode deixar vestigios, e dentro do using ao terminar de ser usado já é dado um dispose
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT [Id], [Title] FROM [Category]";

                    // Como o nosso comando é uma leitura, iremos executar o ExecuteReader, caso fosse outra ação dentro do banco, utilizar outra função respectiva a isso    
                    // Essa função é do SqLDataReader, porém, o command já possui essa função dentro dele também
                    var reader = command.ExecuteReader();

                    // O SqlDataReader é um cursor, então não tem como iterar dentro dele, ele vai apenas pra frente, do 0 até onde deve ir
                    while (reader.Read())
                    {
                        // Porquê 0 e 1 dentro das funções? Porquê eles se assemelham a coluna descrita acima no select
                        // E como a gente já sabe que o 0 é um Guid, pois é o Id, e o 1 é uma string pois é um title, colocamos essas respectivas funções para rodar
                        // Caso fosse outro tipo, vc daria o GetOutroTipo(numerodacoluna)
                        // Se vc colocar uma coluna que não existe no command, vai dar erro
                        Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}");
                    }
                }
            }

        }
    }
}
