namespace Domain.Entities
{
    public class Train
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public int CarriageCount { get; set; }

        public Train(string id, string name, int maxSpeed, int carriageCount)
        {
            Id = id;
            Name = name;
            MaxSpeed = maxSpeed;
            CarriageCount = carriageCount;
        }

        public static bool ValidateInput(string name, string maxSpeedText, string carriageCountText, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(name))
            {
                errorMessage = "Please enter a name for the train.";
                return false;
            }

            if (!int.TryParse(maxSpeedText, out int maxSpeed) || maxSpeed <= 0)
            {
                errorMessage = "Please enter a valid positive number for Max Speed.";
                return false;
            }

            if (!int.TryParse(carriageCountText, out int carriageCount) || carriageCount <= 0)
            {
                errorMessage = "Please enter a valid positive number for Carriage Count.";
                return false;
            }

            return true;
        }
    }
}
