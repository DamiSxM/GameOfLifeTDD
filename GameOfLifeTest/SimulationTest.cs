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

        [Fact]
        public void GetState_CallToGetTheGrid_ShouldReturnGridArray()
        {
            // Arrange
            var sim = new Simulation(5, 5);

            //Act
            bool[,] actualGrid = sim.GetState();

            // Assert
            var expectedGrid = new bool[5, 5];
            Assert.Equal(actualGrid, expectedGrid);
        }

        [Fact]
        public void Add_NegativeArgs_ShouldThrowException()
        {
            // Arrange
            var sim = new Simulation(5, 5);
            var x = -1;
            var y = -1;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => sim.Add(x, y));
        }

        [Fact]
        public void Add_ArgsOutOfGrid_ShouldThrowException()
        {
            // Arrange
            var sim = new Simulation(5, 5);
            var x = 6;
            var y = 6;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => sim.Add(x, y));
        }

        [Fact]
        public void Add_ValidArgs_ShouldReturnValidBoolArray()
        {
            // Arrange
            var sim = new Simulation(3, 3);

            //Act
            sim.Add(1, 1);
            bool[,] actualGrid = sim.GetState();

            // Assert
            bool[,] expectedGrid = new bool[3, 3]{
                { false, false, false },
                { false, true, false },
                { false, false, false },
            };
            Assert.Equal(actualGrid, expectedGrid);
        }
    }
}
