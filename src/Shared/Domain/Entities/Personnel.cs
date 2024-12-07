using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Personnel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }

        public Personnel(string id, string name, string surname, string position, int salary)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Position = position;
            Salary = salary;
        }

        public static bool ValidateInput(string name, string surname, string position, string salaryText, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(name))
            {
                errorMessage = "Proszę wprowadzić imię dla personelu.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(surname))
            {
                errorMessage = "Proszę wprowadzić nazwisko dla personelu.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(position))
            {
                errorMessage = "Proszę wprowadzić stanowisko dla personelu.";
                return false;
            }

            if (!int.TryParse(salaryText, out int salary) || salary < 0)
            {
                errorMessage = "Proszę wprowadzić prawidłową dodatnią liczbę dla wynagrodzenia.";
                return false;
            }

            return true;
        }
    }
}
