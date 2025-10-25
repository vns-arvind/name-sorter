
using NameSorter.Models;
using NameSorter.Services;
using NameSorter.Utilities;

if (args.Length < 2)
{
    Console.WriteLine(@"Please provide input (unsorted name) and output path. e.g. c:\test\input.txt, c:\test\output.txt");
    return;
}

var inputFilePath = args[0];
var outputFilePath = args[1];

try
{
    var fileProvider = new FileProvider();

    var names = fileProvider.ReadAllLines(inputFilePath)
                          .Select(line => new Person(line));

    var sorter = new NameSortingService();
    var sortedNames = sorter.SortNames(names);

    foreach (var person in sortedNames)
        Console.WriteLine(person);

    fileProvider.WriteAllLines(outputFilePath, sortedNames.Select(p => p.ToString()));
    Console.WriteLine("Sorted names written to output file");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}