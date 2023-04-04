namespace Postex.Product.Application.Dtos.Users
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string? NationalCode { get; set; }
        public string? IbanNumber { get; set; }
        public string Mobile { get; set; }
        public string PostalCode { get; set; }
        public bool isShahkarValidate { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
    }
}
