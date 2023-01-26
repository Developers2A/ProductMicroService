using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Dtos
{
    public class ContractCourierDto
    {
        public int Id { get; set; }
        public int ContractInfoId { get; set; }
        public int CourierId { get; set; }
        public int FixedDiscount { get; set; }
        public double PercentDiscount { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public string LevelPrice { get; set; }
    }
}
