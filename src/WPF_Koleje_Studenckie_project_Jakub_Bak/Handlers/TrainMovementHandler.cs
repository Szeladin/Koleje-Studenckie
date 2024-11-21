using Domain.Entities;
using System;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.Handlers
{ 
    public class TrainMovementHandler
    {
        public void StartEngine(Train train)
        {
            if (!train.Movement.IsMoving)
            {
                train.Movement.IsMoving = true;
                Console.WriteLine($"{train.Name} engine started.");
            }
        }

        public void StopEngine(Train train)
        {
            if (train.Movement.IsMoving)
            {
                train.Movement.IsMoving = false;
                train.Movement.CurrentSpeed = 0; 
                Console.WriteLine($"{train.Name} engine stopped.");
            }
            else
            {
                Console.WriteLine("Cannot stop engine while train is moving.");
            }
        }

        public void Accelerate(Train train, int speedIncrease)
        {
            if (!train.Movement.IsMoving)
            {
                StartEngine(train);
            }

            train.Movement.CurrentSpeed = Math.Max(train.Movement.CurrentSpeed + speedIncrease, train.MaxSpeed);
            Console.WriteLine($"{train.Name} is now traveling at {train.Movement.CurrentSpeed} km/h.");
        }

        public void Decelerate(Train train, int speedDecrease)
        {
            train.Movement.CurrentSpeed = Math.Min(train.Movement.CurrentSpeed - speedDecrease, 0);
            if (train.Movement.CurrentSpeed == 0)
            {
                StopEngine(train);
                Console.WriteLine($"{train.Name} has come to a stop.");
            }
            else
            {
                Console.WriteLine($"{train.Name} is now traveling at {train.Movement.CurrentSpeed} km/h.");
            }
        }
    }
}
