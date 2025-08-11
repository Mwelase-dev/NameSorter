using NameSorter.Models;
using NameSorter.Services;

namespace NameSorter.Tests
{
    public class NameSortingServiceTests
    {
        [Fact]
        public void Sort_SortsByLastNameThenGivenNames()
        {
            // Arrange
            var names = new List<PersonName>
            {
                new PersonName("Janet Parsons"),
                new PersonName("Vaughn Lewis"),
                new PersonName("Adonis Julius Archer"),
                new PersonName("Shelby Nathan Yoder"),
                new PersonName("Marin Alvarez"),
                new PersonName("London Lindsey"),
                new PersonName("Beau Tristan Bentley"),
                new PersonName("Leo Gardner"),
                new PersonName("Hunter Uriah Mathew Clarke"),
                new PersonName("Mikayla Lopez"),
                new PersonName("Frankie Conner Ritter")
            };

            var expectedOrder = new List<string>
            {
                "Marin Alvarez",
                "Adonis Julius Archer",
                "Beau Tristan Bentley",
                "Hunter Uriah Mathew Clarke",
                "Leo Gardner",
                "Vaughn Lewis",
                "London Lindsey",
                "Mikayla Lopez",
                "Janet Parsons",
                "Frankie Conner Ritter",
                "Shelby Nathan Yoder",
            };

            var sorter = new NameSortingService();

            // Act
            var sorted = sorter.Sort(names).Select(n => n.ToString()).ToList();

            // Assert
            Assert.Equal(expectedOrder, sorted);
        }

        [Fact]
        public void PersonName_ThrowsException_WhenNameHasTooFewParts()
        {
            // Act & Assert
            Assert.Throws<System.ArgumentException>(() => new PersonName("Smith"));
        }

        [Fact]
        public void PersonName_ThrowsException_WhenNameHasTooManyParts()
        {
            // Act & Assert
            Assert.Throws<System.ArgumentException>(() => new PersonName("Anna Bella Maria Christina Lopez"));
        }
    }
}