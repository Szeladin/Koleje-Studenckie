using Domain.Entities;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Handlers;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Utilities;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class PersonelManagmentViewModel : BaseViewModel
    {
        public ObservableCollection<Personel> PersonelList { get; }
        public ICommand AddPersonelCommand { get; }
        public ICommand RemovePersonelCommand { get; }
        public ICommand UpdatePersonelCommand { get; }

        public PersonelManagmentViewModel()
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

            _personelHandler = new PersonelHandler();
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
            addPersonelWindow.ShowDialog();

            if (addPersonelWindow.NewPersonel != null)
            {
                PersonelList.Add((Personel)addPersonelWindow.NewPersonel);
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
                    int index = PersonelList.IndexOf(SelectedPersonel);
                    if (index >= 0)
                    {
                        PersonelList[index] = (Personel)addPersonelWindow.NewPersonel;
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
            JsonHelper.SaveToJson(PersonelList, AppViewModel.GetPersonelDataFilePath());
        }
        public Personel SelectedPersonel { get; set; }
    }
}