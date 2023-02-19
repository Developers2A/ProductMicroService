using Postex.Contract.Domain;
using Postex.SharedKernel.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Contract.Application.Dtos
{
    public class ContractInfoDto
    {
        public int Id { get; set; }
        public string ContractNo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RegisterDate { get; set; }      
        public Guid? CustomerId { get; set; }
        public int? CityId { get; set; }
        public int? ProvinceId { get; set; }
        public bool IsActive { get; set; }

        public string StartDate_P =>  StartDate.ToPersianDate();  
        public string EndDate_P => EndDate.ToPersianDate();
        public string RegisterDate_P => RegisterDate.ToPersianDate();

        public ICollection<ContractInsurance>? ContractInsurances { get; set; }
        public ICollection<ContractCod> ContractCods { get; set; }
        public ICollection<ContractBoxPrice> ContractBoxPrices { get; set; }
    }
}
