using System.ComponentModel.DataAnnotations;

namespace libreriaAPI.Models.Autor.Dto
{
    public class UpdateAutorDTO
    {
        [MaxLength(30)]
        public string? Nombre { get; set; }
    }
}
