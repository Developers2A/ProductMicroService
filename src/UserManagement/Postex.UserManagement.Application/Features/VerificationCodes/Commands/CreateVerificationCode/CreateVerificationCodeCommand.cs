﻿using Postex.UserManagement.Application.Contracts;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Features.VerificationCodes.Commands.CreateVerificationCode;

public class CreateVerificationCodeCommand : ITransactionRequest
{
    public string Mobile { get; set; }
    public Guid? UserId { get; set; }
    public VerificationCodeType VerificationCodeType { get; set; }
}
