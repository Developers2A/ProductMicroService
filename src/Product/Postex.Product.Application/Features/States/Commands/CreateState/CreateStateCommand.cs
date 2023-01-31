﻿using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.States.Commands.CreateState
{
    public class CreateStateCommand : ITransactionRequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string EnglishName { get; set; }
    }
}