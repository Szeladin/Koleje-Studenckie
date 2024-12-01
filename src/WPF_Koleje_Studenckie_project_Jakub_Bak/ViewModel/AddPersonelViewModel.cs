using Domain.Entities;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class AddPersonelViewModel : BaseViewModel
    {
        public Personel NewPersonel { get; set; }

        public void AddPersonel(string id,string name, string surname, string position, int salary)
        {
            NewPersonel = new Personel(id, name, surname, position, salary);
        }

        public static bool ValidateInput(string name, string surname, string position, string salaryText, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(name))
            {
                errorMessage = "Please enter a name for the personnel.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(surname))
            {
                errorMessage = "Please enter a surname for the personnel.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(position))
            {
                errorMessage = "Please enter a position for the personnel.";
                return false;
            }

            if (!int.TryParse(salaryText, out int salary) || salary < 0)
            {
                errorMessage = "Please enter a valid positive number for Salary.";
                return false;
            }

            return true;
        }
    }
}
