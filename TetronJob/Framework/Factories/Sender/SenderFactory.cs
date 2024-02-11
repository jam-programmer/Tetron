using Application.Reports.Setting;
using Application.Reports.User;
using Kavenegar.Models.Enums;
using Kavenegar;
using Kavenegar.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Framework.Factories.Sender
{
    public class SenderFactory : ISenderFactory
    {
        private readonly ISettingReport _setting;
        private readonly IUserReport _userReport;

        public SenderFactory(ISettingReport setting, IUserReport userReport)
        {
            _setting = setting;
            _userReport = userReport;
        }
        public async Task Welcome(string name, string phoneNumber)
        {
            var smsInfo = await _setting.GetSettingAsync();
            KavenegarApi api = new KavenegarApi(smsInfo!.SmsKey);
            var result =  api.VerifyLookup(phoneNumber,
                "کاربر", null, null, null, name, "welcome",
                VerifyLookupType.Sms);
        }

       
        public async Task Accept(string name, string phoneNumber)
        {
            var smsInfo = await _setting.GetSettingAsync();
       
            var sender = smsInfo!.SmsKey;
            KavenegarApi api = new KavenegarApi(smsInfo.SmsKey);
        
            var result =  api.VerifyLookup(phoneNumber, "اطلاعیه:", 
                null, null, null, name, "accept", VerifyLookupType.Sms);

        }

        public async Task Cancel(string name, string phoneNumber)
        {
            var smsInfo = await _setting.GetSettingAsync();
           
            var sender = smsInfo!.SmsKey;
            KavenegarApi api = new KavenegarApi(smsInfo.SmsKey);

            var result = api.VerifyLookup(phoneNumber, "اطلاعیه:",
                null, null, null, name, "Canecl", VerifyLookupType.Sms);
        }
    }
}
