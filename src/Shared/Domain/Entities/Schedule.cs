﻿namespace Domain.Entities
{
    public class Schedule
    {
        public string Id { get; set; }
        public string TrainId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Station { get; set; }

        public DateTime LastUpdated { get; set; }
        public Schedule(string id, string trainId, DateTime departureTime, DateTime arrivalTime, string station, DateTime lastupdated)
        {
            Id = id;
            TrainId = trainId;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Station = station;
            LastUpdated = lastupdated;
        }
    }
}