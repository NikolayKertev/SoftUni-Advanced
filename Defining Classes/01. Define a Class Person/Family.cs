﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            this.people = new List<Person>();
        }


        public void AddMember(Person member)
        {
            this.people.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.people
                .OrderByDescending(p => p.Age)
                .FirstOrDefault();
        }

        public List<Person> OlderThan()
        {
            List<Person> olderThanThirty = new List<Person>();
            foreach (var person in people)
            {
                if (person.Age > 30)
                {
                    olderThanThirty.Add(person);
                }
            }
            return olderThanThirty.OrderBy(p => p.Name).ToList();
        }
    }
}
