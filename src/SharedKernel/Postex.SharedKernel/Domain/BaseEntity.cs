namespace Postex.SharedKernel.Domain
{
    public abstract class BaseEntity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; protected set; }
        public byte[] RowVersion { get; private set; }
        public DateTime CreatedOn { get; set; }
        public TKey? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? RemovedOn { get; set; }
        public TKey? ModifiedBy { get; set; }
    }
}
