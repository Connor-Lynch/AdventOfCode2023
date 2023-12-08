namespace AdventOfCode23.Solutions.Day05.Models
{
    public class RawRange
    {
        public long Start { get; set; }
        public long End { get; set; }
        public long Length { get; set; }

        public RawRange(long start, long length) 
        { 
            Start = start;
            End = start + length - 1;
            Length = length;
        }
    }
}
