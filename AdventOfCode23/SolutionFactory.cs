using AdventOfCode23.Interfaces;
using AdventOfCode23.Solutions;
using AdventOfCode23.Solutions.Day01;
using AdventOfCode23.Solutions.Day02;
using AdventOfCode23.Solutions.Day03;
using AdventOfCode23.Solutions.Day04;
using AdventOfCode23.Solutions.Day05;
using AdventOfCode23.Solutions.Day06;

namespace AdventOfCode23
{
    public class SolutionFactory : ISolutionFactory
    {
        private IFileReader _fileReader;

        public SolutionFactory()
        {
            _fileReader = new FileReader();
        }

        public ISolution GetSolution(string day)
        {
            return day switch
            {
                "1" => new Day01Solution(_fileReader),
                "2" => new Day02Solution(_fileReader),
                "3" => new Day03Solution(_fileReader),
                "4" => new Day04Solution(_fileReader),
                "5" => new Day05Solution(_fileReader),
                "6" => new Day06Solution(_fileReader),
                _ => new Default(),
            };
        }
    }
}
