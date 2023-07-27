using System;
namespace MauiAppToTest.Models
{
    /// <summary>
    /// This model class represents a waypoint you'd see on the map that has geo position info (lat, lon, elevation)
    /// </summary>
    public class Waypoint
	{
        public GeoCoordinate GeoCoordinate { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Address Address { get; set; }

        public string UserId { get; set; }

        public bool IsPublic { get; set; }

        public Uri ImageUrl { get; set; }
    }
}

