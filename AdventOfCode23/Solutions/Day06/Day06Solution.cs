using AdventOfCode23.Interfaces;
using AdventOfCode23.Solutions.Day06.Models;
using System.Text.RegularExpressions;

namespace AdventOfCode23.Solutions.Day06
{
    public class Day06Solution : SolutionBase, ISolution
    {
        private IFileReader _fileReader;
        private List<Race> _races = new List<Race>();
        private Race _race;

        public Day06Solution(IFileReader fileReader)
        {
            _fileReader = fileReader;
            InitData();
            ResetSolution();
        }

        public void Solve()
        {
            StartTime();
            var part1Answer = GetProductOfWinningRaces();
            SetAnswer(part1Answer.ToString());

            StartTime();
            var part2Answer = GetProductOfWinningRacesForCorrectedInput();
            SetAnswer(part2Answer.ToString());
        }

        public long GetProductOfWinningRaces()
        {
            var numberOfWinsPerRace = _races.Select(r => r.GetNumberOfWinningPreLoads());

            return numberOfWinsPerRace.Aggregate(1, (long acc, long val) => acc * val);
        }

        public long GetProductOfWinningRacesForCorrectedInput()
        {
            var result = _race.GetNumberOfWinningPreLoads();

            return result;
        }

        private void InitData()
        {
            var rawInput = _fileReader.ReadFileToStringArray("Solutions/Day06/data.json");

            _race = new Race(
                GetSingleNumberFromInput(rawInput.First()),
                GetSingleNumberFromInput(rawInput.Last())
            );

            var times = GetListOfNumberFromInput(rawInput.First());
            var distance = GetListOfNumberFromInput(rawInput.Last());

            for(var i = 0; i < times.Count; i++) 
            {
                _races.Add(new Race(times[i], distance[i]));
            }
        }

        private List<long> GetListOfNumberFromInput(string input)
        {
            return input.Split(':')[1].Split(' ').Where(n => !string.IsNullOrEmpty(n))
                .Select(long.Parse).ToList();
        }

        private long GetSingleNumberFromInput(string input)
        {
            var whiteSpace = new Regex(@"\s+");
            return long.Parse(whiteSpace.Replace(input.Split(':')[1], ""));
        }
    }
}
