using System.ComponentModel.DataAnnotations;

namespace libreriaAPI.Models.Libro.Dto
{
    public class UpdateLibroDTO
    {
        [MaxLength(20)]
        public string? Titulo { get; set; }

        [MaxLength(20)]
        public string? Subtitulo { get; set; }

        [MaxLength(50)]
        public string? Descripcion { get; set; }

        public int? CantidadPaginas { get; set; }

        public int? AutorId { get; set; }
    }
}
