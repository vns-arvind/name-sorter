using NameSorter.Models;
using NameSorter.Services;
using NameSorter.Utilities;

namespace NameSorter
{
    public class NameSorterRunner
    {
        private readonly IFileProvider _fileProvider;
        private readonly INameSortingService _sorter;

        public NameSorterRunner(IFileProvider fileProvider, INameSortingService sorter)
        {
            _fileProvider = fileProvider;
            _sorter = sorter;
        }

        public void Run(string inputFilePath, string outputFilePath)
        {
            var names = _fileProvider.ReadAllLines(inputFilePath)
                                     .Select(line => new Person(line));

            var sortedNames = _sorter.SortNames(names);

            foreach (var person in sortedNames)
                Console.WriteLine(person);

            _fileProvider.WriteAllLines(outputFilePath, sortedNames.Select(p => p.ToString()));
            Console.WriteLine("Sorted names written to output file");
        }
    }
}
