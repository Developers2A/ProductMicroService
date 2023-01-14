using Postex.SharedKernel.Domain;
using System.ComponentModel.DataAnnotations;

namespace Postex.Contract.Domain;

public class Customer : BaseEntity<int>
{
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    [MaxLength(20)]
    public string CustomerCode { get; set; }
}
