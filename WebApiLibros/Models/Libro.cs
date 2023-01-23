using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiLibros.Models
{
    [Table("Libro")]
    public class Libro
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Titulo { get; set; }

        [Column(TypeName = "varchar(200)")]
        [Required]
        public string Descripcion { get; set; }


        public int IdAutor { get; set; }

        [ForeignKey("IdAutor")]
        public Autor Autor { get; set; }
    }
}
