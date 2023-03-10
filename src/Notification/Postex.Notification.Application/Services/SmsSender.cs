using Kavenegar;
using Kavenegar.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Postex.SharedKernel.Settings;

namespace Postex.Notification.Application.Services;

public class SmsSender : ISmsSender
{
    private string smsApiKey { get; set; }
    public KavenegarApi kavenegar { get; set; }
    private readonly IConfiguration _configuration;

    public SmsSender(ILogger<SmsSender> logger)
    {
        smsApiKey = _configuration.GetSection(nameof(SmsSetting)).Get<SmsSetting>().KavenegarApiKey;
        kavenegar = new KavenegarApi(smsApiKey);
    }

    public async Task<bool> SendSmsWithMessage(string mobile, string message)
    {
        try
        {
            if (!ValidateMobile(mobile))
                return false;

            SendResult result = null;
            result = await kavenegar.Send("", mobile, message);

            if (result.Status == 1 || result.Status == 2 || result.Status == 4 || result.Status == 5 || result.Status == 10)
            {
                return true;
            }
            return false;
        }
        catch (Exception e)
        {
            return false;
        }
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

    public async Task<SendResult> SendSms(Dictionary<string, string> values, List<string> mobiles, string template)
    {
        SendResult result = new();
        foreach (var mobile in mobiles)
        {
            try
            {
                if (!ValidateMobile(mobile))
                    continue;

                var temp = values.Select(v => v.Value);
                var finalValues = temp.ToList();

                if (values.Count == 1)
                {
                    result = await kavenegar.VerifyLookup(mobile.ToString(), finalValues[0], template.ToString());
                }
                if (values.Count == 2)
                {
                    result = await kavenegar.VerifyLookup(mobile.ToString(), finalValues[0], finalValues[1], null, template.ToString());
                }
                if (values.Count == 3)
                {
                    result = await kavenegar.VerifyLookup(mobile.ToString(), finalValues[0], finalValues[1], finalValues[2], template.ToString());
                }
                if (values.Count == 4)
                {
                    result = await kavenegar.VerifyLookup(mobile.ToString(), finalValues[0], finalValues[1], finalValues[2], finalValues[3], template.ToString());
                }
                if (values.Count == 5)
                {
                    result = await kavenegar.VerifyLookup(mobile.ToString(), finalValues[0], finalValues[1], finalValues[2], finalValues[3], finalValues[4], template.ToString(), Kavenegar.Core.Models.Enums.VerifyLookupType.Sms);
                }

                //if (result!.Status == 1 || result.Status == 2 || result.Status == 4 || result.Status == 5 || result.Status == 10)
                //{
                //    isSend = true; ;
                //}
                return result;
            }
            catch (Exception)
            {
            }
        }
        return result;
    }
}
