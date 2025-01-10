using Domain.Validation;
using KolejeStudenckie.Commands;
using KolejeStudenckie.DTO;
using KolejeStudenckie.Utilities;
using KolejeStudenckie.Validation;
using System.Windows;
using System.Windows.Input;

namespace KolejeStudenckie.ViewModel
{
    internal class AddPersonnelViewModel : BaseViewModel
    {
        public PersonnelDTO NewPersonnel { get; set; }

        public ICommand AddPersonnelCommand { get; }
        public ICommand CancelCommand { get; }

        private readonly IValidator<PersonnelDTO> _personnelValidator;

        public AddPersonnelViewModel()
        {
            string newPersonnelId = ShortGuidHandler.GenerateUniqueShortGuid("Personnels-");
            NewPersonnel = new PersonnelDTO(newPersonnelId, "", "", "", 0, DateTime.Now);

            _personnelValidator = new PersonnelValidator();

            AddPersonnelCommand = new RelayCommand(AddPersonnel);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void AddPersonnel(object? parameter)
        {
            if (parameter is Window window)
            {
                var validationResult = _personnelValidator.Validate(NewPersonnel);
                if (!validationResult.IsValid)
                {
                    MessageBox.Show(string.Join("\n", validationResult.Errors), "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

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
