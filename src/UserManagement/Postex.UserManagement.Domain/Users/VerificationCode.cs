using Postex.SharedKernel.Domain;

namespace Postex.UserManagement.Domain.Users;

public class VerificationCode : BaseEntity<int>
{
    public Guid? UserId { get; set; }
    public int Code { get; set; }
    public string Mobile { get; set; }
    public bool IsUsed { get; set; }
    public VerificationCodeType VerificationCodeType { get; set; }
}
