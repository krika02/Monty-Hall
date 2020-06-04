using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Monty_Hall.Models;

namespace Monty_Hall.Services
{
    public class MontyHallCalculator : IMontyHallCalculator
    {
        private readonly IDoorCreator _doorCreator;

        public MontyHallCalculator(IDoorCreator doorCreator)
        {
            _doorCreator = doorCreator;
        }

        /// <summary>
        /// Calculate the Monty Hall request
        /// </summary>
        /// <param name="model">The input model from the user</param>
        /// <returns>A decimal value representing the winning procent</returns>
        public decimal Calculate(MontyHallCalculationRequestModel model)
        {
            var results = new List<bool>();
            var changeDoor = model.ChangeDoor == 1;

            // Iterate and save all the results

            for (int i = 0; i < model.Iterations; i++)
            {
                results.Add(Calculate(model.Door, changeDoor));
            }

            return Math.Round(((decimal)results.Count(n => n == true) / (decimal)model.Iterations) * 100M, 2);
        }

        /// <summary>
        /// True will be returned if the door contains the "car" and false if the "goat"
        /// </summary>
        /// <param name="chosenDoor">Chosen door</param>
        /// <param name="changeDoor">Change door after "goat" door X has been revealed?</param>
        /// <returns></returns>
        public bool Calculate(int chosenDoor, bool changeDoor)
        {
            var doors = _doorCreator.GenerateRandomDoors();

            // Pick some random door (The door Monty hall picks where there is a "goat")
            // Ofcourse this door can't be the same as the one the user picked 

            var montyDoor = doors.First(n => n.DoorNumber != chosenDoor && !n.WinningOption);

            // Now we have the "goat door" that Monty choosed. 
            // So now we can calculate if we win or loose

            // Select our final door and return the result

            chosenDoor = changeDoor ? 
                doors.First(n => n.DoorNumber != montyDoor.DoorNumber && n.DoorNumber != chosenDoor).DoorNumber // We decide to change door, select the door that Monty didn't select and the one that we did not choose first
                : chosenDoor; // We decide to keep with our first initial door

            return doors.First(n => n.DoorNumber == chosenDoor).WinningOption; // Return result
        }
    }
}
