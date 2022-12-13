using Product.Application.Contracts;

namespace Product.Application.Features.Couriers.Commands.UpdateCourier
{
    public class UpdateCourierCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ForeignPost { get; set; }
        public bool DomesticPost { get; set; }
        public bool HasCollection { get; set; }
        public bool HasDistribution { get; set; }
        public bool BetweenCity { get; set; }
        public bool InnerCity { get; set; }
        public bool Parcel { get; set; }
        public bool Document { get; set; }
        public bool HasApi { get; set; }
        public bool CodPayment { get; set; }
        public bool NeedLatLon { get; set; }
        public bool Fragile { get; set; }
        public bool FreeShipping { get; set; }
        public bool PostPaid { get; set; }
        public bool Heavy { get; set; }
        public bool ChangePrice { get; set; }
        public float ChangePercent { get; set; }
        public string Company { get; set; }
        public bool IsActive { get; set; }
    }
}
