using NameSorter.Models;
using NameSorter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.Tests
{
    public class NameSortingServiceTests
    {
        [Test]
        public void NameSortingService_SortsByLastName()
        {
            var service = new NameSortingService();
            var names = new[] { new Person("Jane Doe"), new Person("John Smith") };
            var sorted = service.SortNames(names).ToList();
            Assert.That(sorted[0].ToString(), Is.EqualTo("Jane Doe"));
            Assert.That(sorted[1].ToString(), Is.EqualTo("John Smith"));
        }

        [Test]
        public void NameSortingService_SameLastName_SortsByGivenNames()
        {
            var service = new NameSortingService();
            var names = new[] {new Person("Beau Tristan Bentley"), new Person("Adonis Julius Bentley")};

            var sorted = service.SortNames(names).ToArray();

            Assert.That(sorted[0].ToString(), Is.EqualTo("Adonis Julius Bentley"));
            Assert.That(sorted[1].ToString(), Is.EqualTo("Beau Tristan Bentley"));
        }
    }
}
