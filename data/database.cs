using Microsoft.Data.Sqlite;

namespace TodoMVC.Data
{
    public static class Database
    {
//   abrir la connection
        public static SqliteConnection AbrirConexion()
        {
            var conexion = new SqliteConnection("Data Source=libros.db");
            conexion.Open();
            return conexion;
        }

    //   crate table
        public static void Inicializar()
        {
            using var conexion = AbrirConexion();

            var sql = @"
            CREATE TABLE IF NOT EXISTS Libros (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Titulo TEXT NOT NULL,
                Autor TEXT NOT NULL,
                Leido INTEGER NOT NULL,
                Categoria TEXT NOT NULL
            );";

            using var comando = new SqliteCommand(sql, conexion);
            comando.ExecuteNonQuery();
        }
    }
}