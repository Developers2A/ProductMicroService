using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.PostShops.Commands.CreatePostShop
{
    public class CreatePostShopCommand : ITransactionRequest
    {
        public int ShopID { get; set; }
        public string PostalCode { get; set; }
        public int PostUnitID { get; set; }
        public int CityID { get; set; }
        public int PostnodeID { get; set; }
        public bool Enabled { get; set; }
        public DateTime ContractEndDate { get; set; }
        public int CollectTypeID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mob { get; set; }
        public string Email { get; set; }
        public string WebSiteURL { get; set; }
        public string AccountBank { get; set; }
        public string AccountBranchName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountIban { get; set; }
        public string AccountOwner { get; set; }
        public string ManagerNationalID { get; set; }
        public string ManagerNationalIDSerial { get; set; }
        public string ManagerBirthDate { get; set; }
    }
}
