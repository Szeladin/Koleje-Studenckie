namespace Domain.Entities
{
    public class Train
    {
        private static int _idCounter = 0; // Static counter for unique IDs

        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxSpeed { get; private set; }
        public TrainMovement Movement { get; private set; }
        public TrainCarriage Carriage { get; private set; }

        public Train(string name, int maxSpeed, int initialCarriageCount)
        {
            Id = ++_idCounter; // Increment and assign unique ID
            Name = name;
            MaxSpeed = maxSpeed;
            Movement = new TrainMovement();
            Carriage = new TrainCarriage(initialCarriageCount);
        }
        
    }
}
