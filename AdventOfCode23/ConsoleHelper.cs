using AdventOfCode23.Interfaces;
using Figgle;

namespace AdventOfCode23
{
    public class ConsoleHelper : IConsoleHelper
    {
        public string GetDayFromUser()
        {
            Console.WriteLine("Please Enter The Day:");
            return Console.ReadLine();
        }

        public void ShowMainText()
        {
            Console.WriteLine(FiggleFonts.Standard.Render("2023 Advent Of Code"));
            Console.WriteLine("Enter the day you would like to solve, or press 'ENTER' to exit" + Environment.NewLine);
        }

        public void InitDay(string day)
        {
            Console.Clear();
            ShowMainText();
            Console.WriteLine(FiggleFonts.Small.Render($"Day {day}"));
        }

        public void IterationComplete()
        {
            Console.WriteLine(Environment.NewLine);
        }

        public void PrintTable(List<List<string>> table)
        {
            PrintLine();
            PrintRow(table[0]);
            PrintLine();
            table.RemoveAt(0);

            foreach (var row in table)
            {
                PrintRow(row);
            }

            PrintLine();
        }

        private void PrintLine()
        {
            Console.WriteLine(new string('-', 50));
        }

        private void PrintRow(List<string> columns)
        {
            int width = (50 - columns.Count) / columns.Count;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCenter(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        private string AlignCenter(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
