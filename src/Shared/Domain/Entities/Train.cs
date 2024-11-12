using System;

namespace Domain.Entities
{
    public class Train
    {
        public string Name { get; set; }
        public int MaxSpeed { get; private set; }
        public int CurrentSpeed { get; private set; } = 0;
        public int CarriageCount { get; private set; }
        public bool IsMoving { get; private set; } = false;

        public Train(string name, int maxSpeed, int carriageCount)
        {
            Name = name;
            MaxSpeed = maxSpeed;
            CarriageCount = carriageCount;
        }

        public void SetIsMoving(bool isMoving)
        {
            IsMoving = isMoving;
        }

        public void SetCurrentSpeed(int currentSpeed)
        {
            CurrentSpeed = currentSpeed;
        }

        public void SetCarriageCount(int carriageCount)
        {
            CarriageCount = carriageCount;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Train: {Name}");
            Console.WriteLine($"Max Speed: {MaxSpeed} km/h");
            Console.WriteLine($"Current Speed: {CurrentSpeed} km/h");
            Console.WriteLine($"Number of Carriages: {CarriageCount}");
            Console.WriteLine($"Is Moving: {IsMoving}");
        }
    }
}
