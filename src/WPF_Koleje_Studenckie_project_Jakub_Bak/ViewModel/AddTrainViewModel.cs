using Domain.Entities;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class AddTrainViewModel : BaseViewModel
    {
        public Train NewTrain { get; set; }

        public void AddTrain(string id, string name, int maxSpeed, int carriageCount)
        {
            NewTrain = new Train(id, name, maxSpeed, carriageCount);
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
    }
}
