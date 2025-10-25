using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.Models
{
    public class Person
    {
        public string[] GivenNames { get; }
        public string LastName { get; }

        public Person(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Name cannot be empty", nameof(fullName));

            var parts = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2)
                throw new ArgumentException("A name must have at least one given name and a last name.");

            LastName = parts[^1];
            GivenNames = parts[..^1];
        }

        public override string ToString() => string.Join(" ", GivenNames.Append(LastName));
    }
}



