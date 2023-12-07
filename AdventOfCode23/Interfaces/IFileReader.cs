namespace AdventOfCode23.Interfaces
{
    public interface IFileReader
    {
        public List<int> ReadFileToIntArray(string filePath);
        public List<string> ReadFileToStringArray(string filePath);
    }
}
