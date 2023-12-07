namespace AdventOfCode23.Solutions.Day01.Models
{
    public class OrderNumber
    {
        public int Index { get; set; }

        public int Number { get; set; }

        public OrderNumber(int index, int number)
        {
            Index = index;
            Number = number;
        }
    }
}
