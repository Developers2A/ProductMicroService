﻿using Postex.Contract.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Features.Contracts.Commands.CreateContractCommand
{
    public class CreateContractCommand:ITransactionRequest
    {
        public string ContractNo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RegisterDate { get; set; }       
        public int? CustomerId { get; set; }
        public bool IsActive { get; set; }
    }
}
