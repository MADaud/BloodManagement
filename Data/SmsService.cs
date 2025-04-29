using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace BloodDonationbd.Data
{
    public class SmsService
    {
        private readonly IConfiguration _configuration;
        public SmsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SendSms(string phoneNumber, string message)
        {
            var accountSid = _configuration["Twilio:AccountSID"];
            var authToken = _configuration["Twilio:AuthToken"];
            var fromPhoneNumber = _configuration["Twilio:FromPhoneNumber"];

            TwilioClient.Init(accountSid, authToken);
            MessageResource.Create(
                to: new PhoneNumber(phoneNumber),
                from: new PhoneNumber(fromPhoneNumber),
                body: message
            );
        }
    }
}
