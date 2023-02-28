using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Postex.Product.Application.Dtos.ServiceProviders.Kbk.Dtos
{
    public class KbkTrackRequest
    {
        public string ApiCode { get; set; }

        public string ShipmentCode { get; set; }
    }
}
