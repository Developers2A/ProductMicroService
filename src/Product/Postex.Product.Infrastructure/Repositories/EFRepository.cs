using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Infrastructure.Data;
using Postex.SharedKernel.Interfaces;
using Postex.SharedKernel.Paginations;

namespace Postex.Product.Infrastructure.Repositories
{
    public class EFRepository<TEntity> : IWriteRepository<TEntity>, IReadRepository<TEntity>
         where TEntity : class
    {
        private readonly ApplicationDBContext _context;
        public DbSet<TEntity> _dbSet { get; }

        public EFRepository(ApplicationDBContext dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Table => _dbSet;
        public virtual IQueryable<TEntity> TableNoTracking => _dbSet.AsNoTracking();

        public TEntity Add(TEntity entity)
        {
            return _context.Add(entity).Entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            return entity;
        }
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return;
        }

        public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            return;
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
        }


        public async Task CommitTransactionAsync(Action action, CancellationToken cancellationToken = default)
        {
            try
            {
                await _context.Database.BeginTransactionAsync(cancellationToken);
                action.Invoke();
                await SaveChangeAsync(cancellationToken);
                await _context.Database.CommitTransactionAsync(cancellationToken);
            }
            catch
            {
                await _context.Database.RollbackTransactionAsync(cancellationToken);
                throw;
            }
        }

        public TEntity Delete(TEntity entity)
        {
            return _context.Remove(entity).Entity;
        }

        public Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_context.Remove(entity).Entity);
        }

        public Task SaveChangeAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public TEntity Update(TEntity entity)
        {
            return _dbSet.Update(entity).Entity;
        }

        public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_dbSet.Update(entity).Entity);
        }

        public Task<bool> AnyAsync(CancellationToken cancellationToken)
        {
            return _dbSet.AnyAsync(cancellationToken);
        }

        public Task<int> CountAsync(CancellationToken cancellationToken)
        {
            return _dbSet.CountAsync(cancellationToken);
        }

        public Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return _dbSet.ToListAsync(cancellationToken);
        }

        public Task<TEntity> GetAsync(CancellationToken cancellationToken)
        {
            return _dbSet.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.FindAsync(id, cancellationToken);
        }

        //public Task<PagedList<TEntity>> GetPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        //{
        //    return dbContext.Set<TEntity>().ToPagedListAsync(pageIndex, pageSize, 0, cancellationToken);
        //}

        Task<PagedList<TEntity>> IReadRepository<TEntity>.GetPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
