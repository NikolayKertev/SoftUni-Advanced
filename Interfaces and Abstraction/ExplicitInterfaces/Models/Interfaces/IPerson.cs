using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces.Models.Interfaces
{
    public interface IPerson
    {
        string Name { get; }
        int Age { get; }

        public string GetName()
        {
            return Name;
        }

    }
}
