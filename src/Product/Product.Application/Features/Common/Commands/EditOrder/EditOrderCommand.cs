﻿using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Common;

namespace Product.Application.Features.Common.Commands.EditOrder
{
    public class EditOrderCommand : ITransactionRequest<BaseResponse<EditOrderResponse>>
    {
        public int CourierCode { get; set; }
        public string ParcelId { get; set; }
        public string SenderMobile { get; set; }
        public string Content { get; set; }
        public string ReceiverFristName { get; set; }
        public string ReceiverLastName { get; set; }
        public string ReceiverMobile { get; set; }
        public string ReceiverPostCode { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverEmail { get; set; }
        public string ReceiverNationalCode { get; set; }
    }
}
