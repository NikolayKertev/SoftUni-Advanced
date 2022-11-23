using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Models.Interfaces
{
    interface ISmartphone : IStationaryPhone
    {
        public string Browse(string url);
    }
}
