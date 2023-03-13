using Kavenegar;
using Kavenegar.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Settings;

namespace Postex.Notification.Application.Services;

public class SmsSender : ISmsSender
{
    private string smsApiKey { get; set; }
    public KavenegarApi kavenegar { get; set; }
    private readonly IConfiguration _configuration;

    public SmsSender(ILogger<SmsSender> logger, IConfiguration configuration)
    {
        _configuration = configuration;
        smsApiKey = _configuration.GetSection(nameof(SmsSetting)).Get<SmsSetting>().KavenegarApiKey;
        kavenegar = new KavenegarApi(smsApiKey);
    }

    public async Task<SendResult> SendSms(List<string> mobiles, string message)
    {
        SendResult result = new();

        try
        {
            foreach (var mobile in mobiles)
            {
                if (!ValidateMobile(mobile))
                    continue;

                return await kavenegar.Send("", mobile, message);
            }
        }
        catch (Exception ex)
        {
            throw new AppException(ex.Message);
        }
        return result;
    }

    private bool ValidateMobile(string mobile)
    {
        if (string.IsNullOrEmpty(mobile))
        {
            return false;
        }

        if (mobile.Length != 11)
        {
            return false;
        }

        if (!mobile.StartsWith("0"))
        {
            return false;
        }

        return true;
    }

    public async Task<SendResult> SendSms(List<string> mobiles, string template, Dictionary<string, string> values)
    {
        SendResult result = new();
        foreach (var mobile in mobiles)
        {
            try
            {
                if (!ValidateMobile(mobile))
                    continue;

                var parameters = values.Select(v => v.Value).ToList();

                if (values.Count == 1)
                {
                    return await kavenegar.VerifyLookup(mobile.ToString(), parameters[0], template.ToString());
                }
                if (values.Count == 2)
                {
                    return await kavenegar.VerifyLookup(mobile.ToString(), parameters[0], parameters[1], null, template.ToString());
                }
                if (values.Count == 3)
                {
                    return await kavenegar.VerifyLookup(mobile.ToString(), parameters[0], parameters[1], parameters[2], template.ToString());
                }
                if (values.Count == 4)
                {
                    return await kavenegar.VerifyLookup(mobile.ToString(), parameters[0], parameters[1], parameters[2], parameters[3], template.ToString());
                }
                if (values.Count == 5)
                {
                    return await kavenegar.VerifyLookup(mobile.ToString(), parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], template.ToString(), Kavenegar.Core.Models.Enums.VerifyLookupType.Sms);
                }

                //if (result!.Status == 1 || result.Status == 2 || result.Status == 4 || result.Status == 5 || result.Status == 10)
                //{
                //    isSend = true; ;
                //}
                return result;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
        return result;
    }
}
