namespace Postex.Product.Application.Dtos.Posts
{
    public class PostShopDto
    {
        public int ShopId { get; set; }
        public string? PostalCode { get; set; }
        public int ProvinceCode { get; set; }
        public int PostUnitID { get; set; }
        public int CityCode { get; set; }
        public int PostnodeID { get; set; }
        public bool Enabled { get; set; }
        public bool AdminAccepet { get; set; }
        public DateTime ContractEndDate { get; set; }
        public int PricePlanID { get; set; }
        public int CollectTypeID { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Mob { get; set; }
        public string? Email { get; set; }
        public string WebSiteURL { get; set; }
        public string? AccountBank { get; set; }
        public string? AccountBranchName { get; set; }
        public string? AccountNumber { get; set; }
        public string? AccountIban { get; set; }
        public string? ManagerNationalID { get; set; }
        public string? ManagerNationalIDSerial { get; set; }
        public string? ManagerBirthDate { get; set; }
        public string? ManagerFirstName { get; set; }
        public string? ManagerLastName { get; set; }
        public string? ManagerFatherName { get; set; }
        public string ManagerCertNumber { get; set; }
        public string? ManagerCertSeries { get; set; }
        public string? ManagerCertSerial { get; set; }
        public DateTime ShopCreateDate { get; set; }
        public string? ShopAddress { get; set; }
        public string? PostUnit { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
        public string Postnode { get; set; }
        public int CompanyPricePlanID { get; set; }
        public int CompanyDiscountPercent { get; set; }
        public int ShopDiscountPercent { get; set; }
    }
}
