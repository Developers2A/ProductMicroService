using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractLeasingWarranties.Commands.Create
{
    public class CreateContractLeasingWarrantyCommand : ITransactionRequest<ContractLeasingWarrantyDto>
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
