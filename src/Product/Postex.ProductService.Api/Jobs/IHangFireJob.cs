namespace Postex.ProductService.Api.Jobs
{
    public interface IHangFireJob
    {
        Task SyncShops();
        Task SyncPrices();
    }
}
