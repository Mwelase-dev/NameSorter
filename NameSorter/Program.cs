using NameSorter.Interfaces;
using NameSorter.Models;
using NameSorter.Services;

class Program
{
    static void Main()
    {
        string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
        string inputFile = Path.Combine(projectRoot, "unsorted-names-list.txt");
        string outputFile = Path.Combine(projectRoot, "sorted-names-list.txt");


        if (!File.Exists(inputFile))
        {
            Console.WriteLine("File 'unsorted-names-list.txt' not found in the application directory.");
            return;
        }

        try
        {
            var rawNames = File.ReadAllLines(inputFile);
            var personNames = new List<PersonName>();

            foreach (var name in rawNames)
            {
                personNames.Add(new PersonName(name));
            }

            INameSortingService sorter = new NameSortingService();
            var sortedNames = sorter.Sort(personNames);

            File.WriteAllLines(outputFile, sortedNames.Select(n => n.ToString()));

            Console.WriteLine("Names sorted successfully.");

            foreach(var name in sortedNames)
            {
                Console.WriteLine(name);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    
    }
}
