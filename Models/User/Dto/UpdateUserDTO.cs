using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace libreriaAPI.Models.User.Dto
{
    public class UpdateUserDTO
    {
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string UserName { get; set; } = null!;
    }
}
