using KolejeStudenckie.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejeStudenckie.Utilities
{
    public class StationService : IStationService
    {
        public ObservableCollection<StationDTO> GetStations()
        {
            return new ObservableCollection<StationDTO>(JsonDataHandler.LoadDataFromJson<StationDTO>("src/KolejeStudenckie/Data/stations.json"));
        }

        public void RefreshStationTrainList(ObservableCollection<StationDTO> stations)
        {
            var schedules = JsonDataHandler.LoadDataFromJson<ScheduleDTO>("src/KolejeStudenckie/Data/schedules.json");
            var trains = JsonDataHandler.LoadDataFromJson<TrainDTO>("src/KolejeStudenckie/Data/trains.json");
            var currentTime = DateTime.Now;

            foreach (var station in stations)
            {
                station.TrainIds.Clear();
                var stationSchedules = schedules.Where(s => s.Station == station.Name);
                foreach (var schedule in stationSchedules)
                {
                    if (schedule.ArrivalTime <= currentTime && schedule.DepartureTime > currentTime)
                    {
                        var train = trains.FirstOrDefault(t => t.Id == schedule.TrainId);
                        if (train != null)
                        {
                            station.TrainIds.Add(train.Id);
                        }
                    }
                }
            }
            JsonDataHandler.SaveDataToJson("src/KolejeStudenckie/Data/stations.json", stations);
        }
    }
}
