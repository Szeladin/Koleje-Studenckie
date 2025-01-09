namespace Domain.Entities
{
    public class Personel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public DateTime LastUpdated { get; set; }

        public Personel(string id, string name, string surname, string position, int salary, DateTime lastupdated)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Position = position;
            Salary = salary;
            LastUpdated = lastupdated;
        }
    }
}