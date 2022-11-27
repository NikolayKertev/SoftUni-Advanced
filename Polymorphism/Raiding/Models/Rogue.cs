using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Rogue : DamageDealer
    {
        public Rogue(string name) 
            : base(name)
        {
            Power = 80;
        }
    }
}
