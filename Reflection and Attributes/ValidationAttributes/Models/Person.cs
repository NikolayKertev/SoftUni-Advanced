namespace ValidationAttributes.Models
{
    using System;

    using Contracts;
    using Utilities.Attributes;

    class Person : IPerson
    {
        private const int MIN_AGE = 12;
        private const int MAX_AGE = 90;

        public Person(string name, int age)
        {
            FullName = name;
            Age = age;
        }

        [MyRequired]
        public string FullName { get; private set; }

        [MyRange(MIN_AGE, MAX_AGE)]
        public int Age { get; private set; }
    }
}
