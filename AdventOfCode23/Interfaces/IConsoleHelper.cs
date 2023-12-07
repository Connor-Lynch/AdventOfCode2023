namespace AdventOfCode23.Interfaces
{
    public interface IConsoleHelper
    {
        public string GetDayFromUser();
        public void ShowMainText();
        public void InitDay(string day);
        public void IterationComplete();
        public void PrintTable(List<List<string>> table);
    }
}
