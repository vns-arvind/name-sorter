using Moq;
using NameSorter.Services;
using NameSorter.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.Tests
{
    public class NameSorterRunnerTests
    {
        [Test]
        public void NameSorterRunner_ValidateFunctionality()
        {
            var inputLines = new[] { "Vaughn Lewis", "Marin Alvarez", "Beau Tristan Bentley" };

            var mockFileProvider = new Mock<IFileProvider>();
            mockFileProvider.Setup(f => f.ReadAllLines("input.txt")).Returns(inputLines);

            var writtenLines = new List<string>();
            mockFileProvider.Setup(f => f.WriteAllLines("output.txt", It.IsAny<IEnumerable<string>>()))
                            .Callback<string, IEnumerable<string>>((_, lines) => writtenLines.AddRange(lines));

            var sorter = new NameSortingService();
            var runner = new NameSorterRunner(mockFileProvider.Object, sorter);

            runner.Run("input.txt", "output.txt");

            var expected = new[] { "Marin Alvarez", "Beau Tristan Bentley", "Vaughn Lewis" };
            Assert.That(writtenLines.ToArray(), Is.EqualTo(expected));
        }

    }
}
