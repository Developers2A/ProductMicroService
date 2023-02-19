using Postex.ProfileManagement.Domain;
using Postex.SharedKernel.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.ProfileManagement.Application.Dtos
{
    public class CustomerCodDto
    {
        public int Id { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string BirthDate { get; set; }
        public string NationalIDSerial { get; set; }
        public string AccountNumber { get; set; }
        public string AccountSheba { get; set; }
        public string BankBranchName { get; set; }
        public int PostUnitId { get; set; }
        public int PostNodeId { get; set; }
        public DateTime ExpireDate { get; set; }
        public string ExpireDate_P => ExpireDate.ToPersianDate();
        public bool IsActive { get; set; }
        public bool IsAdminAccept { get; set; }
        public int PostShopId { get; set; }
        public int CollectType { get; set; }
    }
}
