﻿using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Contratcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.Contratcs.ContractLeasingWarranties.Commands.Update
{
    public class UpdateContractLeasingWarrantyCommand : ITransactionRequest<ContractLeasingWarrantyDto>
    {
        public int Id { get; set; }

        public int ContractLeasingId { get; set; }

        public string WarrantyNo { get; set; }

        public int WarrantyAmount { get; set; }

        public DateTime WarrantyReqistrationDate { get; set; }

        public DateTime WarrantyEndDate { get; set; }

        public string BankName { get; set; }

        public string Description { get; set; }

    }
}
