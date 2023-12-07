using AdventOfCode23.Interfaces;
using AdventOfCode23.Solutions.Day01.Models;
using System.Text.RegularExpressions;

namespace AdventOfCode23.Solutions.Day01
{
    public class Day01Solution : SolutionBase, ISolution
    {
        private IFileReader _fileReader;
        private List<string> _calibrationValues = new List<string>();

        public Day01Solution(IFileReader fileReader)
        {
            _fileReader = fileReader;
            InitCalibrationValues();
            ResetSolution();
        }

        public void Solve()
        {
            StartTime();
            var part1Answer = GetSumOfCalibratedValues();
            SetAnswer(part1Answer.ToString());

            StartTime();
            var part2Answer = GetSumOfCalibratedValues(true);
            SetAnswer(part2Answer.ToString());
        }

        public int GetSumOfCalibratedValues(bool complexInput = false)
        {
            var total = 0;
            foreach (var calibrationValue in _calibrationValues)
            {
                var newNumber = complexInput ? GetComplexInput(calibrationValue) : GetSimpleInput(calibrationValue);

                total += newNumber;
            }

            return total;
        }

        private int GetSimpleInput(string calibrationValue)
        {
            var numbers = calibrationValue.Where(char.IsDigit).ToList();

            var newNumber = $"{numbers.First()}{numbers.Last()}";

            return int.Parse(newNumber);
        }

        private int GetComplexInput(string calibrationValue)
        {
            var stringNumbers = new List<StringNumber>
            {
                new StringNumber("one", 1),
                new StringNumber("two", 2),
                new StringNumber("three", 3),
                new StringNumber("four", 4),
                new StringNumber("five", 5),
                new StringNumber("six", 6),
                new StringNumber("seven", 7),
                new StringNumber("eight", 8),
                new StringNumber("nine", 9),
            };

            var orderedStringNumbers = new List<OrderNumber>();

            foreach (var stringNumber in stringNumbers)
            {
                var literalIndexs = GetAllIndexes(calibrationValue, stringNumber.Literal);
                foreach(var literalIndex in literalIndexs)
                {
                    if (literalIndex >= 0)
                        orderedStringNumbers.Add(new OrderNumber(literalIndex, stringNumber.Value));
                }

                var valueIndexs = GetAllIndexes(calibrationValue, stringNumber.Value.ToString());
                foreach (var valueIndex in valueIndexs)
                {
                    if (valueIndex >= 0)
                        orderedStringNumbers.Add(new OrderNumber(valueIndex, stringNumber.Value));
                }
            }

            orderedStringNumbers = orderedStringNumbers.OrderBy(o => o.Index).ToList();

            var newNumber = $"{orderedStringNumbers.First().Number}{orderedStringNumbers.Last().Number}";

            return int.Parse(newNumber);
        }

        public static IEnumerable<int> GetAllIndexes(string source, string matchString)
        {
            matchString = Regex.Escape(matchString);
            foreach (Match match in Regex.Matches(source, matchString))
            {
                yield return match.Index;
            }
        }

        private void InitCalibrationValues()
        {
            _calibrationValues = _fileReader.ReadFileToStringArray("Solutions/Day01/data.json");
        }
    }
}
