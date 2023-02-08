namespace Postex.UserManagement.Application.Dtos.Users
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Mobile { get; set; }
        public bool IsActive { get; set; }
    }
}
