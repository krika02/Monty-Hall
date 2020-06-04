using Monty_Hall.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monty_Hall_UnitTests.Tests
{
    public class DoorCreatorTest
    {
        private IDoorCreator _doorCreator;

        [SetUp]
        public void Setup()
        {
            _doorCreator = new DoorCreator();
        }

        /// <summary>
        /// Ensure that there are 3 numbers of doors
        /// </summary>
        [Test]
        public void Doors_Correct_Number()
        {
            var doors = _doorCreator.GenerateRandomDoors();

            Assert.IsTrue(doors.Count == 3);
        }

        /// <summary>
        /// Ensure that 1 door is the winning option
        /// </summary>
        [Test]
        public void Doors_One_Winner()
        {
            var doors = _doorCreator.GenerateRandomDoors();

            Assert.IsTrue(doors.Count(n => n.WinningOption == true) == 1);
        }
    }
}
