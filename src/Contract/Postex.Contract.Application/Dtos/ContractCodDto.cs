﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Dtos
{
    public class ContractCodDto
    {
        public int Id { get; set; }
        public int ContractInfoId { get; set; }
        public int FromValue { get; set; }
        public int ToValue { get; set; }
        public Double FixedPercent { get; set; }
        public int FixedValue { get; set; }
        public string Description { get; set; }
        public bool IsActice { get; set; }
        public string LevelPrice { get; set; }
    }
}
