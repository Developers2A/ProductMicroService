namespace Product.Api.Jobs
{
    public interface IHangFireJob
    {
        Task SyncShops();
        Task SyncPrices();
    }
}
