using Monty_Hall.Services;
using Monty_Hall.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monty_Hall_UnitTests.Tests
{
    public class MontyHallCalculatorTest
    {
        [TestCase(1, true, true)]
        [TestCase(2, false, true)]
        [TestCase(3, true, true)]
        [TestCase(1, false, false)]
        [TestCase(2, true, false)]
        public void Calculation_Correct(int doorNumber, bool changeDoor, bool expectedResult)
        {
            // Calculate will call GenerateRandomDoors so we will mock that function to always return the same result

            var doorCreatorMock = new Mock<IDoorCreator>();
            var doors = new List<DoorModel>()
            {
                new DoorModel(){ DoorNumber = 1, WinningOption = false},
                new DoorModel(){ DoorNumber = 2, WinningOption = true},
                new DoorModel(){ DoorNumber = 3, WinningOption = false}
            };
            doorCreatorMock.Setup(n => n.GenerateRandomDoors()).Returns(doors);

            var calculator = new MontyHallCalculator(doorCreatorMock.Object);

            var result = calculator.Calculate(doorNumber, changeDoor);

            Assert.IsTrue(result == expectedResult);
        }
    }
}
