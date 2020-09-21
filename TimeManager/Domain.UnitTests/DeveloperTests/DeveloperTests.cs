using System;
using TimeManager.Domain.Developers;
using Xunit;

namespace TimeManager.Domain.UnitTests.DeveloperTests
{
    public class DeveloperTests
    {
        private readonly string _developerName;

        public DeveloperTests()
        {
            _developerName = "Developer de Testes";
        }

        [Fact]
        public void ShouldCreateANewDeveloper()
        {
            // Act
            var dev = new Developer(_developerName);

            //Assert
            Assert.NotEqual(Guid.Empty, dev.Id);
            Assert.Equal(_developerName, dev.Name);
        }

        [Fact]
        public void ShouldSetToInactive()
        {
            // Arrange
            var dev = new Developer(_developerName);

            // Act
            dev.SetInactive();

            // Assert

            Assert.False(dev.IsActive);
        }
    }
}
