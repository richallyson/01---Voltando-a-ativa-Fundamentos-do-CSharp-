using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.Data
{
    // LEmbrando que o nosso DbContext é a representação do nosso banco em memória
    // E os DbSets são as representações das tabelas em memoria
    public class AppDbContext : DbContext
    {
        public DbSet<TodoModel> Todos { get; set; }

        // Cofigurando a nossa connection string usando o Sqlite
        // Como esse banco não existe (não foi feito antes), a gente vai gerar ele via Migrations
        // Se você viu o ultimo módulo sobre EF, o seu comando dotnet ef tool já está liberado
        // Sendo assim, basta ir no prompt e digitar dotnet ef migrations add "nomedomigrations", para gerar ele
        // Logo depois basta dar um dotnet ef database update, que o nosso banco vai ser gerado. Vai ser criado um arquivo app.db, do qual pode ser aberto por qualquer editor do sqlite
        // Esse arquivo .db gerado é uma diferenciação do Sqlite. No módulo anterior foi feito um migrations usando SqlServer e a parada foi diferente
        // Esse tipo de abordagem pode ser usado para apps do tipo Standalone ou Offline, que são apps que n ficam em um servidor. Porém, não é a maioria dos casos quando se trata de uma API
        // Então, esse modelo é só um exemplo, pra gente poder utilizar o EF junto da nossa API, para gente ter uma ideia de como a gente pode criar uma API do zero
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}