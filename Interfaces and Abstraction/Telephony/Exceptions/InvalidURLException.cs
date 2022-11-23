using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Exceptions
{
    public class InvalidURLException : Exception
    {
        private const string DEFAULT_MESSAGE = "Invalid URL!";

        public InvalidURLException()
            : base(DEFAULT_MESSAGE)
        {

        }

        public InvalidURLException(string message)
            : base(message)
        {

        }
    }
}
