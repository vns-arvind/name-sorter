using NameSorter.Models;
using System;

namespace NameSorter.Tests
{
    public class PersonTests
    {

        [Test]
        public void Person_Construct_FromFullName_SetsLastNameAndGivenNames()
        {
            var p = new Person("Adonis Julius Archer");
            Assert.That(p.LastName, Is.EqualTo("Archer"));
            Assert.That(p.GivenNames, Is.EqualTo(new[] { "Adonis", "Julius" }));
            Assert.That(p.ToString(), Is.EqualTo("Adonis Julius Archer"));
        }
        [Test]
        public void Person_TrimsExtraWhitespace()
        {
            var p = new Person("  Marin   Alvarez  ");
            Assert.That(p.ToString(), Is.EqualTo("Marin Alvarez"));
        }
    }
}