﻿using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.Statuses.Commands.CreateStatus
{
    public class CreateStatusCommand : ITransactionRequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public string Type { get; set; }
    }
}
