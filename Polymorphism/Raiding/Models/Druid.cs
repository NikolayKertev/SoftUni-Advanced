using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Druid : Healer
    {
        public Druid(string name) 
            : base(name)
        {
            Power = 80;
        }
    }
}
