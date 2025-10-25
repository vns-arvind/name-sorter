using NameSorter.Models;
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
            Assert.That("Jane Doe", sorted[0].ToString());
            Assert.That("John Smith", sorted[1].ToString());
        }
    }
}
