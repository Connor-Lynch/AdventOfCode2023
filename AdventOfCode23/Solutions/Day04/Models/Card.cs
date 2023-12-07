namespace AdventOfCode23.Solutions.Day04.Models
{
    public class Card
    {
        public int Id { get; set; }
        public List<int> WinningNumbers { get; set; } = new List<int>();
        public List<int> MyNumbers { get; set; } = new List<int>();
        public int NumberOfWins { get => GetNumberOfWins(); }
        public double Points { get => CalculatePointsForCard(); }

        public List<int> GetCardsIdsToCopy()
        {
            var cardIdsToCopy = new List<int>();
            
            for (int i = 1; i <= NumberOfWins; i++)
            {
                cardIdsToCopy.Add(Id +i);
            }

            return cardIdsToCopy;
        }

        private int GetNumberOfWins()
        {
            return MyNumbers.Where(WinningNumbers.Contains).Count();
        }

        private double CalculatePointsForCard()
        {
            if (NumberOfWins == 0)
                return 0;

            return NumberOfWins == 1 ? 1 : Math.Pow(2, NumberOfWins - 1);
        }
    }
}
