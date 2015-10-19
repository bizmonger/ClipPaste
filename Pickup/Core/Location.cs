namespace Core
{
    public class Location
    {
        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public Location(int v1, int v2)
        {
            Latitude = v1;
            Longitude = v2;
        }

        public double Latitude { get; internal set; }
        public double Longitude { get; internal set; }
    }
}