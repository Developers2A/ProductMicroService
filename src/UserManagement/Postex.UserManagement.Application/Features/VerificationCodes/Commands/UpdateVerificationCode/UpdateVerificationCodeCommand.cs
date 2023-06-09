﻿using Postex.UserManagement.Application.Contracts;

namespace Postex.UserManagement.Application.Features.VerificationCodes.Commands.UpdateVerificationCode;

public class UpdateVerificationCodeCommand : ITransactionRequest
{
    public string Mobile { get; set; }
    public int Code { get; set; }
    public bool IsUsed { get; set; }
    public Guid? UserId { get; set; }
}
