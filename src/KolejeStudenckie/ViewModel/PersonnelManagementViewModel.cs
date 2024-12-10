using KolejeStudenckie.Commands;
using KolejeStudenckie.DTO.Interfaces;
using KolejeStudenckie.Utilities;
using KolejeStudenckie.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using KolejeStudenckie.DTO;

namespace KolejeStudenckie.ViewModel
{
    internal class PersonnelManagementViewModel : BaseViewModel
    {
        public ObservableCollection<IDTO> Personnels { get; set; }
        private PersonnelDTO _selectedPersonnel;
        public PersonnelDTO SelectedPersonnel
        {
            get => _selectedPersonnel;
            set
            {
                _selectedPersonnel = value;
                OnPropertyChanged();
                ((RelayCommand)RemovePersonnelCommand).RaiseCanExecuteChanged();
                ((RelayCommand)OpenUpdatePersonnelWindowCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand OpenAddPersonnelWindowCommand { get; }
        public ICommand RemovePersonnelCommand { get; }
        public ICommand OpenUpdatePersonnelWindowCommand { get; }

        public PersonnelManagementViewModel()
        {
            Personnels = new ObservableCollection<IDTO>();
            _selectedPersonnel = new PersonnelDTO(string.Empty, string.Empty, string.Empty, string.Empty, 0);
            OpenAddPersonnelWindowCommand = new RelayCommand(OpenAddPersonnelWindow);
            RemovePersonnelCommand = new RelayCommand(RemovePersonnel, CanExecuteRemoveOrUpdate);
            OpenUpdatePersonnelWindowCommand = new RelayCommand(OpenUpdatePersonnelWindow, CanExecuteRemoveOrUpdate);
            RefreshPersonnels();
        }

        private bool CanExecuteRemoveOrUpdate(object? parameter)
        {
            return SelectedPersonnel != null;
        }

        private void OpenAddPersonnelWindow(object? parameter)
        {
            var addPersonnelWindow = new AddPersonnelWindow();
            if (addPersonnelWindow.ShowDialog() == true)
            {
                RefreshPersonnels();
            }
        }

        private void RemovePersonnel(object? parameter)
        {
            var personnels = JsonDataHandler.LoadDataFromJson<PersonnelDTO>("src/KolejeStudenckie/Data/personnels.json");
            var personnelToRemove = personnels.FirstOrDefault(p => p.Id == SelectedPersonnel.Id);
            if (personnelToRemove != null)
            {
                personnels.Remove(personnelToRemove);
                JsonDataHandler.SaveDataToJson("src/KolejeStudenckie/Data/personnels.json", personnels);
                RefreshPersonnels();
            }
        }

        private void OpenUpdatePersonnelWindow(object? parameter)
        {
            if (SelectedPersonnel != null)
            {
                var updatePersonnelWindow = new UpdatePersonnelWindow(SelectedPersonnel);
                if (updatePersonnelWindow.ShowDialog() == true)
                {
                    RefreshPersonnels();
                }
            }
        }

        private void RefreshPersonnels()
        {
            var personnels = JsonDataHandler.LoadDataFromJson<PersonnelDTO>("src/KolejeStudenckie/Data/personnels.json");
            Personnels = new ObservableCollection<IDTO>(personnels);
            OnPropertyChanged(nameof(Personnels));
        }
    }
}
