using System.ComponentModel.DataAnnotations;

namespace libreriaAPI.Models.Genero.Dto
{
    public class UpdateGeneroDTO
    {
        [Required]
        [MaxLength(30)]
        public string? Nombre { get; set; }
    }
}
