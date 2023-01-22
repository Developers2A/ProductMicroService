using Postex.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Domain
{
    public class ContractLeasing:BaseEntity<int>
    {
        /// <summary>
        /// کد مشتری
        /// 
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// مبلغ لیزینگ
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// نرخ بازگشت
        /// </summary>
        public double ReturnRate { get; set; }
        /// <summary>
        /// نرخ برداشت
        /// </summary>
        public double WithdrawRate { get; set; }
        /// <summary>
        /// نرخ واریز روزانه
        /// </summary>
        public int DailyDepositRateCeiling { get; set; }
        /// <summary>
        /// سقف واریز روزانه
        /// </summary>
        public double DailyDepositeRate { get; set; }
        /// <summary>
        ///وضعیت فعال بودن
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// لیست ضمانتنامه ها
        /// </summary>
        public List<ContractLeasingWarranty> Warranties { get; set; }

    }
}
