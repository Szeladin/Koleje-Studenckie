using Domain.Entities;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.Services
{
    public class TrainHandler
    {
        public void StartEngine(Train train)
        {
            if (!train.IsMoving)
            {
                train.SetIsMoving(true);
                Console.WriteLine($"{train.Name} engine started.");
            }
        }

        public void StopEngine(Train train)
        {
            if (train.IsMoving)
            {
                train.SetIsMoving(false);
                Console.WriteLine($"{train.Name} engine stopped.");
            }
            else
            {
                Console.WriteLine("Cannot stop engine while train is moving.");
            }
        }

        public void Accelerate(Train train, int speedIncrease)
        {
            if (!train.IsMoving)
            {
                StartEngine(train);
            }

            train.SetCurrentSpeed(Math.Min(train.CurrentSpeed + speedIncrease, train.MaxSpeed));
            Console.WriteLine($"{train.Name} is now traveling at {train.CurrentSpeed} km/h.");
        }

        public void Decelerate(Train train, int speedDecrease)
        {
            train.SetCurrentSpeed(Math.Max(train.CurrentSpeed - speedDecrease, 0));
            if (train.CurrentSpeed == 0)
            {
                train.SetIsMoving(false);
                Console.WriteLine($"{train.Name} has come to a stop.");
            }
            else
            {
                Console.WriteLine($"{train.Name} is now traveling at {train.CurrentSpeed} km/h.");
            }
        }

        public void AddCarriage(Train train)
        {
            train.SetCarriageCount(train.CarriageCount + 1);
            Console.WriteLine($"Carriage added. {train.Name} now has {train.CarriageCount} carriages.");
        }

        public void RemoveCarriage(Train train)
        {
            if (train.CarriageCount > 0)
            {
                train.SetCarriageCount(train.CarriageCount - 1);
                Console.WriteLine($"Carriage removed. {train.Name} now has {train.CarriageCount} carriages.");
            }
            else
            {
                Console.WriteLine($"{train.Name} has no carriages to remove.");
            }
        }
    }
}
