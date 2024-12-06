using Domain.Entities;
using System.Windows;
using System.Windows.Input;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Utilities;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class AddTrainViewModel : BaseViewModel
    {
        public Train NewTrain { get; set; }
        public ICommand AddCommand { get; }
        public ICommand CancelCommand { get; }

        public AddTrainViewModel()
        {
            AddCommand = new RelayCommand(AddTrain);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void AddTrain()
        {
            if (ValidateInput(Name, MaxSpeed, CarriageCount, out string errorMessage))
            {
                NewTrain = new Train(ShortGuidHandler.GenerateUniqueShortGuid("Train-"), Name, int.Parse(MaxSpeed), int.Parse(CarriageCount));
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

        public bool ValidateInput(string name, string maxSpeedText, string carriageCountText, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(name))
            {
                errorMessage = "Please enter a name for the train.";
                return false;
            }

            if (!int.TryParse(maxSpeedText, out int maxSpeed) || maxSpeed <= 0)
            {
                errorMessage = "Please enter a valid positive number for Max Speed.";
                return false;
            }

            if (!int.TryParse(carriageCountText, out int carriageCount) || carriageCount <= 0)
            {
                errorMessage = "Please enter a valid positive number for Carriage Count.";
                return false;
            }

            return true;
        }

        public string Name { get; set; }
        public string MaxSpeed { get; set; }
        public string CarriageCount { get; set; }
    }
}
