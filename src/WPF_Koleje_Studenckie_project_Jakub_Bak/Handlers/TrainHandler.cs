using Domain.Entities;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.Handlers
{
    public class TrainHandler
    {
        private readonly TrainMovementHandler _movementHandler;
        private readonly TrainCarriageHandler _carriageHandler;

        public TrainHandler()
        {
            _movementHandler = new TrainMovementHandler();
            _carriageHandler = new TrainCarriageHandler();
        }

        public void StartEngine(Train train)
        {
            _movementHandler.StartEngine(train);
        }

        public void StopEngine(Train train)
        {
            _movementHandler.StopEngine(train);
        }

        public void Accelerate(Train train, int speedIncrease)
        {
            _movementHandler.Accelerate(train, speedIncrease);
        }

        public void Decelerate(Train train, int speedDecrease)
        {
            _movementHandler.Decelerate(train, speedDecrease);
        }

        public void AddCarriage(Train train)
        {
            _carriageHandler.AddCarriage(train);
        }

        public void RemoveCarriage(Train train)
        {
            _carriageHandler.RemoveCarriage(train);
        }
    }
}
