namespace AdventOfCode23.Solutions.Day05.Models
{
    public class Map
    {
        private List<MapRange> _ranges = new List<MapRange>();
        public MapType SourceType { get; set; }
        public MapType DestinationType { get; set; }
        public List<MapRange> Ranges { get => _ranges; }

        public Map(string sourceKey, string destinationKey) 
        {
            SourceType = GetMapTypeFromKey(sourceKey);
            DestinationType = GetMapTypeFromKey(destinationKey);
        }

        public void InitKeys(long destinationIndex, long sourceIndex, long totalNumber)
        {
            _ranges.Add(new MapRange(sourceIndex, destinationIndex, totalNumber));

            _ranges = _ranges.OrderBy(r => r.Source).ToList();
        }

        public long GetDestinationForSource(long source)
        {
            long destination = default;
            Ranges.Where(range => range.TryGetDestinationForSource(source, out destination)).FirstOrDefault();

            return destination != default ? destination : source;
        }

        private MapType GetMapTypeFromKey(string key)
        {
            key = key.Trim().ToLower();

            return key switch
            {
                MapTypes.Seed => MapType.Seed,
                MapTypes.Soil => MapType.Soil,
                MapTypes.Fertilizer => MapType.Fertilizer,
                MapTypes.Water => MapType.Water,
                MapTypes.Light => MapType.Light,
                MapTypes.Temperature => MapType.Temperature,
                MapTypes.Humidity => MapType.Humidity,
                MapTypes.Location => MapType.Location,
                _ => throw new Exception($"Invalid Key: {key}"),
            };
        }
    }
}
