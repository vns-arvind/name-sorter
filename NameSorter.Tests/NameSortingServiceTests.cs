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
    }
}
