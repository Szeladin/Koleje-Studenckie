using Domain.Entities;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.Handlers
{
    public class TrainCarriageHandler
    {
        public void AddCarriage(Train train)
        {
            train.Carriage.CarriageCount++;
            Console.WriteLine($"Carriage added. {train.Name} now has {train.Carriage.CarriageCount} carriages.");
        }

        public void RemoveCarriage(Train train)
        {
            if (train.Carriage.CarriageCount > 0)
            {
                train.Carriage.CarriageCount--;
                Console.WriteLine($"Carriage removed. {train.Name} now has {train.Carriage.CarriageCount} carriages.");
            }
            else
            {
                Console.WriteLine($"{train.Name} has no carriages to remove.");
            }
        }
    }
}
