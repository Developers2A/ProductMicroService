using System.Collections.Generic;

namespace Product.Application.Dtos.Chapar
{
    public class ChaparBulkHistoryReportResponse
    {
        public bool Status { get; set; }
        public int CodeStatus { get; set; }
        public string Message { get; set; }
        public ObjectsBulkHistoryReport objects { get; set; }
    }
    public class Temp_Result_Chapar_BulkHistoryReport
    {
        public bool result { get; set; }
        public string message { get; set; }
        public ObjectsBulkHistoryReport objects { get; set; }
    }
    /// <summary>
    /// مدل خروجی تاریخچه هر یک از محموله های درخواستی
    /// <para>time زمان</para>
    /// <para>date تاریخ</para>
    /// <para>status کد وضعیت</para>
    /// <para>status_note توضیحات فارسی وضعیت</para>
    /// <para>tracking کد بارنامه</para>
    /// <para>reference شناسه محلی</para>
    /// <para>به طورمثال</para>
    /// <para>time: "09:21",</para>
    ///  <para>date": "2019-09-17",</para>
    ///  <para>status": "D01",</para>
    ///  <para>status_note": "بار در سیستم ورود اطلاعات شد",</para>
    ///  <para>tracking": "913001011",</para>
    ///  <para>reference": "19320"</para>
    ///  
    /// </summary>
    public class HistoryBulkHistoryReport
    {
        public string time { get; set; }
        public string date { get; set; }
        public string status { get; set; }
        public string status_note { get; set; }
        public string tracking { get; set; }
        public string reference { get; set; }
    }
    /// <summary>
    /// لیستی از تاریخچه محموله ها
    /// </summary>
    public class ObjectsBulkHistoryReport
    {
        public List<HistoryBulkHistoryReport> history { get; set; }
    }
}
