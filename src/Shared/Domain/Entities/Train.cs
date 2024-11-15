namespace Domain.Entities
{
    public class Train
    {
        public string Name { get; set; }
        public int MaxSpeed { get; private set; }
        public TrainMovement Movement { get; private set; }
        public TrainCarriage Carriage { get; private set; }

        public Train(string name, int maxSpeed, int initialCarriageCount)
        {
            Name = name;
            MaxSpeed = maxSpeed;
            Movement = new TrainMovement();
            Carriage = new TrainCarriage(initialCarriageCount);
        }
    }
}
