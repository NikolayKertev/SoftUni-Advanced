using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models.Interfaces
{
    public interface IBirthable
    {
        public string Day { get; }
        public string Month { get; }
        public string Year { get; }
    }
}
