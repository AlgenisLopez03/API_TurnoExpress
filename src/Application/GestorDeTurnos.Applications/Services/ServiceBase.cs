using AutoMapper;
using GestorDeTurnos.Application.Exceptions;
using GestorDeTurnos.Application.Interfaces;
using GestorDeTurnos.Application.Interfaces.Repositories;
using GestorDeTurnos.Application.Interfaces.Services;
using GestorDeTurnos.Application.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System.Linq.Expressions;
using System.Web;

namespace GestorDeTurnos.Application.Services
{
    /// <summary>
    /// Provides basic service operations like CRUD for the entity of type TEntity.
    /// </summary>
    public class ServiceBase<TEntity> : IAsyncService<TEntity>
    {
        #region Private Variable

        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        protected readonly IAsyncRepository<TEntity> repository;

        #endregion Private Variable

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the ServiceBase class.
        /// </summary>
        /// <param name="repository">The repository for operations.</param>
        /// <param name="mapper">The mapper for entity transformations.</param>
        /// <param name="httpContextAccessor">The HTTP context accessor for request handling.</param>

        public ServiceBase(IAsyncRepository<TEntity> repository, IMapper mapper, IHttpContextAccessor httpContext)
        {
            this.repository = repository;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        #endregion Constructor

        #region Public Methods

        /// <summary>
        /// Creates a new entity from the source.
        /// </summary>
        /// <typeparam name="TSource">The source type for creation.</typeparam>
        /// <param name="source">The source object to create the entity from.</param>

        public virtual async Task<TEntity> CreateAsync<TSource>(TSource source)
        {
            var entity = _mapper.Map<TEntity>(source);
            await repository.CreateAsync(entity);
            return entity;
        }

        /// <summary>
        /// Deletes the entity identified by the provided id.
        /// </summary>
        /// <param name="id">The identifier of the entity to be deleted.</param>

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity is null)
            {
                throw new NotFoundException(typeof(TEntity).Name, id);
            }

            await repository.DeleteAsync(entity);
        }

        /// <summary>
        /// Checks if an entity with the provided id exists.
        /// </summary>
        /// <param name="id">The identifier of the entity to check.</param>
        /// <returns>A boolean indicating the existence of the entity.</returns>

        public virtual async Task<bool> ExistsAsync(int id)
        {
            var entity = await GetByIdProjectedAsync<TEntity>(id);
            return entity != null;
        }

        /// <summary>
        /// Retrieves all entities and projects them to the specified type.
        /// </summary>
        /// <typeparam name="TDestination">The type to which the entities will be projected.</typeparam>
        /// <returns>A collection of projected entities.</returns>
        public virtual async Task<IEnumerable<TDestination>> GetAllProjectedAsync<TDestination>()
        {
            return await repository.GetAllProjectedAsync<TDestination>();
        }


        /// <summary>
        /// Retrieves an entity by id and projects it to the specified type with all specified includes.
        /// </summary>
        /// <typeparam name="TDestination">The type to which the entity will be projected.</typeparam>
        /// <param name="id">The identifier of the entity.</param>
        /// <param name="includes">Expressions representing the properties to include in the query.</param>
        /// <returns>A projected entity of the specified type if found; otherwise, throws NotFoundException.</returns>
        public virtual async Task<TDestination?> GetByIdProjectedWithIncludesAsync<TDestination>(int id, params Expression<Func<TEntity, object>>[] includes)
        {
            var entity = await repository.GetByIdProjectedWithIncludesAsync<TDestination>(id, includes);

            if (entity is null)
            {
                throw new NotFoundException(typeof(TEntity).Name, id);
            }

            return entity;
        }

        /// <summary>
        /// Retrieves all entities with pagination and projects them to the specified type, based on a given specification.
        /// </summary>
        /// <typeparam name="TDestination">The type to which the entities will be projected.</typeparam>
        /// <typeparam name="TSpecification">The specification type to apply for filtering and sorting.</typeparam>
        /// <param name="request">The pagination request details.</param>
        /// <returns>A paged collection of projected entities.</returns>
        public virtual async Task<PagedCollection<TDestination>> GetAllProjectedWithPaginationAsync<TDestination, TSpecification>(IPaginationBase request)
        where TSpecification : ISpecification<TEntity>
        {
            var type = typeof(TSpecification);
            object[] constructorArguments = new object[] { request };
            var spec = (TSpecification)Activator.CreateInstance(type, constructorArguments)!;

            if (spec.Skip % spec.Take != 0)
            {
                throw new BadRequestException($"The 'offset' value ({spec.Skip}) must be either zero or a multiple of the 'limit' value({spec.Take}).");
            }

            var total = await repository.GetTotalCountAsync(spec.Criteria);

            if (total < spec.Skip)
            {
                throw new BadRequestException($"The 'offset' value must be either zero or minimum to 'total' value ({total}) and multiple of the 'limit' value({spec.Take}).");
            }

            var items = await repository.GetAllProjectedAsync<TDestination>(spec);
            var href = _httpContext?.HttpContext?.Request.GetEncodedUrl()!;

            var next = GetNextURL(href, spec.Take, spec.Skip, total);
            var prev = GetPrevURL(href, spec.Take, spec.Skip);

            return new PagedCollection<TDestination>
            {
                Href = href,
                Items = items,
                Limit = spec.Take,
                Next = next,
                Offset = spec.Skip,
                Prev = prev,
                Total = total
            };
        }

        /// <summary>
        /// Retrieves a single entity projected to the specified type by its id.
        /// </summary>
        /// <typeparam name="TDestination">The type to which the entity will be projected.</typeparam>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns>The projected entity if found; otherwise, throws NotFoundException.</returns>
        public virtual async Task<TDestination> GetByIdProjectedAsync<TDestination>(int id)
        {
            var mappedEntity = await repository.GetByIdProjectedAsync<TDestination>(id);
            if (mappedEntity is null)
            {
                throw new NotFoundException(typeof(TEntity).Name, id);
            }

            return mappedEntity;
        }

        /// <summary>
        /// Retrieves a single entity by its id.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns>The entity if found; otherwise, throws NotFoundException.</returns>

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            var mappedEntity = await repository.GetByIdAsync(id);
            if (mappedEntity is null)
            {
                throw new NotFoundException(typeof(TEntity).Name, id);
            }

            return mappedEntity;
        }

        /// <summary>
        /// Updates an entity identified by the provided id with the given source data.
        /// </summary>
        /// <typeparam name="TSource">The source type containing update data.</typeparam>
        /// <param name="id">The identifier of the entity to be updated.</param>
        /// <param name="source">The source object containing the update data.</param>
        /// <returns>Throws BadRequestException if Id mismatch; NotFoundException if entity is not found.</returns>

        public virtual async Task UpdateAsync<TSource>(int id, TSource source) where TSource : IHasId<int>
        {
            if (!id.Equals(source.Id))
            {
                throw new BadRequestException("The source Id does not match the provided Id");
            }

            var entity = await GetByIdAsync(id);

            if (entity == null)
            {
                throw new NotFoundException(typeof(TEntity).Name, id);
            }

            _mapper.Map(source, entity);
            await repository.UpdateAsync(entity);
        }

        /// <summary>
        /// Retrieves the first entity that satisfies the given predicate or null if no such entity is found.
        /// </summary>
        /// <param name="predicate">The expression to filter entities.</param>
        /// <returns>The first entity that satisfies the predicate or null.</returns>
        public virtual async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await repository.FirstOrDefaultAsync(predicate);
        }

        #endregion Public Methods

        #region Private Methods

        private string? GetNextURL(string url, int limit, int offset, int total)
        {
            var newOffSet = limit + offset;
            if (newOffSet >= total)
            {
                return null;
            }

            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["offset"] = $"{newOffSet}";
            uriBuilder.Query = query.ToString();
            return uriBuilder.ToString();
        }

        private string? GetPrevURL(string url, int limit, int offset)
        {
            var oldOffSet = offset - limit;
            if (oldOffSet < 0)
            {
                return null;
            }

            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            if (oldOffSet == 0)
            {
                query.Remove("offset");
            }
            else
            {
                query["offset"] = $"{oldOffSet}";
            }

            uriBuilder.Query = query.ToString();
            return uriBuilder.ToString();
        }

        #endregion Private Methods
    }
}