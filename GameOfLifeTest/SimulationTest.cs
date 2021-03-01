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
        public void Constructor_ValidWidthAndInvalidHeightArgs_ShouldNotThrowException()
        {
            // Arrange
            var width = 1;
            var height = 0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Simulation(width, height));
        }
    }
}
