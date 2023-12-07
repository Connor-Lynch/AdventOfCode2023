using AdventOfCode23.Interfaces;
using AdventOfCode23.Solutions.Day04.Models;

namespace AdventOfCode23.Solutions.Day04
{
    public class Day04Solution : SolutionBase, ISolution
    {
        private IFileReader _fileReader;
        private List<Card> _cards = new List<Card>();

        public Day04Solution(IFileReader fileReader)
        {
            _fileReader = fileReader;
            InitCards();
            ResetSolution();
        }

        public void Solve()
        {
            StartTime();
            var part1Answer = GetSumOfWinningCards();
            SetAnswer(part1Answer.ToString());

            StartTime();
            var part2Answer = GetTotalNumberOfCopiedCards();
            SetAnswer(part2Answer.ToString());
        }

        public double GetSumOfWinningCards()
        {
            return _cards.Sum(c => c.Points);
        }

        public int GetTotalNumberOfCopiedCards()
        {
            return CountCards(_cards, 0);
        }

        private int CountCards(List<Card> cards, int count)
        {
            cards.ForEach(card =>
            {
                var newCards = AddCardCopies(card.GetCardsIdsToCopy());
                count = CountCards(newCards, count);
            });

            return count += cards.Count();
        }

        private List<Card> AddCardCopies(List<int> carIds)
        {
            var copiedCards = new List<Card>();

            carIds.ForEach(id =>
            {
                copiedCards.Add(_cards[id - 1]);
            });

            return copiedCards;
        }

        private void InitCards()
        {
            var rawCards = _fileReader.ReadFileToStringArray("Solutions/Day04/data.json");

            rawCards.ForEach(rawCard =>
            {
                var card = new Card();
                card.Id = int.Parse(rawCard.Split(':')[0].Split(' ').Last());

                var numberPieces = rawCard.Split(':')[1].Split('|');
                card.WinningNumbers = GetListOfNumbers(numberPieces[0]);
                card.MyNumbers = GetListOfNumbers(numberPieces[1]);

                _cards.Add(card);
            });
        }

        private List<int> GetListOfNumbers(string rawList)
        {
            var numbers = rawList.Split(' ').Where(n => !string.IsNullOrEmpty(n))
                .Select(int.Parse)
                .Order()
                .ToList();
            return numbers;
        }
    }
}
