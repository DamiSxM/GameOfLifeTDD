using System;
using Xunit;

using GameOfLife;

namespace GameOfLifeTest
{
    public class SimulationTest
    {
        [Fact]
        public void Constructor_InvalidWidthAndHeightArgs_ShouldThrowException()
        {
            // Arrange
            var width = 0;
            var height = 0;
            
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Simulation(width, height));
        }

        [Fact]
        public void Constructor_ValidWidthAndInvalidHeightArgs_ShouldThrowException()
        {
            // Arrange
            var width = 1;
            var height = 0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Simulation(width, height));
        }

        [Fact]
        public void Constructor_ValidWidthAndHeightArgs_ShouldNotThrowException()
        {
            // Arrange
            var width = 1;
            var height = 1;

            // Act
            new Simulation(width, height);

            // Assert
            Assert.True(true);
        }
    }
}
