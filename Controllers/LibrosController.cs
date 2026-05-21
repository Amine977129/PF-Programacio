using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using TodoMVC.Data;
using TodoMVC.Models;

namespace TodoMVC.Controllers;

public class LibrosController : Controller
{
    // ✅ INDEX + FILTRO (EXTRA)
    public IActionResult Index(string filtro = "todos")
    {
        var libros = new List<Libro>();

        using var conexion = Database.AbrirConexion();

        string sql = "SELECT Id, Titulo, Autor, Leido, Categoria FROM Libros";

        if (filtro == "leidos")
            sql += " WHERE Leido = 1";
        else if (filtro == "noleidos")
            sql += " WHERE Leido = 0";

        sql += " ORDER BY Id DESC";

        using var comando = new SqliteCommand(sql, conexion);
        using var reader = comando.ExecuteReader();

        while (reader.Read())
        {
            libros.Add(new Libro
            {
                Id = reader.GetInt32(0),
                Titulo = reader.GetString(1),
                Autor = reader.GetString(2),
                Leido = reader.GetInt32(3) == 1,
                Categoria = reader.GetString(4)
            });
        }

        return View(libros);
    }

    // ✅ CREATE (GET)
    public IActionResult Crear()
    {
        return View();
    }

    // ✅ CREATE (POST + VALIDATION OBLIGATORIA)
    [HttpPost]
    public IActionResult Crear(Libro libro)
    {
        if (string.IsNullOrWhiteSpace(libro.Titulo) || libro.Titulo.Length < 3)
        {
            ViewBag.Error = "El título debe tener mínimo 3 caracteres";
            return View(libro);
        }

        if (string.IsNullOrWhiteSpace(libro.Autor))
        {
            ViewBag.Error = "El autor es obligatorio";
            return View(libro);
        }

        using var conexion = Database.AbrirConexion();

        var sql = @"INSERT INTO Libros (Titulo, Autor, Leido, Categoria)
                    VALUES (@titulo, @autor, 0, @categoria)";

        using var comando = new SqliteCommand(sql, conexion);

        comando.Parameters.AddWithValue("@titulo", libro.Titulo);
        comando.Parameters.AddWithValue("@autor", libro.Autor);
        comando.Parameters.AddWithValue("@categoria", libro.Categoria);

        comando.ExecuteNonQuery();

        return RedirectToAction("Index");
    }

    // ✅ EDITAR (GET)
    public IActionResult Editar(int id)
    {
        Libro libro = new();

        using var conexion = Database.AbrirConexion();
        var sql = "SELECT Id, Titulo, Autor, Leido, Categoria FROM Libros WHERE Id=@id";

        using var comando = new SqliteCommand(sql, conexion);
        comando.Parameters.AddWithValue("@id", id);

        using var reader = comando.ExecuteReader();

        if (reader.Read())
        {
            libro.Id = reader.GetInt32(0);
            libro.Titulo = reader.GetString(1);
            libro.Autor = reader.GetString(2);
            libro.Leido = reader.GetInt32(3) == 1;
            libro.Categoria = reader.GetString(4);
        }

        return View(libro);
    }

    // ✅ EDITAR (POST + VALIDATION)
    [HttpPost]
    public IActionResult Editar(Libro libro)
    {
        if (string.IsNullOrWhiteSpace(libro.Titulo) || libro.Titulo.Length < 3)
        {
            ViewBag.Error = "Título inválido";
            return View(libro);
        }

        using var conexion = Database.AbrirConexion();

        var sql = @"UPDATE Libros 
                    SET Titulo=@titulo, Autor=@autor, Leido=@leido, Categoria=@categoria
                    WHERE Id=@id";

        using var comando = new SqliteCommand(sql, conexion);

        comando.Parameters.AddWithValue("@titulo", libro.Titulo);
        comando.Parameters.AddWithValue("@autor", libro.Autor);
        comando.Parameters.AddWithValue("@leido", libro.Leido ? 1 : 0);
        comando.Parameters.AddWithValue("@categoria", libro.Categoria);
        comando.Parameters.AddWithValue("@id", libro.Id);

        comando.ExecuteNonQuery();

        return RedirectToAction("Index");
    }

    // ✅ MARCAR COMO LEÍDO
    public IActionResult Leer(int id)
    {
        using var conexion = Database.AbrirConexion();

        var sql = "UPDATE Libros SET Leido = 1 WHERE Id = @id";

        using var comando = new SqliteCommand(sql, conexion);
        comando.Parameters.AddWithValue("@id", id);

        comando.ExecuteNonQuery();

        return RedirectToAction("Index");
    }

    // ✅ DELETE
    public IActionResult Eliminar(int id)
    {
        using var conexion = Database.AbrirConexion();

        var sql = "DELETE FROM Libros WHERE Id = @id";

        using var comando = new SqliteCommand(sql, conexion);
        comando.Parameters.AddWithValue("@id", id);

        comando.ExecuteNonQuery();

        return RedirectToAction("Index");
    }
}