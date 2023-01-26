using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Dtos.CourierServices.Chapar
{
    public class ChaparCreateManifestResponse
    {
        public bool result { get; set; }
        public string message { get; set; }
        public ObjectsCreateManifest objects { get; set; }
    }
    public class ObjectsCreateManifest
    {
        public object success { get; set; }
        public List<object> error { get; set; }
        public string runsheet { get; set; }
    }
}
