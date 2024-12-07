using Domain.Entities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Utilities;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Views;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class PersonnelManagementViewModel : BaseViewModel
    {
        public ObservableCollection<Personnel> PersonnelList { get; }
        public ICommand AddPersonnelCommand { get; }
        public ICommand RemovePersonnelCommand { get; }
        public ICommand UpdatePersonnelCommand { get; }
        public Personnel SelectedPersonnel { get; set; }

        public PersonnelManagementViewModel()
        {
            var appViewModel = (AppViewModel)Application.Current.Resources["AppViewModel"];
            if (appViewModel != null)
            {
                PersonnelList = appViewModel.PersonnelList;
            }
            else
            {
                MessageBox.Show("AppViewModel is not initialized.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            AddPersonnelCommand = new RelayCommand(_ => AddPersonnel());
            RemovePersonnelCommand = new RelayCommand(_ => RemovePersonnel(), _ => SelectedPersonnel != null);
            UpdatePersonnelCommand = new RelayCommand(_ => UpdatePersonnel(), _ => SelectedPersonnel != null);
        }

        private void AddPersonnel()
        {
            var addPersonnel = new AddPersonnel
            {
                DataContext = new AddPersonnelViewModel()
            };

            bool? result = addPersonnel.ShowDialog();

            if (result == true && addPersonnel.NewPersonnel != null)
            {
                PersonnelList.Add(addPersonnel.NewPersonnel);
                SavePersonnel();
            }
        }

        private void RemovePersonnel()
        {
            if (SelectedPersonnel != null)
            {
                var result = MessageBox.Show($"Are you sure you want to remove the personnel {SelectedPersonnel.Name}?", "Remove Personnel", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    PersonnelList.Remove(SelectedPersonnel);
                    SavePersonnel();
                }
            }
            else
            {
                MessageBox.Show("Please select a personnel to remove.", "No Personnel Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void UpdatePersonnel()
        {
            if (SelectedPersonnel != null)
            {
                var addPersonnel = new AddPersonnel
                {
                    NameTextBox = { Text = SelectedPersonnel.Name },
                    SurnameTextBox = { Text = SelectedPersonnel.Surname },
                    PositionTextBox = { Text = SelectedPersonnel.Position },
                    SalaryTextBox = { Text = SelectedPersonnel.Salary.ToString() },
                };

                addPersonnel.ShowDialog();

                if (addPersonnel.NewPersonnel != null)
                {
                    var updatedPersonnel = (Personnel)addPersonnel.NewPersonnel;
                    updatedPersonnel.Id = SelectedPersonnel.Id;

                    int index = PersonnelList.IndexOf(SelectedPersonnel);
                    if (index >= 0)
                    {
                        PersonnelList[index] = updatedPersonnel;
                        SavePersonnel();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a Personnel to update.", "No Personnel Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SavePersonnel()
        {
            try
            {
                JsonHelper.SaveToJson(PersonnelList, FilePathProvider.GetPersonnelDataFilePath());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving personnel data: {ex.Message}", "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}