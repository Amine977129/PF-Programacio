using TodoMVC.Data;

var builder = WebApplication.CreateBuilder(args);

//  MVC services
builder.Services.AddControllersWithViews();

var app = builder.Build();


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// craer base de datos
Database.Inicializar();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Libros}/{action=Index}/{id?}"
);

app.Run();