using Microsoft.EntityFrameworkCore;
using Proyecto2025.BD.Datos;
using Proyecto2025.Server.Client.Pages;
using Proyecto2025.Server.Components;

var builder = WebApplication.CreateBuilder(args);
#region configura el Constructor de la aplicacion y sus servicios

builder.Services.AddControllers();

//var ClaveConfig = builder.Configuration.GetValue<string>("Clave");
var connectionString = builder.Configuration.GetConnectionString("ConnSqlServer")
                            ?? throw new InvalidOperationException(
                                    "El string de conexion no existe.");
builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

#endregion

var app = builder.Build();
#region Construccion la aplicacion y área de middlewares

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Proyecto2025.Server.Client._Imports).Assembly);

app.MapControllers();

#endregion

app.Run();
