using Microsoft.EntityFrameworkCore; // Agregarlo siempre
using WebApiLibros.Models;

namespace WebApiLibros.Data
{
    public class DBLibrosBootcampContext : DbContext
    {

        public DBLibrosBootcampContext(DbContextOptions<DBLibrosBootcampContext> options):base(options) { }

        //propiedades, por cada modelo un dbset:

        public DbSet<Autor> Autores { get; set; }

        public DbSet<Libro> Libros { get; set; }

    }
}
