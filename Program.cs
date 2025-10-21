// Builder
using TaskWeb.Repositories;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddSingleton<ITagRepository>(new TagMemoryRepository());
builder.Services.AddTransient<IUsuarioRepository>(_ => 
    new UsuarioDatabaseRepository(
        builder.Configuration.GetConnectionString("default")));
builder.Services.AddTransient<ITagRepository>(_ => 
    new TagDatabaseRepository(
        builder.Configuration.GetConnectionString("default")));
builder.Services.AddTransient<ITarefaRepository>(_ => 
    new TarefaDatabaseRepository(
        builder.Configuration.GetConnectionString("default")));

builder.Services.AddSession();
builder.Services.AddControllersWithViews();

// App
var app = builder.Build();

app.UseSession();
app.MapControllerRoute("default", "{controller=usuario}/{action=login}/{id?}");

app.Run();
