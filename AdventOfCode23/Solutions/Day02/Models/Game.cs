namespace AdventOfCode23.Solutions.Day02.Models
{
    public class Game
    {
        public int GameNumber { get; set; }
        public List<Draw> Draws { get; set;} = new List<Draw>();
        public int MostRedCubes { get; set; } = 0;
        public int MostGreenCubes { get; set; } = 0;
        public int MostBlueCubes { get; set; } = 0;
    }
}
