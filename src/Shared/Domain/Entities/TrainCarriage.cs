namespace Domain.Entities
{
    public class TrainCarriage
    {
        public int CarriageCount { get; set; }

        public TrainCarriage(int initialCarriageCount)
        {
            CarriageCount = initialCarriageCount;
        }
    }
}