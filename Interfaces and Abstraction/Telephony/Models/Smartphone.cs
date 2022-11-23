namespace Telephony.Models
{
    using Interfaces;
    using System.Linq;
    using Telephony.Exceptions;

    public class SmartPhone : ISmartphone
    {
        public string Call(string phoneNumber)
        {
            if (phoneNumber.All(ch => char.IsDigit(ch)))
            {
                return $"Calling... {phoneNumber}";
            }

            throw new InvalidPhoneNumberException();
        }

        public string Browse(string url)
        {
            if (url.All(ch => !char.IsDigit(ch)))
            {
                return $"Browsing: {url}!";
            }

            throw new InvalidURLException();
        }
    }
}
