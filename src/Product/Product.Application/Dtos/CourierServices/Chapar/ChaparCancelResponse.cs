using System.Collections.Generic;

namespace Product.Application.Dtos.Chapar
{
    public class ChaparCancelResponse
    {
        public bool Status { get; set; }
        public int CodeStatus { get; set; }
        public string Message { get; set; }
        public Detail_Chapar_Cancel Detail_Chapar_Cancel { get; set; }

    }
    public class Detail_Chapar_Cancel
    {
        public bool result { get; set; }
        public string message { get; set; }
        public Objects1 objects { get; set; }
    }
    public class Objects1
    {
        public List<object> order { get; set; }
    }
}
