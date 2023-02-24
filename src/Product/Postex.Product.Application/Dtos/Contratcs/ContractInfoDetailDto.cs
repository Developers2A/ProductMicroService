using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Dtos.Contratcs
{
    public class ContractInfoDetailDto : ContractInfoDto
    {
        public List<ContractCodDto> Cod { get; set; }
    }
}
