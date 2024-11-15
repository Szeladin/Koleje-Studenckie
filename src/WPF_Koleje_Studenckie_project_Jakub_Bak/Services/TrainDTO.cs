using System.Text.Json.Serialization;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.Services
{
    public class TrainDTO
    {
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public int CarriageCount { get; set; }
        public bool IsMoving { get; set; }

        [JsonConstructor]
        public TrainDTO(string name, int maxSpeed, int carriageCount, bool isMoving)
        {
            Name = name;
            MaxSpeed = maxSpeed;
            CarriageCount = carriageCount;
            IsMoving = isMoving;
        }
    }
}