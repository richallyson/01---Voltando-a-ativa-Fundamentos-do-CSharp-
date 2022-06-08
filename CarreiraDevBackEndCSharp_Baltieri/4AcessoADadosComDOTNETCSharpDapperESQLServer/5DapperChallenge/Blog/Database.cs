using Microsoft.Data.SqlClient;

namespace Blog
{
    // Compartilhando a conexão com geral
    public static class Database
    {
        public static SqlConnection Connection;
    }
}