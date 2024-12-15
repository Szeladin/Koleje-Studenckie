using KolejeStudenckie.DTO.Interfaces;
using System.Text.Json.Serialization;

namespace KolejeStudenckie.DTO
{

    public class PersonnelDTO : IDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }

        [JsonConstructor]
        public PersonnelDTO(string id, string name, string surname, string position, int salary)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Position = position;
            Salary = salary;
        }
    }
}