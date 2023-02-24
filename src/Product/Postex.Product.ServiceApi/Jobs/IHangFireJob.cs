namespace Postex.Product.ServiceApi.Jobs
{
    public interface IHangFireJob
    {
        Task SyncShops();
        Task SyncPrices();
    }
}
