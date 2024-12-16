using KolejeStudenckie.Commands;
using KolejeStudenckie.DTO;
using KolejeStudenckie.Utilities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace KolejeStudenckie.ViewModel
{
    internal class AddScheduleViewModel : BaseViewModel
    {
        public ScheduleDTO NewSchedule { get; set; }
        public ObservableCollection<TrainDTO> Trains { get; set; }
        public ObservableCollection<StationDTO> Stations { get; set; }
        public ICommand AddScheduleCommand { get; }
        public ICommand CancelCommand { get; }

        public AddScheduleViewModel()
        {
            string newScheduleId = ShortGuidHandler.GenerateUniqueShortGuid("Schedules-");
            NewSchedule = new ScheduleDTO(newScheduleId, "", DateTime.Now, DateTime.Now, "");

            Trains = new ObservableCollection<TrainDTO>(JsonDataHandler.LoadDataFromJson<TrainDTO>("src/KolejeStudenckie/Data/trains.json"));
            Stations = new ObservableCollection<StationDTO>(JsonDataHandler.LoadDataFromJson<StationDTO>("src/KolejeStudenckie/Data/stations.json"));
            AddScheduleCommand = new RelayCommand(AddSchedule);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void AddSchedule(object? parameter)
        {
            if (parameter is Window window)
            {
                var schedules = JsonDataHandler.LoadDataFromJson<ScheduleDTO>("src/KolejeStudenckie/Data/schedules.json");
                schedules.Add(NewSchedule);
                JsonDataHandler.SaveDataToJson("src/KolejeStudenckie/Data/schedules.json", schedules);
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
