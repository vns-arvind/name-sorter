using System;

namespace NameSorter.Tests
{
    public class PersonTests
    {

        [Test]
        public void Person_Construct_FromFullName_SetsLastNameAndGivenNames()
        {
            var p = new Person("Adonis Julius Archer");
            Assert.Equals("Archer", p.LastName);
            Assert.Equals(new[] { "Adonis", "Julius" }, p.GivenNames);
            Assert.Equals("Adonis Julius Archer", p.ToString());
        }
    }
}