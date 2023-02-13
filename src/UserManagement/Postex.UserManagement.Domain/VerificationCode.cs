using Postex.SharedKernel.Domain;

namespace Postex.UserManagement.Domain
{
    public class VerificationCode : BaseEntity<int>
    {
        public int? UserId { get; set; }
        public int Code { get; set; }
        public string Mobile { get; set; }
        public bool IsUsed { get; set; }
    }
}
