namespace Telephony.Models
{
    using Interfaces;
    using System;
    using System.Linq;
    using Telephony.Exceptions;

    public class StationaryPhone : IStationaryPhone
    {
        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(ch => char.IsDigit(ch)))
            {
                throw new InvalidPhoneNumberException();
            }

            return $"Dialing... {phoneNumber}";
        }
    }
}
