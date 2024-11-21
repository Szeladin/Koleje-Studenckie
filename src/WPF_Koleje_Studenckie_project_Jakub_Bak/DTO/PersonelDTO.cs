using System.Text.Json.Serialization;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.DTO
{
    [method: JsonConstructor]
    public class PersonelDTO(string name, string surname, string position, int salary)
    {
        public string Name { get; set; } = name;
        public string Surname { get; set; } = surname;
        public string Position { get; set; } = position;
        public int Salary { get; set; } = salary;
    }
}
