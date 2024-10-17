using System.Configuration;
using System.Data;
using System.Windows;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    //comment

    public class Train
    {
        // Properties
        public string Name { get; set; }
        public int MaxSpeed { get; private set; }
        public int CurrentSpeed { get; private set; }
        public int CarriageCount { get; private set; }
        public bool IsMoving { get; private set; }

        // Constructor
        public Train(string name, int maxSpeed, int carriageCount)
        {
            Name = name;
            MaxSpeed = maxSpeed;
            CarriageCount = carriageCount;
            CurrentSpeed = 0;
            IsMoving = false;
        }

        // Methods
        public void StartEngine()
        {
            Console.WriteLine($"{Name} engine started.");
        }

        public void StopEngine()
        {
            if (IsMoving)
            {
                Console.WriteLine("Cannot stop engine while train is moving.");
                return;
            }
            Console.WriteLine($"{Name} engine stopped.");
        }

        public void Accelerate(int speedIncrease)
        {
            if (!IsMoving)
            {
                IsMoving = true;
            }

            CurrentSpeed = Math.Min(CurrentSpeed + speedIncrease, MaxSpeed);
            Console.WriteLine($"{Name} is now traveling at {CurrentSpeed} km/h.");
        }

        public void Decelerate(int speedDecrease)
        {
            CurrentSpeed = Math.Max(CurrentSpeed - speedDecrease, 0);
            Console.WriteLine($"{Name} is now traveling at {CurrentSpeed} km/h.");

            if (CurrentSpeed == 0)
            {
                IsMoving = false;
                Console.WriteLine($"{Name} has come to a stop.");
            }
        }

        public void AddCarriage()
        {
            CarriageCount++;
            Console.WriteLine($"Carriage added. {Name} now has {CarriageCount} carriages.");
        }

        public void RemoveCarriage()
        {
            if (CarriageCount > 0)
            {
                CarriageCount--;
                Console.WriteLine($"Carriage removed. {Name} now has {CarriageCount} carriages.");
            }
            else
            {
                Console.WriteLine($"{Name} has no carriages to remove.");
            }
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

    public partial class App : Application
    {

    }

}
