using NameSorter.Models;

namespace NameSorter.Interfaces
{
    public interface INameSortingService
    {
        IEnumerable<PersonName> Sort(IEnumerable<PersonName> names);
    }
}
