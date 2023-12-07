namespace AdventOfCode23.Solutions.Day05.Models
{
    public class MapRange
    {
        public long Source { get; set; }
        public long Destination { get; set; }
        public long TotalNumber { get; set; }

        public MapRange(long source, long destination, long totalNumber) 
        {
            Source = source;
            Destination = destination;
            TotalNumber = totalNumber;
        }

        public bool TryGetDestinationForSource(long key, out long destinationKey)
        {
            destinationKey = default;

            if (key < Source || key > Source + TotalNumber)
                return false;

            destinationKey = (key - Source) + Destination;

            return true;
        }
    }
}
