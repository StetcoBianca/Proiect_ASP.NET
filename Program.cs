using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proiect_ASP.NET.Data;

var builder = WebApplication.CreateBuilder(args);

// Adaugă serviciile necesare aplicației.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Proiect_ASPNETContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Proiect_ASPNETContext") ?? throw new InvalidOperationException("Connection string 'Proiect_ASPNETContext' not found.")));

var app = builder.Build();

// Configurează pipeline-ul HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configurează ruta implicită pentru pagina principală.
app.MapGet("/", context =>
{
    context.Response.Redirect("/ClaseFitness");
    return Task.CompletedTask;
});

// Map Razor Pages
app.MapRazorPages();

app.Run();
