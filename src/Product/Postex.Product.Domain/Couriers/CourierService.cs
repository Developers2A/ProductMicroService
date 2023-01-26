using Postex.Product.Domain.Offlines;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Couriers
{
    public class CourierService : BaseEntity<int>
    {
        public int CourierId { get; set; }
        public Courier Courier { get; set; }
        public string Name { get; set; }
        public CourierServiceCode Code { get; set; }
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

        /// <summary>
        /// مبلغ اعلامی کوریر با کسر تخفیف است یا خیر
        /// </summary>
        public bool PriceHasDiscount { get; set; } //مبلغ اعلامی با کسر تخفیف است یا خیر 
        /// <summary>
        /// درصد تخفیف
        /// </summary>
        public double DiscountPercent { get; set; } //درصد تخفیف 

        /// <summary>
        /// مبلغ اعلامی با مالیات است یا خیر
        /// </summary>
        public bool PriceHasTax { get; set; } //قیمت اعلامی با مالیات است یا خیر

        /// <summary>
        /// عدد ثابتی که به عدد پایه پستی اضافه میگردد
        /// </summary>
        public long FixBasePrice { get; set; }

        /// <summary>
        /// درصد اضافه پستکس به مبلغ نهایی
        /// </summary>
        public double PostexPercent { get; set; }

        /// <summary>
        /// مبلغ اضافه پستکس به مبلغ نهایی
        /// </summary>
        public long PostexFixPrice { get; set; }
        public bool IsActive { get; set; }
        public string? Days { get; set; }
        public ICollection<CourierCod> CourierCods { get; set; }
        public ICollection<CourierInsurance> CourierInsurances { get; set; }
        public ICollection<CourierLimitValue> CourierLimitValues { get; set; }

        public ICollection<CourierCityMapping> CourierCityMappings { get; set; }
        public ICollection<CourierZonePriceTemplate> CourierZonePriceTemplates { get; set; }
    }
}
