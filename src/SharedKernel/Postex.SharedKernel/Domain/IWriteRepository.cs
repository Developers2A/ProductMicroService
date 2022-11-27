using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.SharedKernel.Domain
{
    public interface IWriteRepository<TEntity> where TEntity : BaseEntity<int>
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> AddRangeAsync(IEnumerable<TEntity> entities);
        Task<bool> DeleteRangeAsync(IEnumerable<TEntity> entities);
    }
}
