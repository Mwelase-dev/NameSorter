namespace NameSorter.Models
{
    public class PersonName
    {
        public List<string> GivenNames { get; }
        public string LastName { get; }

        public PersonName(string fullName)
        {
            var parts = fullName.Split(' ');
            if (parts.Length < 2 || parts.Length > 4)
                throw new ArgumentException("Name must have 1–3 given names and 1 last name.");

            LastName = parts.Last();
            GivenNames = parts.Take(parts.Length - 1).ToList();
        }

        public override string ToString()
        {
            return string.Join(" ", GivenNames) + " " + LastName;
        }
    }
}
