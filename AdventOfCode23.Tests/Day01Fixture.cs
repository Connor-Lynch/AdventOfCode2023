using AdventOfCode23.Solutions.Day01;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AdventOfCode23.Tests
{
    [TestClass]
    public class Day01Fixture : BaseFixture
    {
        private Day01Solution _solution;

        public Day01Fixture()
        {
            _solution = new Day01Solution(FileReaderMock.Object);
        }

        [TestMethod]
        public void GetSumOfCalibratedValues_StandardInput_ReturnCorrectValue()
        {
            // Arrange
            var data = new List<string>
            {
                "1abc2",
                "pqr3stu8vwx",
                "a1b2c3d4e5f",
                "treb7uchet",
            };
            FileReaderMock.Setup(f => f.ReadFileToStringArray(It.IsAny<string>())).Returns(data);
            _solution = new Day01Solution(FileReaderMock.Object);

            // Act
            var result = _solution.GetSumOfCalibratedValues();

            // Assert
            Assert.AreEqual(142, result);
        }

        [TestMethod]
        public void GetSumOfCalibratedValues_ComplexInput_ReturnCorrectValue()
        {
            // Arrange
            var data = new List<string>
            {
                "two1nine",
                "eightwothree",
                "abcone2threexyz",
                "xtwone3four",
                "4nineeightseven2",
                "zoneight234",
                "7pqrstsixteen",
            };
            FileReaderMock.Setup(f => f.ReadFileToStringArray(It.IsAny<string>())).Returns(data);
            _solution = new Day01Solution(FileReaderMock.Object);

            // Act
            var result = _solution.GetSumOfCalibratedValues(true);

            // Assert
            Assert.AreEqual(281, result);
        }

        [TestMethod]
        public void GetSumOfCalibratedValues_ComplexInputWithMultipleOccurrences_ReturnCorrectValue()
        {
            // Arrange
            var data = new List<string>
            {
                "8twoonesevenone",
                "1sdkjfh1",
            };
            FileReaderMock.Setup(f => f.ReadFileToStringArray(It.IsAny<string>())).Returns(data);
            _solution = new Day01Solution(FileReaderMock.Object);

            // Act
            var result = _solution.GetSumOfCalibratedValues(true);

            // Assert
            Assert.AreEqual(92, result);
        }
    }
}