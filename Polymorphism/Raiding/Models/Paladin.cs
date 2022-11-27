using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Paladin : Healer
    {
        public Paladin(string name) 
            : base(name)
        {
            Power = 100;
        }
    }
}
