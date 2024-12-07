using Domain.Entities;
using System.Windows;
using System.Windows.Input;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Utilities;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class AddPersonnelViewModel : BaseViewModel
    {
        public Personnel? NewPersonnel { get; set; }
        public ICommand AddPersonnelCommand { get; }
        public ICommand CancelCommand { get; }

        public AddPersonnelViewModel()
        {
            AddPersonnelCommand = new RelayCommand(AddPersonnel);
            CancelCommand = new RelayCommand(Cancel);
        }

        public void AddPersonnel(string id, string name, string surname, string position, int salary)
        {
            NewPersonnel = new Personnel(id, name, surname, position, salary);
        }

        private void AddPersonnel(object parameter)
        {
            var values = (object[])parameter;
            string name = (string)values[0];
            string surname = (string)values[1];
            string position = (string)values[2];
            string salaryText = (string)values[3];

            if (Personnel.ValidateInput(name, surname, position, salaryText, out string errorMessage))
            {
                AddPersonnel(ShortGuidHandler.GenerateUniqueShortGuid("Personnel-"), name, surname, position, int.Parse(salaryText));
                OnRequestClose?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel(object parameter)
        {
            OnRequestClose?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler? OnRequestClose;
    }
}