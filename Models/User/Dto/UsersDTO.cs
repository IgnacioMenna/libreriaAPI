using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace libreriaAPI.Models.User.Dto
{
    public class UsersDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string UserName { get; set; } = null!;
    }
}
