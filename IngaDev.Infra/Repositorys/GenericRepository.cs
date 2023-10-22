using IngaDev.Domain.Entities;
using IngaDev.Domain.RepositoryInterface;
using System.Threading.Tasks;
using System.Linq;
using IngaDev.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace IngaDev.Infra.Repositorys
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public readonly MyDbContext _context;
        public readonly DbSet<T> _db;

        public GenericRepository(MyDbContext context, DbSet<T> db)
        {
            _context = context;
            _db = context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            await _db.AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _db.FindAsync(id);
            if (entity == default)
            {
                throw new ArgumentNullException($"A entidade com o id: {id} não foi  encontrada no banco de dados");
            }
            entity.Ative = false;
            entity.DeletedAt = DateTime.Now;

            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return true;
        }

        public IQueryable<T> GetAll()
        {
            return _db.AsNoTracking();
        }

        public async Task<T> GetById(Guid Id)
        {
            return await _db.FindAsync(Id);
        }

        public async Task<bool> Update(T entity)
        {
            if (entity == default)
            {
                throw new ArgumentException($"A entidade informada está vazia");
            }
            entity.UpdatedAt = DateTime.Now;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
