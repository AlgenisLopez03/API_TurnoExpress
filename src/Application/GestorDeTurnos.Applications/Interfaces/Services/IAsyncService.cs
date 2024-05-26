using GestorDeTurnos.Application.Pagination;
using System.Linq.Expressions;

namespace GestorDeTurnos.Application.Interfaces.Services
{
    public interface IAsyncService<TEntity>
    {
        Task<TEntity> CreateAsync<TSource>(TSource source);

        Task DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);

        Task<IEnumerable<TDestination>> GetAllProjectedAsync<TDestination>();

        Task<PagedCollection<TDestination>> GetAllProjectedWithPaginationAsync<TDestination, TSpecification>(IPaginationBase request) where TSpecification : ISpecification<TEntity>;

        Task<TDestination> GetByIdProjectedAsync<TDestination>(int id);

        Task<TEntity> GetByIdAsync(int id);

        Task UpdateAsync<TSource>(int id, TSource source) where TSource : IHasId<int>;

        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    }
}