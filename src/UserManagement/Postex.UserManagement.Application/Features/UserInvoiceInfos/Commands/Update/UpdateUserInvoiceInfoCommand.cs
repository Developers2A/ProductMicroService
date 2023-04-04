using Postex.UserManagement.Application.Contracts;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Features.UserInvoiceInfos.Commands.Update
{
    public class UpdateUserInvoiceInfoCommand : ITransactionRequest<UserInvoiceInfo>
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int AddressId { get; set; }
        public int TelNo { get; set; }
        public string NationalCode { get; set; }
        public string EconomicCode { get; set; }
    }
}
