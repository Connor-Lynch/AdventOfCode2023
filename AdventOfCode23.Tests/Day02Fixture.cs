using AdventOfCode23.Solutions.Day02;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AdventOfCode23.Tests
{
    [TestClass]
    public class Day02Fixture : BaseFixture
    {
        private Day02Solution _solution;

        public Day02Fixture()
        {
            var data = new List<string>
            {
                "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
                "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
                "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
                "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
                "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
            };
            FileReaderMock.Setup(f => f.ReadFileToStringArray(It.IsAny<string>())).Returns(data);
            _solution = new Day02Solution(FileReaderMock.Object);
        }

        [TestMethod]
        public void GetSumOfValidGameIds_StandardInput_ReturnCorrectValue()
        {
            // Act
            var result = _solution.GetSumOfValidGameIds(12, 13, 14);

            // Assert
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void SumThePowerOfAllGames_StandardInput_ReturnCorrectValue()
        {
            // Act
            var result = _solution.SumThePowerOfAllGames();

            // Assert
            Assert.AreEqual(2286, result);
        }
    }
}
