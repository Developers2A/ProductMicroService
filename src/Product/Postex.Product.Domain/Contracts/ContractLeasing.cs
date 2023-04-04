using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Contracts
{
    public class ContractLeasing : BaseEntity<int>
    {
        /// <summary>
        /// کد مشتری
        /// 
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// مبلغ لیزینگ
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// نرخ بازگشت
        /// </summary>


        public double ReturnRate { get; set; }
        /// <summary>
        /// تاریخ شروع
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// تاریخ پایان
        /// </summary>
        public DateTime EndDate { get; set; }
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
        public string? Description { get; set; }
        /// <summary>
        /// لیست ضمانتنامه ها
        /// </summary>
        public List<ContractLeasingWarranty> Warranties { get; set; }
    }
}
