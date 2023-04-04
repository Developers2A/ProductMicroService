using Postex.UserManagement.Application.Contracts;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Features.UserCods.Commands.Create
{
    public class CreateUserCodCommand : ITransactionRequest<UserCod>
    {
        public Guid UserId { get; set; }
        public string BirthDate { get; set; }
        public string NationalIDSerial { get; set; }
        public string AccountNumber { get; set; }
        public string AccountSheba { get; set; }
        public string BankBranchName { get; set; }
        public int PostUnitId { get; set; }
        public int PostNodeId { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdminAccept { get; set; }
        public int PostShopId { get; set; }
        public int CollectType { get; set; }
    }
}
