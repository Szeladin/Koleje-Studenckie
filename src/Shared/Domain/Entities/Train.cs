﻿namespace Domain.Entities
{
    public class Train
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public int CarriageCount { get; set; }
        public DateTime LastUpdated { get; set; }

        public Train(string id, string name, int maxSpeed, int carriageCount, DateTime lastupdated)
        {
            Id = id;
            Name = name;
            MaxSpeed = maxSpeed;
            CarriageCount = carriageCount;
            LastUpdated = lastupdated;
        }
    }
}
