namespace Postex.Product.Application.Dtos.CourierStatus
{
    public class CourierStatusMappingDto
    {
        public int Id { get; set; }
        public int CourierId { get; set; }
        public int StatusId { get; set; }

        /// <summary>
        /// کد پنج رقمی وضعیت پستکس
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// شرح وضعیت پستکس
        /// </summary>
        public string StatusName { get; set; }

        /// <summary>
        /// کد وضعیت کوریر
        /// </summary>
        public string CourierStatusCode { get; set; }

        /// <summary>
        ///  شرح وضعیت کوریر
        /// </summary>
        public string CourierStatusName { get; set; }
    }
}
