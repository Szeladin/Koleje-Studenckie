using System.Text.Json.Serialization;
namespace WPF_Koleje_Studenckie_project_Jakub_Bak.DTO
{
    public class ScheduleDTO : IDTO
    {
        public string Id { get; set; }
        public string TrainId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Station { get; set; }

        [JsonConstructor]
        public ScheduleDTO(string id, string trainId, DateTime departureTime, DateTime arrivalTime, string station)
        {
            Id = id;
            TrainId = trainId;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Station = station;
        }
    }
} 