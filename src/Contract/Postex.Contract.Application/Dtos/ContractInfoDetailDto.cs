using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Dtos
{
    public class ContractInfoDetailDto:ContractInfoDto
    {
        public List<ContractCodDto> Cod { get; set; }
    }
}
