using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Personel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }

        public Personel(string id, string name, string surname, string position, int salary)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Position = position;
            Salary = salary;
        }
    }
}
