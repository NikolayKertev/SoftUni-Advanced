using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Warrior : DamageDealer
    {
        public Warrior(string name) 
            : base(name)
        {
            Power = 100;
        }
    }
}
