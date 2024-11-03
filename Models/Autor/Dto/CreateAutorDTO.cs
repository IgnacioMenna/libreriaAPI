using System.ComponentModel.DataAnnotations;

namespace libreriaAPI.Models.Autor.Dto
{
    public class CreateAutorDTO
    {
        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; } = null!;
    }
}
