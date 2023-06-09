﻿using Postex.UserManagement.Application.Contracts;

namespace Postex.UserManagement.Application.Features.Messages.Commands;

public class SendSmsCommand : ITransactionRequest
{
    public string Mobile { get; set; }
    public int Template { get; set; }
    public Dictionary<string, string>? Parameters { get; set; }
}
