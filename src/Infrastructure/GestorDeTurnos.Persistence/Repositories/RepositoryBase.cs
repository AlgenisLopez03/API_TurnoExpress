using AutoMapper;
using AutoMapper.QueryableExtensions;
using GestorDeTurnos.Application.Interfaces;
using GestorDeTurnos.Application.Interfaces.Repositories;
using GestorDeTurnos.Domain.Common;
using GestorDeTurnos.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestorDeTurnos.Persistence.Repositories
{
    public class RepositoryBase<TEntity> : IAsyncRepository<TEntity> where TEntity : EntityBase
    {
        #region Private Variables

        private readonly ApplicationDbContext _dbContext;
        private readonly IConfigurationProvider _configurationProvider;

        #endregion Private Variables

        #region Constructor

        public RepositoryBase(ApplicationDbContext context, IConfigurationProvider configurationProvider)
        {
            _dbContext = context;
            _configurationProvider = configurationProvider;
        }

        #endregion Constructor

        #region Public Methods

        public async Task CreateAsync(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TDestination?> GetByIdProjectedAsync<TDestination>(int id)
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();
            return await query.Where(x => x.Id.Equals(id))
                              .AsNoTracking()
                              .ProjectTo<TDestination>(_configurationProvider)
                              .FirstOrDefaultAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();
            return await query.Where(x => x.Id.Equals(id))
                              .FirstOrDefaultAsync();
        }

        public async Task<int> GetTotalCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
            {
                return await _dbContext.Set<TEntity>().CountAsync();
            }
            else
            {
                return await _dbContext.Set<TEntity>().Where(predicate).CountAsync();
            }
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<TDestination>> GetAllProjectedAsync<TDestination>(ISpecification<TEntity> spec)
        {
            var query = _dbContext.Set<TEntity>().AsQueryable().AsNoTracking();
            query = ApplySpecification(query, spec);

            return await query.ProjectTo<TDestination>(_configurationProvider).ToListAsync();
        }

        public async Task<List<TDestination>> GetAllProjectedAsync<TDestination>()
        {
            return await _dbContext.Set<TEntity>()
                                   .AsNoTracking()
                                   .ProjectTo<TDestination>(_configurationProvider)
                                   .ToListAsync();
        }

        public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<List<TEntity>> GetAllWithIncludeAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            var entityProperties = _dbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations();

            if (includes.Length == 0)
            {
                foreach (var property in entityProperties)
                {
                    query = query.Include(property.Name);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<List<TEntity>> GetAllWithIncludeAsync(ISpecification<TEntity> spec, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (includes.Length == 0)
            {
                var entityProperties = _dbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations();
                foreach (var property in entityProperties)
                {
                    query = query.Include(property.Name);
                }
            }

            if (spec != null)
            {
                query = ApplySpecification(query, spec);
            }

            return await query.ToListAsync();
        }

        #endregion Public Methods

        #region Private Methods

        private IQueryable<TEntity> ApplySpecification(IQueryable<TEntity> query, ISpecification<TEntity> spec)
        {
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            if (spec.Descending)
            {
                query = query.OrderByDescending(spec.OrderBy);
            }
            else
            {
                query = query.OrderBy(spec.OrderBy);
            }

            return query.Skip(spec.Skip).Take(spec.Take);
        }

        #endregion Private Methods
    }
}