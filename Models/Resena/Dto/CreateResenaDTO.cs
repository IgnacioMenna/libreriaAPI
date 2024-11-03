using System.ComponentModel.DataAnnotations;

namespace libreriaAPI.Models.Resena.Dto
{
    public class CreateResenaDTO
    {
        [Required]
        [MaxLength(5)]
        public int Puntuacion { get; set; }

        [Required]
        [MaxLength(30)]
        public string Comentario { get; set; } = null!;
    }
}
