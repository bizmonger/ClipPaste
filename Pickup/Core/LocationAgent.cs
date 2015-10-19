namespace Core
{
    public class LocationAgent
    {
        public string Id { get; internal set; }
        public Location Location { get; private set; }

        public void Pulse() =>
            Location = new Location(99, 99);
    }
}