using KolejeStudenckie.Commands;
using KolejeStudenckie.DTO;
using KolejeStudenckie.Utilities;
using System.Windows;
using System.Windows.Input;

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
            NewPersonnel = new PersonnelDTO(newPersonnelId, "", "", "", 0,DateTime.Now);

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
