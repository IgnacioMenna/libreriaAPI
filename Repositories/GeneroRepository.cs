using libreriaAPI.Models.Genero;
using libreriaAPI.Config;

namespace libreriaAPI.Repositories
{
    public interface IGeneroRepository : IRepository<Genero> { }
    public class GeneroRepository : Repository<Genero>, IGeneroRepository
    {
        public GeneroRepository(ApplicationDbContext db) : base(db) { }
    }
}
