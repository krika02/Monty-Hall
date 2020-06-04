using Monty_Hall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monty_Hall.Helpers
{
    /// <summary>
    /// Generate some random doors.
    /// </summary>
    /// <returns>A list of 3 bools. True means the "car = winning option", false means a "goat = loosing option"</returns>
    public interface IDoorCreator
    {
        List<DoorModel> GenerateRandomDoors();
    }
}
