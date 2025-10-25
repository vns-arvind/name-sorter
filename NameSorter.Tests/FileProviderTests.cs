using Moq;
using NameSorter.Models;
using NameSorter.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.Tests
{
    public class FileProviderTests
    {
        [Test]
        public void FileReader_ReadContent()
        {
            var inputLines = new[] { "Vaughn Lewis", "Marin Alvarez", "Beau Tristan Bentley" };
            
            var mockFileProvider = new Mock<IFileProvider>();
            mockFileProvider.Setup(f => f.ReadAllLines("input.txt")).Returns(inputLines);

            var readLines = mockFileProvider.Object.ReadAllLines("input.txt");

            Assert.That(readLines.First(), Is.EqualTo("Vaughn Lewis"));
        }

        [Test]
        public void FileReader_WriteContent()
        {
            var inputLines = new[] { "Vaughn Lewis", "Marin Alvarez", "Beau Tristan Bentley" };

            var mockFileProvider = new Mock<IFileProvider>();
            mockFileProvider.Setup(f => f.ReadAllLines("input.txt")).Returns(inputLines);

            var writtenLines = new List<string>();
            mockFileProvider.Setup(f => f.WriteAllLines("output.txt", It.IsAny<IEnumerable<string>>()))
                            .Callback<string, IEnumerable<string>>((_, lines) => writtenLines.AddRange(lines));

            mockFileProvider.Object.WriteAllLines("output.txt", inputLines);

            Assert.That(writtenLines.First(), Is.EqualTo("Vaughn Lewis"));
        }
    }
}
