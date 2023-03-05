using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Contracts;

/// <summary>
/// ضمانتنامه های قرارداد های لیزینگ
/// </summary>
public class ContractLeasingWarranty : BaseEntity<int>
{
    /// <summary>
    /// شناسه قرارداد لیزینگ
    /// </summary>
    public int ContractLeasingId { get; set; }
    /// <summary>
    /// قرارداد لیزینگ
    /// </summary>
    public ContractLeasing ContractLeasing { get; set; }
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
    public string? Description { get; set; }
}


