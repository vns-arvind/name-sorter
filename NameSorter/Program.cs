using Microsoft.Extensions.DependencyInjection;
using NameSorter;
using NameSorter.Services;
using NameSorter.Utilities;

if (args.Length < 2)
{
    Console.WriteLine(@"Please provide input (unsorted name) and output path. e.g. c:\test\input.txt, c:\test\output.txt");
    return;
}

var inputFilePath = args[0];
var outputFilePath = args[1];

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
