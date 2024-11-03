using System.ComponentModel.DataAnnotations;

namespace libreriaAPI.Models.Genero.Dto
{
    public class CreateGeneroDTO
    {
        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; } = null!;
    }
}
