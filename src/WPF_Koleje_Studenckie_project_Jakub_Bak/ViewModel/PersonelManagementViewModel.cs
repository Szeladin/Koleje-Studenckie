using Domain.Entities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Utilities;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class PersonelManagementViewModel : BaseViewModel
    {
        public ObservableCollection<Personel> PersonelList { get; }
        public ICommand AddPersonelCommand { get; }
        public ICommand RemovePersonelCommand { get; }
        public ICommand UpdatePersonelCommand { get; }
        public Personel SelectedPersonel { get; set; }

        public PersonelManagementViewModel()
        {
            var appViewModel = (AppViewModel)Application.Current.Resources["AppViewModel"];
            if (appViewModel != null)
            {
                PersonelList = appViewModel.PersonelList;
            }
            else
            {
                MessageBox.Show("AppViewModel is not initialized.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            AddPersonelCommand = new RelayCommand(AddPersonel);
            RemovePersonelCommand = new RelayCommand(RemovePersonel);
            UpdatePersonelCommand = new RelayCommand(UpdatePersonel);
        }

        private void AddPersonel()
        {
            var addPersonelWindow = new AddPersonelWindow
            {
                DataContext = new AddPersonelViewModel()
            };

            bool? result = addPersonelWindow.ShowDialog();

            if (result == true && addPersonelWindow.NewPersonel != null)
            {
                PersonelList.Add(addPersonelWindow.NewPersonel);
                SavePersonel();
            }
        }

        private void RemovePersonel()
        {
            if (SelectedPersonel != null)
            {
                PersonelList.Remove(SelectedPersonel);
                SavePersonel();
            }
            else
            {
                MessageBox.Show("Please select a personnel to remove.", "No Personnel Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void UpdatePersonel()
        {
            if (SelectedPersonel != null)
            {
                var addPersonelWindow = new AddPersonelWindow
                {
                    NameTextBox = { Text = SelectedPersonel.Name },
                    SurnameTextBox = { Text = SelectedPersonel.Surname },
                    PositionTextBox = { Text = SelectedPersonel.Position },
                    SalaryTextBox = { Text = SelectedPersonel.Salary.ToString() },
                };

                addPersonelWindow.ShowDialog();

                if (addPersonelWindow.NewPersonel != null)
                {
                    var updatedPersonel = (Personel)addPersonelWindow.NewPersonel;
                    updatedPersonel.Id = SelectedPersonel.Id;

                    int index = PersonelList.IndexOf(SelectedPersonel);
                    if (index >= 0)
                    {
                        PersonelList[index] = updatedPersonel;
                        SavePersonel();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a Personel to update.", "No Personel Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SavePersonel()
        {
            JsonHelper.SaveToJson(PersonelList, FilePathProvider.GetPersonelDataFilePath());
        }
    }
}