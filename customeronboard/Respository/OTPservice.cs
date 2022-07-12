using System;

namespace customeronboard.Respository
{
    public class OTPservice
    {
        public static string OTPServiceExtensions(string number)
        {
            var otp = string.Empty;

            if (string.IsNullOrEmpty(number))
            {
                return "invalid Number";
            }
            else
            {
                var random = new Random();
                otp = random.Next(3, 6).ToString();
            }

            return otp;
        }
    }
}
