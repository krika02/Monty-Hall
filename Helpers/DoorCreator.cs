using Monty_Hall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monty_Hall.Helpers
{
    public class DoorCreator : IDoorCreator
    {
        private readonly Random _random;

        public DoorCreator()
        {
            _random = new Random();
        }

        /// <summary>
        /// Generate some random doors.
        /// </summary>
        /// <returns>A list of 3 bools. True means the "car = winning option", false means a "goat = loosing option"</returns>
        public List<DoorModel> GenerateRandomDoors()
        {
            var rightDoor = _random.Next(1, 4);
            var doors = new List<DoorModel>();

            for (int i = 1; i < 4; i++)
            {
                doors.Add(new DoorModel
                {
                    DoorNumber = i,
                    WinningOption = rightDoor == i
                });
            }

            return doors;
        }
    }
}
