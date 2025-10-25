using NameSorter.Models;

namespace NameSorter.Services;

public interface INameSortingService
{
    IEnumerable<Person> SortNames(IEnumerable<Person> people);
}
