using AdventOfCode23.Solutions.Day03;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AdventOfCode23.Tests
{
    [TestClass]
    public class Day03Fixture : BaseFixture
    {
        private Day03Solution _solution;

        public Day03Fixture()
        {
            var data = new List<string>
            {
                "467..114..",
                "...*......",
                "..35..633.",
                "......#...",
                "617*......",
                ".....+.58.",
                "..592.....",
                "......755.",
                "...$.*....",
                ".664.598..",
            };
            FileReaderMock.Setup(f => f.ReadFileToStringArray(It.IsAny<string>())).Returns(data);
            _solution = new Day03Solution(FileReaderMock.Object);
        }

        [TestMethod]
        public void GetSumOfValidPartNumbers_StandardInput_ReturnCorrectValue()
        {
            // Act
            var result = _solution.GetSumOfValidPartNumbers();

            // Assert
            Assert.AreEqual(4361, result);
        }

        [TestMethod]
        public void GetSumOfAllGearRatios_StandardInput_ReturnCorrectValue()
        {
            // Act
            var result = _solution.GetSumOfAllGearRatios();

            // Assert
            Assert.AreEqual(467835, result);
        }

        [TestMethod]
        public void GetSumOfAllGearRatios_GearOnSingeLine_ReturnCorrectValue()
        {
            // Arrange
            var data = new List<string>
            {
                "46...114..",
                ".27*876...",
                "46...114..",
            };
            FileReaderMock.Setup(f => f.ReadFileToStringArray(It.IsAny<string>())).Returns(data);
            _solution = new Day03Solution(FileReaderMock.Object);

            // Act
            var result = _solution.GetSumOfAllGearRatios();

            // Assert
            Assert.AreEqual(23652, result);
        }

        [TestMethod]
        public void GetSumOfAllGearRatios_GearWithMoreThanTwoParts_ReturnCorrectValue()
        {
            // Arrange
            var data = new List<string>
            {
                "461..114..",
                ".27*876...",
                "462..114..",
            };
            FileReaderMock.Setup(f => f.ReadFileToStringArray(It.IsAny<string>())).Returns(data);
            _solution = new Day03Solution(FileReaderMock.Object);

            // Act
            var result = _solution.GetSumOfAllGearRatios();

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}
