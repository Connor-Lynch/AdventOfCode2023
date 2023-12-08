using AdventOfCode23.Solutions.Day06;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AdventOfCode23.Tests
{
    [TestClass]
    public class Day06Fixture : BaseFixture
    {
        private Day06Solution _solution;

        public Day06Fixture()
        {
            var data = new List<string>
            {
                "Time:      7  15   30",
                "Distance: 9  40  200",
            };
            FileReaderMock.Setup(f => f.ReadFileToStringArray(It.IsAny<string>())).Returns(data);
            _solution = new Day06Solution(FileReaderMock.Object);
        }

        [TestMethod]
        public void GetProductOfWinningRaces_StandardInput_ReturnCorrectValue()
        {
            // Act
            var result = _solution.GetProductOfWinningRaces();

            // Assert
            Assert.AreEqual(288, result);
        }

        [TestMethod]
        public void GetProductOfWinningRacesForCorrectedInput_StandardInput_ReturnCorrectValue()
        {
            // Act
            var result = _solution.GetProductOfWinningRacesForCorrectedInput();

            // Assert
            Assert.AreEqual(71503, result);
        }
    }
}
