using libreriaAPI.Models.Autor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libreriaAPI.Models.Libro
{
    public class Libro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Titulo { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string Subtitulo { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; } = null!;

        [Required]
        public int CantidadPaginas { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        public int AutorId { get; set; }

        [Required]
        public int GeneroId { get; set; }

        [ForeignKey("AutorId")]
        public Autor.Autor Autor { get; set; } = null!;

        [ForeignKey("GeneroId")]
        public Genero.Genero Genero { get; set; } = null!;
    }
}
