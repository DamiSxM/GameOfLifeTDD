using System;
using Xunit;

using GameOfLife;
using System.Linq;

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
            bool[,] actualGrid = sim.States.First();

            // Assert
            var expectedGrid = new bool[5, 5];
            Assert.Equal(expectedGrid, actualGrid);
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
            bool[,] actualGrid = sim.States.First();

            // Assert
            bool[,] expectedGrid = new bool[3, 3]{
                { false, false, false },
                { false, true, false },
                { false, false, false },
            };
            Assert.Equal(expectedGrid, actualGrid);
        }

        [Fact]
        public void Functionnality_CallGetStateTwice_ShouldReturnValidBehavior()
        {
            // Arrange
            var sim = new Simulation(3, 3);

            //Act
            sim.Add(1, 1);

            bool[,] actualInitialGrid = sim.States.First();
            bool[,] actualGrid = sim.States.First();

            // Assert
            bool[,] expectedGrid = new bool[3, 3];
            Assert.Equal(expectedGrid, actualGrid);
        }

        [Fact]
        public void Functionnality_CallGetStateTwice_TestBlock()
        {
            // Arrange
            var sim = new Simulation(4, 4);

            //Act
            sim.Add(1, 1);
            sim.Add(1, 2);
            sim.Add(2, 1);
            sim.Add(2, 2);

            bool[,] actualInitialGrid = sim.States.First();
            bool[,] actualGrid = sim.States.First();

            // Assert
            Assert.Equal(actualInitialGrid, actualGrid);
        }


        [Fact]
        public void Functionnality_CallGetStateTwice_TestBlinkerk()
        {
            // Arrange
            var sim = new Simulation(3, 3);

            //Act
            sim.Add(0, 1);
            sim.Add(1, 1);
            sim.Add(2, 1);

            // - - -
            // o o o
            // - - -
            bool[,] state1 = sim.States.First();

            // - o -
            // - o -
            // - o -
            bool[,] state2 = sim.States.First();

            // - - -
            // o o o
            // - - -
            bool[,] state3 = sim.States.First();

            // Assert
            Assert.Equal(state1, state3);
        }
    }
}
