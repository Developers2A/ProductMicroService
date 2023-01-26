using Postex.SharedKernel.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Dtos
{
    public class ContractLeasingDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int CustomerId { get; set; }
        public int Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }   
        public double ReturnRate { get; set; }
        public double WithdrawRate { get; set; }
        public int DailyDepositRateCeiling { get; set; }
        public double DailyDepositeRate { get; set; }       
        public string Description { get; set; }
        public string StartDate_P => StartDate.ToPersianDate();
        public string EndDate_P => EndDate.ToPersianDate();
    }
}
