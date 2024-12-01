using Domain.Entities;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class AddScheduleViewModel : BaseViewModel
    {
        public Schedule NewSchedule { get; set; }

        public void AddSchedule(string id, string trainId, DateTime departureTime, DateTime arrivalTime, string departureStation)
        {
            NewSchedule = new Schedule(id, trainId, departureTime, arrivalTime, departureStation);
        }

        public bool ValidateInput(string trainId, string departureTimeText, string arrivalTimeText, string departureStation, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(trainId))
            {
                errorMessage = "Please enter a train ID.";
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
            if (string.IsNullOrWhiteSpace(departureStation))
            {
                errorMessage = "Please enter a departure station.";
                return false;
            }
            return true;
        }
    }
}