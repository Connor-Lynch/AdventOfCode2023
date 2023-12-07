using AdventOfCode23.Interfaces;
using AdventOfCode23.Solutions.Day05.Models;

namespace AdventOfCode23.Solutions.Day05
{
    public class Day05Solution : SolutionBase, ISolution
    {
        private IFileReader _fileReader;
        private List<long> _seeds = new List<long>();
        private List<Map> _maps = new List<Map>();

        public Day05Solution(IFileReader fileReader)
        {
            _fileReader = fileReader;
            InitData();
            ResetSolution();
        }

        public void Solve()
        {
            StartTime();
            var part1Answer = GetClosestLocationId();
            SetAnswer(part1Answer.ToString());
        }

        public long? GetClosestLocationId()
        {
            long? closestLocation = null;

            _seeds.ForEach(seed =>
            {
                var seedLocation = GetLocationForSeed(seed);
                if (closestLocation == null || seedLocation < closestLocation)
                    closestLocation = seedLocation;
            });

            return closestLocation;
        }

        public long? GetClosestLocationIdFromSeedRange()
        {
            long? closestLocation = null;

            _seeds.ForEach(seed =>
            {
                var seedLocation = GetLocationForSeed(seed);
                if (closestLocation == null || seedLocation < closestLocation)
                    closestLocation = seedLocation;
            });

            return closestLocation;
        }

        private long GetLocationForSeed(long seed)
        {
            var path = new List<MapType>
            {
                MapType.Soil,
                MapType.Fertilizer,
                MapType.Water,
                MapType.Light,
                MapType.Temperature,
                MapType.Humidity,
                MapType.Location,
            };

            var key = seed;

            path.ForEach(destination =>
            {
                var map = _maps.Where(m => m.DestinationType == destination).FirstOrDefault();
                key = map.GetDestinationForSource(key);
            });

            return key;
        }

        private void InitData()
        {
            var rawData = _fileReader.ReadFileToStringArray("Solutions/Day05/data.json");

            _seeds = rawData[0].Split(':')[1].Split(' ').Where(n => !string.IsNullOrEmpty(n))
                .Select(long.Parse)
                .Order()
                .ToList();

            rawData.RemoveAt(0);

            Map? workingMap = null;

            rawData.ForEach(rawRow =>
            {
                if (rawRow.Contains("map"))
                {
                    if (workingMap != null)
                        _maps.Add(workingMap);

                    workingMap = CreateBaseMap(rawRow);
                }
                else { 
                    SetKeysOnMap(workingMap, rawRow);
                }
            });

            _maps.Add(workingMap);
        }

        private Map CreateBaseMap(string mapKey)
        {
            var keys = mapKey.Replace("map:", "").Trim().Split('-');

            return new Map(keys.First(), keys.Last());
        }

        private void SetKeysOnMap(Map map, string rawKeys) 
        {
            var keys = rawKeys.Split(' ').Where(n => !string.IsNullOrEmpty(n))
                .Select(long.Parse).ToList();

            map.InitKeys(keys[0], keys[1], keys[2]);
        }

    }
}
