using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace libreriaAPI.Models.User.Dto
{
    public class CreateUserDTO
    {
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string UserName { get; set; } = null!;
    }
}
