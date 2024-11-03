using libreriaAPI.Config;
using libreriaAPI.Models.Autor;

namespace libreriaAPI.Repositories
{
    public interface IAutorRepository : IRepository<Autor> { }
    public class AutorRepository : Repository<Autor>, IAutorRepository
    {
        public AutorRepository(ApplicationDbContext db) : base(db) { }
    }
}
