using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Dtos.CourierServices.Chapar
{
    /// <summary>
    /// مدل خروجی متد پیگیری بارنامه یا کالا 
    ///<para>Status اگر true باشد تابع به درستی انجام شده است در غیر این صورت تابع به هر دلیل خطا داده است</para>
    ///<para>CodeStatus کد خطای برگشتی</para>
    ///<para>Message متن برگشتی</para>
    /// <para>objects آبجکت خروجی</para>
    /// </summary>
    public class ChaparTrackingResponse
    {
        public bool Status { get; set; }
        public int CodeStatus { get; set; }
        public string Message { get; set; }
        public ObjectsTracking objects { get; set; }
    }
    public class Temp_Result_Chapar_Tracking
    {
        public bool result { get; set; }
        public string message { get; set; }
        public ObjectsTracking objects { get; set; }
    }
    public class ObjectsTracking
    {
        public ChaparTrackingOrder order { get; set; }
    }
    /// <summary>
    /// مدل سفارش در متد پیگیری محموله-بارنامه-کالا
    /// <para>delivered_to مکان </para>
    /// <para>delivery_time زمان</para>
    /// <para>signature امضاء</para>
    /// <para>geo مکتن جغرافیایی</para>
    /// <para>history لیست تاریخچه اتفاقات برروی محموله</para>
    /// <para>origin مبدا</para>
    /// <para>dest مقصد</para>
    /// <para>price مدل قیمت</para>
    /// 
    /// </summary>
    public class ChaparTrackingOrder
    {
        public string delivered_to { get; set; }
        public string delivery_time { get; set; }
        public string signature { get; set; }
        public ChaparTrackingGeo geo { get; set; }
        public List<ChaparTrackingHistoryResponse> history { get; set; }
        public string origin { get; set; }
        public string dest { get; set; }
    }
    /// <summary>
    /// مدل جزییات مبلغ فاکتور یا هزیته پست
    /// <para>shipping هزینه پستی</para>
    /// <para>service هزینه خدمات(مثلا دریافت پول)</para>
    /// <para>packing هزینه بسته بندی</para>
    /// <para>extra_shipping_origin</para>
    /// <para>extra_shipping_destination</para>
    /// <para>insurance هزینه بیمه</para>
    /// <para>fuel</para>
    /// <para>vat مالیات</para>
    /// <para>total مبلغ کل کرایع</para>
    /// </summary>
    public class ChaparTrackingPrice
    {
        public string shipping { get; set; }
        public string service { get; set; }
        public string packing { get; set; }
        public string extra_shipping_origin { get; set; }
        public string extra_shipping_destination { get; set; }
        public string insurance { get; set; }
        public string fuel { get; set; }
        public string vat { get; set; }
        public string total { get; set; }
    }
    /// <summary>
    /// مدل یک عملیات یا تاریخچه برروی محموله
    /// <para>timestamp_date کد یکتای تاریخ</para>
    /// <para>date تاریخ فارسی</para>
    /// <para>status وضعبت</para>
    /// <para>loc مکان</para>
    /// <para>مثلا</para>
    /// "timestamp_date": 1565539200,</para>
    ///  "date": "1398/05/20",</para>
    ///  "status": "OK (بار به صورت صحیح و سالم تحویل شد)",</para>
    ///  "loc": null</para>
    /// </summary>
    public class ChaparTrackingHistoryResponse
    {
        public int timestamp_date { get; set; }
        public string date { get; set; }
        public string status { get; set; }
        public string loc { get; set; }
    }

}
