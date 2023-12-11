using AdventOfCode23.Solutions.Day07;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AdventOfCode23.Tests
{
    [TestClass]
    public class Day07Fixture : BaseFixture
    {
        private Day07Solution _solution;

        public Day07Fixture()
        {
            var data = new List<string>
            {
                "32T3K 765",
                "T55J5 684",
                "KK677 28",
                "KTJJT 220",
                "QQQJA 483",
            };

            FileReaderMock.Setup(f => f.ReadFileToStringArray(It.IsAny<string>())).Returns(data);
            _solution = new Day07Solution(FileReaderMock.Object);
        }

        [TestMethod]
        public void GetTotalWinnings_StandardInput_ReturnCorrectValue()
        {
            // Act
            var result = _solution.GetTotalWinnings();

            // Assert
            Assert.AreEqual(6440, result);
        }
        [TestMethod]
        public void GetTotalWinningsForWildHands_StandardInput_ReturnCorrectValue()
        {
            // Act
            var result = _solution.GetTotalWinningsForWildHands();

            // Assert
            Assert.AreEqual(5905, result);
        }

    }
}
