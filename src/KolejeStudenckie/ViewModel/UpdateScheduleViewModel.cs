using KolejeStudenckie.Commands;
using KolejeStudenckie.DTO;
using KolejeStudenckie.Utilities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace KolejeStudenckie.ViewModel
{
    internal class UpdateScheduleViewModel : BaseViewModel
    {
        private ScheduleDTO _existingSchedule;
        public ScheduleDTO ExistingSchedule
        {
            get => _existingSchedule;
            set
            {
                _existingSchedule = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TrainDTO> Trains { get; set; }
        public ObservableCollection<StationDTO> Stations { get; set; }
        public ICommand UpdateScheduleCommand { get; }
        public ICommand CancelCommand { get; }

        public UpdateScheduleViewModel(ScheduleDTO schedule)
        {
            ExistingSchedule = schedule;
            Trains = new ObservableCollection<TrainDTO>(JsonDataHandler.LoadDataFromJson<TrainDTO>("src/KolejeStudenckie/Data/trains.json"));
            Stations = new ObservableCollection<StationDTO>(JsonDataHandler.LoadDataFromJson<StationDTO>("src/KolejeStudenckie/Data/stations.json"));
            UpdateScheduleCommand = new RelayCommand(UpdateSchedule);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void UpdateSchedule(object? parameter)
        {
            if (parameter is Window window)
            {
                var schedules = JsonDataHandler.LoadDataFromJson<ScheduleDTO>("src/KolejeStudenckie/Data/schedules.json");
                var scheduleToUpdate = schedules.FirstOrDefault(s => s.Id == ExistingSchedule.Id);
                if (scheduleToUpdate != null)
                {
                    scheduleToUpdate.TrainId = ExistingSchedule.TrainId;
                    scheduleToUpdate.DepartureTime = ExistingSchedule.DepartureTime;
                    scheduleToUpdate.ArrivalTime = ExistingSchedule.ArrivalTime;
                    scheduleToUpdate.Station = ExistingSchedule.Station;
                    scheduleToUpdate.LastUpdated = DateTime.Now;
                    JsonDataHandler.SaveDataToJson("src/KolejeStudenckie/Data/schedules.json", schedules);
                }
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
