using NameSorter.Interfaces;
using NameSorter.Models;

namespace NameSorter.Services
{
    public class NameSortingService : INameSortingService
    {
        public IEnumerable<PersonName> Sort(IEnumerable<PersonName> names)
        {
            return names
                .OrderBy(n => n.LastName)
                .ThenBy(n => string.Join(" ", n.GivenNames));
        }
    }
}
