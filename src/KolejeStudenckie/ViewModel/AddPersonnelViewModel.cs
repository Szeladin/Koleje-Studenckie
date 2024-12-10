using KolejeStudenckie.Commands;
using KolejeStudenckie.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_Koleje_Studenckie_project_Jakub_Bak.DTO;

namespace KolejeStudenckie.ViewModel
{
    internal class AddPersonnelViewModel : BaseViewModel
    {
        public PersonnelDTO NewPersonnel { get; set; }

        public ICommand AddPersonnelCommand { get; }
        public ICommand CancelCommand { get; }

        public AddPersonnelViewModel()
        {
            string newPersonnelId = ShortGuidHandler.GenerateUniqueShortGuid("Personnels-");
            NewPersonnel = new PersonnelDTO(newPersonnelId, "", "", "", 0);

            AddPersonnelCommand = new RelayCommand(AddPersonnel);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void AddPersonnel(object? parameter)
        {
            if (parameter is Window window)
            {
                var personnels = JsonDataHandler.LoadDataFromJson<PersonnelDTO>("src/KolejeStudenckie/Data/personnels.json");
                personnels.Add(NewPersonnel);
                JsonDataHandler.SaveDataToJson("src/KolejeStudenckie/Data/personnels.json", personnels);
                window.DialogResult = true;
                window.Close();
            }
        }

        private void Cancel(object? parameter)
        {
            if (parameter is Window window)
            {
                window.DialogResult = false;
                window.Close();
            }
        }
    }
}
