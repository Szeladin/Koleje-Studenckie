using Domain.Entities;
using System.Collections.ObjectModel;
using System.Windows;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class AddScheduleViewModel : BaseViewModel
    {
        public ObservableCollection<Train> Trains { get; set; }
        public string selectedTrainId;
        public string SelectedTrainId
        {
            get => selectedTrainId;
            set
            {
                selectedTrainId = value;
                OnPropertyChanged();
            }
        }
        public Schedule? NewSchedule { get; set; }

        public AddScheduleViewModel()
        {
            var appViewModel = (AppViewModel)Application.Current.Resources["AppViewModel"];
            Trains = appViewModel.Trains;
        }

        public void AddSchedule(string id, string SelectedTrainId, DateTime departureTime, DateTime arrivalTime, string departureStation)
        {
            NewSchedule = new Schedule(id, SelectedTrainId, departureTime, arrivalTime, departureStation);
        }

        public bool ValidateInput(string SelectedTrainId,string departureTimeText, string arrivalTimeText, string departureStation, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(SelectedTrainId))
            {
                errorMessage = "Please select a train ID.";
                return false;
            }
            if (!DateTime.TryParse(departureTimeText, out DateTime departureTime))
            {
                errorMessage = "Please enter a valid date for Departure Time.";
                return false;
            }
            if (!DateTime.TryParse(arrivalTimeText, out DateTime arrivalTime))
            {
                errorMessage = "Please enter a valid date for Arrival Time.";
                return false;
            }
            if (departureTime >= arrivalTime)
            {
                errorMessage = "Departure time must be earlier than arrival time.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(departureStation))
            {
                errorMessage = "Please enter a departure station.";
                return false;
            }
            return true;
        }
    }
}