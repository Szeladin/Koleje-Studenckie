using Domain.Entities;
using System.Windows;
using System.Windows.Input;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Utilities;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class AddPersonelViewModel : BaseViewModel
    {
        public Personel NewPersonel { get; set; }

        public ICommand AddCommand { get; }
        public ICommand CancelCommand { get; }

        public AddPersonelViewModel()
        {
            AddCommand = new RelayCommand(AddPersonel);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void AddPersonel()
        {
            if (ValidateInput(Name, Surname, Position, SalaryText, out string errorMessage))
            {
                NewPersonel = new Personel(ShortGuidHandler.GenerateUniqueShortGuid("Personel-"), Name, Surname, Position, int.Parse(SalaryText));
                DialogResult = true;
            }
            else
            {
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel()
        {
            DialogResult = false;
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

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string SalaryText { get; set; }
        public bool? DialogResult { get; set; }
    }
}
