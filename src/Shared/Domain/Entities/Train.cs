namespace Domain.Entities
{
    public class Train
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public TrainMovement Movement { get; private set; }
        public TrainCarriage Carriage { get; private set; }

        public Train(string id, string name, int maxSpeed, int initialCarriageCount)
        {
            Id = id;
            Name = name;
            MaxSpeed = maxSpeed;
            Movement = new TrainMovement();
            Carriage = new TrainCarriage(initialCarriageCount);
        }
        
    }
}
