using libreriaAPI.Config;
using libreriaAPI.Models.Autor;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using libreriaAPI.Models.Libro;

namespace libreriaAPI.Repositories
{
    public interface IAutoRepository : IRepository<Libro> { }
    public class LibroRepository : Repository<Libro>, IAutoRepository
    {
        public LibroRepository(ApplicationDbContext db) : base(db) { }

        public new async Task<Libro> GetOne(Expression<Func<Libro, bool>>? filter = null)
        {
            IQueryable<Libro> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter).Include(a => a.Autor);
            }
            return await query.FirstOrDefaultAsync();
        }
    }
}
