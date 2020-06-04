using Monty_Hall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monty_Hall.Services
{
    public interface IMontyHallCalculator
    {
        /// <summary>
        /// Calculate the Monty Hall request
        /// </summary>
        /// <param name="model">The input model from the user</param>
        /// <returns>A decimal value representing the winning procent</returns>
        decimal Calculate(MontyHallCalculationRequestModel model);

        /// <summary>
        /// True will be returned if the door contains the "car" and false if the "goat"
        /// </summary>
        /// <param name="chosenDoor">Chosen door</param>
        /// <param name="changeDoor">Change door after "goat" door X has been revealed?</param>
        /// <returns></returns>
        bool Calculate(int chosenDoor, bool changeDoor);
    }
}
