namespace Postex.Product.Application.Dtos.CourierStatus
{
    public class CourierStatusMappingDto
    {
        public int Id { get; set; }
        public int CourierId { get; set; }
        public int StatusId { get; set; }

        /// <summary>
        /// کد وضعیت پستکس
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// وضعیت پستکس
        /// </summary>
        public string StatusName { get; set; }

        /// <summary>
        /// کد وضعیت کوریر
        /// </summary>
        public string CourierStatusCode { get; set; }

        /// <summary>
        ///  وضعیت کوریر
        /// </summary>
        public string CourierStatusName { get; set; }
    }
}
