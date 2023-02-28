using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Common;

public class BoxType : BaseEntity<int>
{
    public string Name { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }
    public double Length { get; set; }
}
