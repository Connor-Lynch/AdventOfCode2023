namespace AdventOfCode23.Solutions.Day03.Models
{
    public class Row
    {
        public int Index { get; set; }
        public List<PartNumber> PartNumbers { get; set; } = new List<PartNumber>();
        public List<Symbol> Symbols { get; set; } = new List<Symbol>();
    }
}
