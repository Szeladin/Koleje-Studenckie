using Domain.Entities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Utilities;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class AddScheduleViewModel : BaseViewModel
    {
        public event EventHandler? DialogResultChanged;

        private bool? _dialogResult;
        public bool? DialogResult
        {
            get => _dialogResult;
            set
            {
                if (_dialogResult != value)
                {
                    _dialogResult = value;
                    OnPropertyChanged();
                    DialogResultChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public ObservableCollection<Train> Trains { get; set; }
        public Schedule? NewSchedule { get; set; }
        public ICommand AddCommand { get; }
        public ICommand CancelCommand { get; }

        public AddScheduleViewModel()
        {
            var appViewModel = (AppViewModel)Application.Current.Resources["AppViewModel"];
            Trains = appViewModel.Trains;
            AddCommand = new RelayCommand(AddSchedule);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void AddSchedule()
        {
            if (ValidateInput(Train, DepartureTime, ArrivalTime,Station ,out string errorMessage))
            {
                NewSchedule = new Schedule(ShortGuidHandler.GenerateUniqueShortGuid("Schedule-"), Train, DepartureTime, ArrivalTime,Station);
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

        public static bool ValidateInput(string SelectedTrainId, DateTime departureTime, DateTime arrivalTime, string departureStation, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(SelectedTrainId))
            {
                errorMessage = "Please select a train ID.";
                return false;
            }
            if (departureTime == default)
            {
                errorMessage = "Please enter a valid date for Departure Time.";
                return false;
            }
            if (arrivalTime == default)
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
        public string Train { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Station { get; set; }

    }
}