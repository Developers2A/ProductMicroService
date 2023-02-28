using System;

namespace Postex.Product.Application.Dtos.ServiceProviders.Post
{
    public class PostOrderStatusResponse
    {
        public string ParcelCode { get; set; }
        public int ParcelStatusID { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
