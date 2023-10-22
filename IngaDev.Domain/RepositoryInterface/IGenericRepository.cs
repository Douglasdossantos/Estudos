using IngaDev.Domain.Entities;

namespace IngaDev.Domain.RepositoryInterface
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();

        Task<T> GetById(Guid Id);
        Task<T> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(Guid id);
    }

}
