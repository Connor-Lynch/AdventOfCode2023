namespace AdventOfCode23.Solutions.Day07.Models
{
    public class Hand
    {
        public string Raw { get; set; }
        public int InitialScore { get; set; }
        public int Score { get; set; }
        public string Encoded { get; set; }
        public int Bet { get; set; }

        public Hand (string rawVale, int bet)
        {
            Raw = rawVale;
            Bet = bet;
            SetHandScore();
            SetEndodedHand();
        }

        private void SetHandScore()
        {            
            var groupdedCards = new List<List<char>>();

            Raw.ToList().ForEach(r =>
            {
                var matchingIndex = groupdedCards.FindIndex(g => g.First() == r);

                if (matchingIndex >= 0)
                    groupdedCards[matchingIndex].Add(r);

                else
                    groupdedCards.Add(new List<char> { r });
            });

            InitialScore = groupdedCards.Count switch
            {
                1 => 6,
                2 => groupdedCards.Any(c => c.Count == 1) ? 5 : 4,
                3 => groupdedCards.Any(c => c.Count == 3) ? 3 : 2,
                4 => 1,
                5 => 0,
                _ => throw new Exception($"Hand length of {groupdedCards.Count} is not valid")
            };
        }

        private void SetEndodedHand()
        {
            Encoded = Raw;

            Encoded = Encoded.Replace('K', 'B');
            Encoded = Encoded.Replace('Q', 'C');
            Encoded = Encoded.Replace('J', 'D');
            Encoded = Encoded.Replace('T', 'E');
            Encoded = Encoded.Replace('9', 'F');
            Encoded = Encoded.Replace('8', 'G');
            Encoded = Encoded.Replace('7', 'H');
            Encoded = Encoded.Replace('6', 'I');
            Encoded = Encoded.Replace('5', 'J');
            Encoded = Encoded.Replace('4', 'K');
            Encoded = Encoded.Replace('3', 'L');
            Encoded = Encoded.Replace('2', 'M');
        }
    }
}
