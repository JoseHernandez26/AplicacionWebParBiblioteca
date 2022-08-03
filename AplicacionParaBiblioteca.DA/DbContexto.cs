using Microsoft.EntityFrameworkCore;

namespace AplicacionParaBiblioteca.DA
{
    public class DbContexto : DbContext {
        public DbContexto(DbContextOptions<DbContexto> opciones):base(opciones){}
    public DbSet<AplicacionParaBiblioteca.Model.Libros> Libros { get; set; }
        public DbSet<AplicacionParaBiblioteca.Model.HistorialDePrestamos> HistorialDePrestamos { get; set; }

        public DbSet<AplicacionParaBiblioteca.Model.HistorialDePrestamosDelLibro> HistorialDePrestamosDelLibro { get; set; }

    }
}