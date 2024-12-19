namespace Domain.Entities
{
    public class Station
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public List<string> TrainIds { get; set; }

        public Station(string name, int x, int y, List<string> trainIds)
        {
            Name = name;
            X = x;
            Y = y;
            TrainIds = trainIds;
        }
    }
}
