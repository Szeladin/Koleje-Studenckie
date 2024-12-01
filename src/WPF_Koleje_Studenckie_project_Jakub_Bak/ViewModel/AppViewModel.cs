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
        public ObservableCollection<Personel> PersonelList { get; private set; }

        public ObservableCollection<Schedule> Schedules { get; private set; }

        public AppViewModel()
        {
            Trains = [];
            PersonelList = [];
            Schedules = [];
            LoadTrains();
            LoadPersonel();
            LoadSchedule();
        }

        public void LoadTrains()
        {
            LoadData<TrainDTO>(FilePathProvider.GetTrainDataFilePath(), trainDto =>
            {
                var train = new Train(trainDto.Id, trainDto.Name, trainDto.MaxSpeed, trainDto.Carriage?.CarriageCount ?? 0);
                train.Movement.IsMoving = trainDto.Movement.IsMoving;
                Trains.Add(train);
            });
        }

        public void LoadPersonel()
        {
            LoadData<PersonelDTO>(FilePathProvider.GetPersonelDataFilePath(), personelDto =>
            {
                var personel = new Personel(personelDto.Id, personelDto.Name, personelDto.Surname, personelDto.Position, personelDto.Salary);
                PersonelList.Add(personel);
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
