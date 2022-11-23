using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Exceptions
{
    public class InvalidPhoneNumberException : Exception
    {
        private const string DEFAULT_MESSAGE = "Invalid number!";

        public InvalidPhoneNumberException()
            : base(DEFAULT_MESSAGE)
        {

        }

        public InvalidPhoneNumberException(string message)
            : base(message)
        {

        }
    }
}
