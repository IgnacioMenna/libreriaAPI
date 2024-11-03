using System.ComponentModel.DataAnnotations;

namespace libreriaAPI.Models.Libro.Dto
{
    public class CreateLibroDTO
    {
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

        [Required]
        public int AutorId { get; set; }
    }
}
