namespace Postex.Product.Application.Dtos.Customers
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string NationalCode { get; set; }
        public string Email { get; set; }
        public int MobileNo { get; set; }
        public string PostalCode { get; set; }
        public bool isShahkarValidate { get; set; }
        public Guid UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
