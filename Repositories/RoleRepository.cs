using libreriaAPI.Config;
using libreriaAPI.Models.Role;

namespace libreriaAPI.Repositories
{
    public interface IRoleRepository : IRepository<Role> { }
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
