using Microsoft.Extensions.DependencyInjection;
using NameSorter;
using NameSorter.Services;
using NameSorter.Utilities;

// Require only one argument: input file path
if (args.Length < 1)
{
    Console.WriteLine(@"Please provide input file path. Example: c:\test\unsorted-names.txt");
    return;
}

var inputFilePath = args[0];
// Always write to sorted-names-list.txt in the working directory
var outputFilePath = Path.Combine(Environment.CurrentDirectory, "sorted-names-list.txt");

// Setup DI
var services = new ServiceCollection()
    .AddSingleton<IFileProvider, FileProvider>()
    .AddSingleton<INameSortingService, NameSortingService>()
    .AddSingleton<NameSorterRunner>()
    .BuildServiceProvider();

// Run the program
try
{
    var runner = services.GetRequiredService<NameSorterRunner>();
    runner.Run(inputFilePath, outputFilePath);
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
