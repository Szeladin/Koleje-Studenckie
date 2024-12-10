using KolejeStudenckie.DTO.Interfaces;
using System.Text.Json.Serialization;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.DTO
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