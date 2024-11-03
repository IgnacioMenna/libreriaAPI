using libreriaAPI.Models.Resena;
using libreriaAPI.Config;

namespace libreriaAPI.Repositories
{
    public interface IResenaRepository : IRepository<Resena> { }

    public class ResenaRepository : Repository<Resena>, IResenaRepository
    {
        public ResenaRepository(ApplicationDbContext db) : base(db) { }
    }
}
