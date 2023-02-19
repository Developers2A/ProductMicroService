using Postex.SharedKernel.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Dtos
{
    public class ContractLeasingWarrantyDto
    {
        public int Id { get; set; }
        /// <summary>
        /// شناسه قرارداد لیزینگ
        /// </summary>
        public int ContractLeasingId { get; set; }
       
        /// <summary>
        /// شماره ضمانتنامه
        /// </summary>
        public string WarrantyNo { get; set; }
        /// <summary>
        /// مبلغ ضمانتنامه
        /// </summary>
        public int WarrantyAmount { get; set; }
        /// <summary>
        /// تاریخ ثبت ضمانتنامه
        /// </summary>
        public DateTime WarrantyReqistrationDate { get; set; }
        /// <summary>
        /// تاریخ پایان ضمانتنامه
        /// </summary>
        public DateTime WarrantyEndDate { get; set; }
        /// <summary>
        /// بانک صادر کننده 
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// تاریخ ثبت شمسی
        /// </summary>
        public string WarrantyReqistrationDate_P => WarrantyReqistrationDate.ToPersianDate();
        /// <summary>
        /// تاریخ پایان شمسی
        /// </summary>
        public string WarrantyEndDate_P => WarrantyEndDate.ToPersianDate();
    }
}
