using AdventOfCode23.Interfaces;
using Moq;

namespace AdventOfCode23.Tests
{
    public class BaseFixture
    {
        public readonly Mock<IFileReader> FileReaderMock;

        public BaseFixture()
        {
            FileReaderMock = new Mock<IFileReader>();
        }
    }
}
