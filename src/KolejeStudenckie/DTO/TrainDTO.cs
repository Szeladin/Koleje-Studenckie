using KolejeStudenckie.DTO.Interfaces;
using System.Text.Json.Serialization;

namespace KolejeStudenckie.DTO
{
    public class TrainDTO : IDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public MovementDTO Movement { get; set; }
        public CarriageDTO Carriage { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<string> Personnel { get; set; }

        [JsonConstructor]
        public TrainDTO(string id, string name, int maxSpeed, MovementDTO movement, CarriageDTO carriage, DateTime lastupdated, List <string> personnel)
        {
            Id = id;
            Name = name;
            MaxSpeed = maxSpeed;
            Movement = movement;
            Carriage = carriage;
            LastUpdated = lastupdated;
            Personnel = personnel;
        }
    }
}
