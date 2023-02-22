﻿using Postex.Product.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.ContractLeasingWarranties.Command.Create
{
    public class CreateContractLeasingWarrantyCommand : ITransactionRequest
    {
        public int ContractLeasingId { get; set; }

        public string WarrantyNo { get; set; }

        public int WarrantyAmount { get; set; }

        public DateTime WarrantyReqistrationDate { get; set; }

        public DateTime WarrantyEndDate { get; set; }

        public string BankName { get; set; }

        public string Description { get; set; }


    }
}