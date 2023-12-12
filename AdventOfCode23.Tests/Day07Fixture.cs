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

        [TestMethod]
        public void GetTotalWinningsForWildHands_AllFiveOfAKind_ReturnCorrectValue()
        {
            // Arrange
            var data = new List<string>
            {
                "XXXXX 1",
                "XXXXJ 1",
                "XXXJJ 1",
                "XXJJJ 1",
                "XJJJJ 1",
            };

            FileReaderMock.Setup(f => f.ReadFileToStringArray(It.IsAny<string>())).Returns(data);
            _solution = new Day07Solution(FileReaderMock.Object);

            // Act
            var result = _solution.GetTotalWinningsForWildHands();

            // Assert
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void GetTotalWinningsForWildHands_AllFourOfAKind_ReturnCorrectValue()
        {
            // Arrange
            var data = new List<string>
            {
                "XXXXY 1",
                "XXXJY 1",
                "XXJJY 1",
                "XJJJY 1",
            };

            FileReaderMock.Setup(f => f.ReadFileToStringArray(It.IsAny<string>())).Returns(data);
            _solution = new Day07Solution(FileReaderMock.Object);

            // Act
            var result = _solution.GetTotalWinningsForWildHands();

            // Assert
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void GetTotalWinningsForWildHands_AllFullHouse_ReturnCorrectValue()
        {
            // Arrange
            var data = new List<string>
            {
                "XXXYY 1",
                "XXJYY 1",
            };

            FileReaderMock.Setup(f => f.ReadFileToStringArray(It.IsAny<string>())).Returns(data);
            _solution = new Day07Solution(FileReaderMock.Object);

            // Act
            var result = _solution.GetTotalWinningsForWildHands();

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void GetTotalWinningsForWildHands_AllThreeOfAKind_ReturnCorrectValue()
        {
            // Arrange
            var data = new List<string>
            {
                "XXXYZ 1",
                "XXJYZ 1",
                "XJJYZ 1",
            };

            FileReaderMock.Setup(f => f.ReadFileToStringArray(It.IsAny<string>())).Returns(data);
            _solution = new Day07Solution(FileReaderMock.Object);

            // Act
            var result = _solution.GetTotalWinningsForWildHands();

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void GetTotalWinningsForWildHands_TwoPair_ReturnCorrectValue()
        {
            // Arrange
            var data = new List<string>
            {
                "XXYYZ 1",
            };

            FileReaderMock.Setup(f => f.ReadFileToStringArray(It.IsAny<string>())).Returns(data);
            _solution = new Day07Solution(FileReaderMock.Object);

            // Act
            var result = _solution.GetTotalWinningsForWildHands();

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetTotalWinningsForWildHands_AllOnePair_ReturnCorrectValue()
        {
            // Arrange
            var data = new List<string>
            {
                "XXYZW 1",
                "XJYZW 1",
            };

            FileReaderMock.Setup(f => f.ReadFileToStringArray(It.IsAny<string>())).Returns(data);
            _solution = new Day07Solution(FileReaderMock.Object);

            // Act
            var result = _solution.GetTotalWinningsForWildHands();

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void GetTotalWinningsForWildHands_HighCard_ReturnCorrectValue()
        {
            // Arrange
            var data = new List<string>
            {
                "XYZWU 1",
            };

            FileReaderMock.Setup(f => f.ReadFileToStringArray(It.IsAny<string>())).Returns(data);
            _solution = new Day07Solution(FileReaderMock.Object);

            // Act
            var result = _solution.GetTotalWinningsForWildHands();

            // Assert
            Assert.AreEqual(1, result);
        }
    }
}
