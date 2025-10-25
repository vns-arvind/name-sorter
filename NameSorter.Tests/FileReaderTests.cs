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
    public class FileReaderTests
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
    }
}
