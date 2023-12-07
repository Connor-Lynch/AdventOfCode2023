namespace AdventOfCode23.Solutions.Day01.Models
{
    public class StringNumber
    {
        public string Literal { get; set; }

        public int Value { get; set; }

        public StringNumber(string literal, int value)
        {
            Literal = literal;
            Value = value;
        }
    }
}
