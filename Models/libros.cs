namespace TodoMVC.Models;

public class Libro
{
    public int Id { get; set; }
    public string Titulo { get; set; } = "";
    public string Autor { get; set; } = "";
    public bool Leido { get; set; }

    // ⭐ campo extra obligatorio
    public string Categoria { get; set; } = "";
}