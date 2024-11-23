using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Personel
    {
        private static int _idCounter = 0; // Static counter for unique IDs

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }

        public Personel(string name, string surname, string position, int salary)
        {
            Id = ++_idCounter; // Increment and assign unique ID
            Name = name;
            Surname = surname;
            Position = position;
            Salary = salary;
        }
    }
}
