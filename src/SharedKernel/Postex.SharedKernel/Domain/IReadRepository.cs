using Postex.SharedKernel.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.SharedKernel.Domain
{
    public interface IReadRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }
        Task<TEntity> GetAsync(CancellationToken cancellationToken);
        Task<TEntity> GetAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken);
        Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
        Task<List<TEntity>> GetAllAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken);
        Task<bool> AnyAsync(CancellationToken cancellationToken);
        Task<bool> AnyAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken);
        Task<int> CountAsync(CancellationToken cancellationToken);
        Task<int> CountAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken);
        Task<IPagedList<TEntity>> GetPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken, int limitSize = 100);
        Task<IPagedList<TEntity>> GetPageAsync(ISpecification<TEntity> spec, int pageIndex, int pageSize, CancellationToken cancellationToken, int limitSize = 100);
    }
}
