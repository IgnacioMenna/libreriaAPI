using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace libreriaAPI.Models.Resena
{
    public class Resena
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(5)]
        public int Puntuacion { get; set; }

        [Required]
        [MaxLength(30)]
        public string Comentario { get; set; } = null!;

        [ForeignKey("LibroId")]
        public int LibroId { get; set; }
        public Libro.Libro Libro { get; set; } = null!;
    }
}
