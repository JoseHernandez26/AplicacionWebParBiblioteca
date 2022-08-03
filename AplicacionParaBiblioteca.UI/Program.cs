using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<AplicacionParaBiblioteca.BS.IRepositorioLibros, AplicacionParaBiblioteca.BS.RepositorioConCacheLibros>();
builder.Services.AddScoped<AplicacionParaBiblioteca.BS.IRepositorioHistorialDePrestamos, AplicacionParaBiblioteca.BS.RepositorioConCacheHistorialDePrestamos>();
builder.Services.AddScoped<AplicacionParaBiblioteca.BS.IRepositorioHistorialDePrestamosDeLibros, AplicacionParaBiblioteca.BS.IRepositorioHistorialDePrestamosDelLibro>();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AplicacionParaBiblioteca.DA.DbContexto>(x => x.UseSqlServer(connectionString));
builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Libro}/{action=Index}/{id?}");

app.Run();
