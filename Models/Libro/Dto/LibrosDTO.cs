namespace libreriaAPI.Models.Libro.Dto
{
    public class LibrosDTO
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public string Subtitulo { get; set; } = null!;

        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
