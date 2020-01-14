using Xunit.Sdk;

namespace Xunit.Extensions.Tests
{
    public class AssertAllTest
    {
        [Fact]
        public void Execute_NoAssertPassed_NoExceptionThrown()
        {
            // Arrange & Act & Assert
            AssertAll.Exceute();
        }

        [Fact]
        public void Execute_AssertPassedSuccessful_NoExceptionThrown()
        {
            // Arrange & Act & Assert
            AssertAll.Exceute(() => Assert.True(true));
        }

        [Fact]
        public void Execute_AssertPassedFailed_XunitExceptionThrown()
        {
            // Arrange & Act & Assert
            Assert.Throws<XunitException>(() => AssertAll.Exceute(() => Assert.True(false)));
        }

        [Fact]
        public void Execute_AssertPassedFailed_ValidMessagePrefixUsed()
        {
            // Arrange
            var expectedPrefixMessage = "The following conditions failed:\n\n";

            try
            {
                // Act
                AssertAll.Exceute(() => Assert.True(false));
            }
            catch (XunitException exception)
            {
                // Assert
                Assert.StartsWith(expectedPrefixMessage, exception.Message);
            }
        }

        [Fact]
        public void Execute_AssertPassedFailed_AllMessagesCombined()
        {
            // Arrange
            var expectedFirstExceptionMessage = "First exception message";
            var expectedSecondExceptionMessage = "Second exception message";

            try
            {
                // Act
                AssertAll.Exceute(
                    () => throw new XunitException(expectedFirstExceptionMessage),
                    () => throw new XunitException(expectedSecondExceptionMessage));
            }
            catch (XunitException exception)
            {
                // Assert
                Assert.Contains(expectedFirstExceptionMessage, exception.Message);
                Assert.Contains(expectedSecondExceptionMessage, exception.Message);
            }
        }
    }
}
