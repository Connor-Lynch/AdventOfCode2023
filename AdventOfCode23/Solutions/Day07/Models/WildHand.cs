namespace AdventOfCode23.Solutions.Day07.Models
{
    public class WildHand
    {
        public string Raw { get; set; }
        public int InitialScore { get; set; }
        public int Score { get; set; }
        public string Encoded { get; set; }
        public int Bet { get; set; }

        public WildHand(string rawVale, int bet)
        {
            Raw = rawVale;
            Bet = bet;
            SetHandScore();
            SetEndodedHand();
        }

        private void SetHandScore()
        {
            var jokers = new List<char>();
            var groupedCards = new List<List<char>>();

            Raw.ToList().ForEach(r =>
            {
                if (r == 'J')
                    jokers.Add(r);
                else
                {
                    var matchingIndex = groupedCards.FindIndex(g => g.First() == r);

                    if (matchingIndex >= 0)
                        groupedCards[matchingIndex].Add(r);

                    else
                        groupedCards.Add(new List<char> { r });
                }
            });

            if (jokers.Any())
                InitialScore = GetBestScoreForWildHand(groupedCards, jokers.Count);
            else 
                InitialScore = groupedCards.Count switch
                {
                    1 => 6,
                    2 => groupedCards.Any(c => c.Count == 1) ? 5 : 4,
                    3 => groupedCards.Any(c => c.Count == 3) ? 3 : 2,
                    4 => 1,
                    5 => 0,
                    _ => throw new Exception($"Hand length of {groupedCards.Count} is not valid")
                };
        }

        private int GetBestScoreForWildHand(List<List<char>> groupedCards, int jokerCount)
        {
            if (jokerCount == 5 || groupedCards.Count == 1)
                return 6;

            return groupedCards.Count switch
            {
                2 => jokerCount == 1 && !groupedCards.Any(c => c.Count == 3) ? 3 : 5,
                3 => 3,
                4 => 2,
                _ => throw new Exception($"Hand length of {groupedCards.Count} is not valid")
            };
        }

        private void SetEndodedHand()
        {
            Encoded = Raw;

            Encoded = Encoded.Replace('K', 'B');
            Encoded = Encoded.Replace('Q', 'C');
            Encoded = Encoded.Replace('T', 'D');
            Encoded = Encoded.Replace('9', 'E');
            Encoded = Encoded.Replace('8', 'F');
            Encoded = Encoded.Replace('7', 'G');
            Encoded = Encoded.Replace('6', 'H');
            Encoded = Encoded.Replace('5', 'I');
            Encoded = Encoded.Replace('4', 'J');
            Encoded = Encoded.Replace('3', 'K');
            Encoded = Encoded.Replace('2', 'L');
            Encoded = Encoded.Replace('J', 'M');
        }
    }
}
