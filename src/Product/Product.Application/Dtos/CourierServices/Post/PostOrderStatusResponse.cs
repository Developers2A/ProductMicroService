using System;

namespace Product.Application.Dtos.Post
{
    public class PostOrderStatusResponse
    {
        public string ParcelCode { get; set; }
        public int ParcelStatusID { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
