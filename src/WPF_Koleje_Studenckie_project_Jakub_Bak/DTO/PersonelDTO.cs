using System.Text.Json.Serialization;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.DTO
{
    public class PersonelDTO : IDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        
        [JsonConstructor]
        public PersonelDTO(string name, string surname, string position, int salary)
        {
            Name = name;
            Surname = surname;
            Position = position;
            Salary = salary;
        }
    }
}
