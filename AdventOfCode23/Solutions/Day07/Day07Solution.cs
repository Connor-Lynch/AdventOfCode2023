using AdventOfCode23.Interfaces;
using AdventOfCode23.Solutions.Day07.Models;

namespace AdventOfCode23.Solutions.Day07
{
    public class Day07Solution : SolutionBase, ISolution
    {
        private IFileReader _fileReader;
        private List<Hand> _hands = new List<Hand>();
        private List<WildHand> _wildHands = new List<WildHand>();

        public Day07Solution(IFileReader fileReader)
        {
            _fileReader = fileReader;
            InitData();
            ResetSolution();
        }

        public void Solve()
        {
            StartTime();
            var part1Answer = GetTotalWinnings();
            SetAnswer(part1Answer.ToString());

            StartTime();
            var part2Answer = GetTotalWinningsForWildHands();
            SetAnswer(part2Answer.ToString());
        }

        public int GetTotalWinnings()
        {
            _hands = _hands.OrderBy(h => h.InitialScore).ThenByDescending(h => h.Encoded).ToList();

            for (var i = 0; i < _hands.Count; i ++)
            {
                _hands[i].Score = _hands[i].Bet * (i + 1);
            }

            return _hands.Sum(h => h.Score);
        }

        public int GetTotalWinningsForWildHands()
        {
            _wildHands = _wildHands.OrderBy(h => h.InitialScore).ThenByDescending(h => h.Encoded).ToList();

            for (var i = 0; i < _wildHands.Count; i ++)
            {
                _wildHands[i].Score = _wildHands[i].Bet * (i + 1);
            }

            return _wildHands.Sum(h => h.Score);
        }

        private void InitData()
        {
            var rawInput = _fileReader.ReadFileToStringArray("Solutions/Day07/data.json");

            rawInput.ForEach(line =>
            {
                var linePieces = line.Split(' ');

                _hands.Add(new Hand(linePieces.First(), int.Parse(linePieces.Last())));
                _wildHands.Add(new WildHand(linePieces.First(), int.Parse(linePieces.Last())));
            });
        }
    }
}
