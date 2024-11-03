using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace libreriaAPI.Models.Libro.Dto
{
    public class LibroDTO
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public string Subtitulo { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public int CantidadPaginas { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public Autor.Autor Autor { get; set; } = null!;
    }
}
