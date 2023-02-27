using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Dtos.Contratcs
{
    public class ContractCourierDto
    {
        public int Id { get; set; }
        public int ContractInfoId { get; set; }
        public int CourierServiceId { get; set; }
        public int FixedDiscount { get; set; }
        public double PercentDiscount { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public string LevelPrice { get; set; }
    }
}
