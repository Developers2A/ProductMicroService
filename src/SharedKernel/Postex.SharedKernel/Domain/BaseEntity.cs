using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.SharedKernel.Domain
{
    public abstract class BaseEntity<TKey> : IEntity<TKey>, IAuditable<TKey>
    {
        public TKey Id { get; protected set; }
        public byte[] RowVersion { get; private set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
