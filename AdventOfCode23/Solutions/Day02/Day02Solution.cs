using AdventOfCode23.Interfaces;
using AdventOfCode23.Solutions.Day02.Models;

namespace AdventOfCode23.Solutions.Day02
{
    public class Day02Solution : SolutionBase, ISolution
    {
        private IFileReader _fileReader;
        private List<Game> _games = new List<Game>();

        public Day02Solution(IFileReader fileReader)
        {
            _fileReader = fileReader;
            InitGames();
            ResetSolution();
        }

        public void Solve()
        {
            StartTime();
            var part1Answer = GetSumOfValidGameIds(12, 13, 14);
            SetAnswer(part1Answer.ToString());

            StartTime();
            var part2Answer = SumThePowerOfAllGames();
            SetAnswer(part2Answer.ToString());
        }

        public int GetSumOfValidGameIds(int red, int green, int blue)
        {
            SetMostCubesForEachGame();

            var validGames = _games.Where(g => g.MostRedCubes <= red && g.MostGreenCubes <= green && g.MostBlueCubes <= blue);

            return validGames.Sum(g => g.GameNumber);
        }

        public int SumThePowerOfAllGames()
        {
            SetMostCubesForEachGame();

            var powers = _games.Select(g => g.MostRedCubes * g.MostGreenCubes * g.MostBlueCubes);

            return powers.Sum();
        }

        private void SetMostCubesForEachGame()
        {
            foreach(var game in _games)
            {
                foreach(var draw in game.Draws)
                {
                    if (draw.RedCubes > game.MostRedCubes)
                        game.MostRedCubes = draw.RedCubes;

                    if (draw.GreenCubes > game.MostGreenCubes)
                        game.MostGreenCubes = draw.GreenCubes;

                    if (draw.BlueCubes > game.MostBlueCubes)
                        game.MostBlueCubes = draw.BlueCubes;
                }
            }
        }

        private void InitGames()
        {
            var rawGames = _fileReader.ReadFileToStringArray("Solutions/Day02/data.json");
            var games = new List<Game>();

            foreach(var rawGame in rawGames)
            {
                var game = new Game();
                game.GameNumber = int.Parse(rawGame.Split(':')[0].Split(' ')[1]);

                var rawDraws = rawGame.Split(':')[1].Split(';');
                foreach(var rawDraw in rawDraws)
                {
                    var draw = new Draw();
                    var colorDraws = rawDraw.Split(',');
                    foreach (var colorDraw in colorDraws)
                    {
                        var count = colorDraw.Trim().Split(' ')[0];
                        var color = colorDraw.Trim().Split(' ')[1];

                        switch (color) 
                        {
                            case CubeColors.Red: 
                            {
                                draw.RedCubes = int.Parse(count);
                                break;
                            }
                            case CubeColors.Green:
                            {
                                draw.GreenCubes = int.Parse(count);
                                break;
                            }
                            case CubeColors.Blue:
                            {
                                draw.BlueCubes = int.Parse(count);
                                break;
                            }
                        }
                    }

                    game.Draws.Add(draw);
                }

                games.Add(game);
            }

            _games = games;
        }
    }
}
