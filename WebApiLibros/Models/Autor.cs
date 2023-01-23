using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiLibros.Models
{
    [Table("Autor")]
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Apellido { get; set; }

        [Range(18, 130, ErrorMessage = "Solo se permite ingresar edades entre 18 y 130.")]
        public int? Edad { get; set; }

        public List<Libro> Libros { get; set; }

    }
}
