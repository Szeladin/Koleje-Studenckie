using Domain.Entities;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using WPF_Koleje_Studenckie_project_Jakub_Bak.DTO;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Utilities;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.ViewModel
{
    public class AppViewModel : BaseViewModel
    {
        public ObservableCollection<Train> Trains { get; private set; }
        public ObservableCollection<Personnel> PersonnelList { get; private set; }
        public ObservableCollection<Schedule> Schedules { get; private set; }

        public AppViewModel()
        {
            Trains = new ObservableCollection<Train>();
            PersonnelList = new ObservableCollection<Personnel>();
            Schedules = new ObservableCollection<Schedule>();
            LoadTrains();
            LoadPersonnel();
            LoadSchedule();
        }

        public void LoadTrains()
        {
            LoadData<TrainDTO>(FilePathProvider.GetTrainDataFilePath(), trainDto =>
            {
                var train = new Train(trainDto.Id, trainDto.Name, trainDto.MaxSpeed, trainDto.Carriage?.CarriageCount ?? 0);
                Trains.Add(train);
            });
        }

        public void LoadPersonnel()
        {
            LoadData<PersonnelDTO>(FilePathProvider.GetPersonnelDataFilePath(), personnelDto =>
            {
                var personnel = new Personnel(personnelDto.Id, personnelDto.Name, personnelDto.Surname, personnelDto.Position, personnelDto.Salary);
                PersonnelList.Add(personnel);
            });
        }

        public void LoadSchedule()
        {
            LoadData<ScheduleDTO>(FilePathProvider.GetScheduleDataFilePath(), scheduleDto =>
            {
                var schedule = new Schedule(scheduleDto.Id, scheduleDto.TrainId, scheduleDto.DepartureTime, scheduleDto.ArrivalTime, scheduleDto.Station);
                Schedules.Add(schedule);
            });
        }

        private void LoadData<IDTO>(string filePath, Action<IDTO> loadAction)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var loadedData = JsonSerializer.Deserialize<ObservableCollection<IDTO>>(json);
                if (loadedData != null)
                {
                    foreach (var item in loadedData)
                    {
                        loadAction(item);
                    }
                }
            }
        }
    }
}
