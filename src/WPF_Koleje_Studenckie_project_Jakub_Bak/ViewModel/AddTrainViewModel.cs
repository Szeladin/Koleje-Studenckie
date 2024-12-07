using Domain.Entities;
using System.Windows;
using System.Windows.Input;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Utilities;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class AddTrainViewModel : BaseViewModel
    {
        public Train NewTrain { get; set; }
        public ICommand AddTrainCommand { get; }
        public ICommand CancelCommand { get; }

        public AddTrainViewModel()
        {
            AddTrainCommand = new RelayCommand(AddTrain);
            CancelCommand = new RelayCommand(Cancel);
        }

        public void AddTrain(string id, string name, int maxSpeed, int carriageCount)
        {
            NewTrain = new Train(id, name, maxSpeed, carriageCount);
        }

        public bool ValidateInput(string name, string maxSpeedText, string carriageCountText, out string errorMessage)
        {
            return Train.ValidateInput(name, maxSpeedText, carriageCountText, out errorMessage);
        }

        private void AddTrain(object parameter)
        {
            var values = (object[])parameter;
            string name = (string)values[0];
            string maxSpeedText = (string)values[1];
            string carriageCountText = (string)values[2];

            if (ValidateInput(name, maxSpeedText, carriageCountText, out string errorMessage))
            {
                AddTrain(ShortGuidHandler.GenerateUniqueShortGuid("Train-"), name, int.Parse(maxSpeedText), int.Parse(carriageCountText));
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
