﻿namespace Postex.UserManagement.Application.Dtos.Users
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string IbanNumber { get; set; }
        public string? Mobile { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
    }
}
