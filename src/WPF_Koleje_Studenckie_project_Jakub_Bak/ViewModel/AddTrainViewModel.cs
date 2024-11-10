using Domain.Entities;
using System.Windows;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class AddTrainViewModel : BaseViewModel
    {
        public Train NewTrain { get; private set; }

        public void AddTrain(string name, int maxSpeed, int carriageCount)
        {
            NewTrain = new Train(name, maxSpeed, carriageCount);
        }

        public bool ValidateInput(string name, string maxSpeedText, string carriageCountText)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a name for the train.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!int.TryParse(maxSpeedText, out int maxSpeed) || maxSpeed <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for Max Speed.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!int.TryParse(carriageCountText, out int carriageCount) || carriageCount <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for Carriage Count.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
    }
}
