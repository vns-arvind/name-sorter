using NameSorter.Models;

namespace NameSorter.Services;

public class NameSortingService : INameSortingService
{
    public IEnumerable<Person> SortNames(IEnumerable<Person> people)
    {
        return people
            .OrderBy(p => p.LastName)
            .ThenBy(p => string.Join(" ", p.GivenNames))
            .ToList();
    }
}
