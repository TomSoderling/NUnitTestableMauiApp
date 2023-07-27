namespace MauiAppToTest.Models
{
    public struct GeoCoordinate
    {
        // "The fourth decimal place is worth up to 11 m: it can identify a parcel of land. It is comparable to the typical accuracy of an uncorrected GPS unit with no interference." - http://gis.stackexchange.com/questions/8650/how-to-measure-the-accuracy-of-latitude-and-longitude
        public const double MaxDecimalDegreeAccuracy = .0001;

        private double latitude;
        private double longitude;

        public GeoCoordinate(double latitude, double longitude)
            : this(latitude, longitude, default(double))
        {
        }

        public GeoCoordinate(double latitude, double longitude, double altitude)
        {
            this.latitude = latitude.RoundCoordinate();
            this.longitude = longitude.RoundCoordinate();
            this.Elevation = altitude;
        }

        public double Elevation { get; set; }

        public double Latitude
        {
            get
            {
                return latitude;
            }

            set
            {
                latitude = value;
            }
        }

        public double Longitude
        {
            get
            {
                return longitude;
            }

            set
            {
                longitude = value;
            }
        }
    }

    public static class LatLonExtensions
    {
        public static double RoundCoordinate(this double coordinate)
        {
            return Math.Round(coordinate, 6);
        }
    }
}

