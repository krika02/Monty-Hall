using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Monty_Hall.Helpers;
using Monty_Hall.Models;

namespace Monty_Hall.Controllers
{
    [ApiController]
    public class MontyHallController : ControllerBase
    {
        /// <summary>
        /// Handel the Monty Hall-calculation request
        /// </summary>
        /// <param name="model">The input model from the user</param>
        /// <returns>A decimal value representing the winning procent in total from the user input parameters</returns>
        [HttpPost]
        [Route("monthyHall/calculate")]
        public decimal Calculate(MontyHallCalculationRequestModel model)
        {
            var montyHallCalculator = new MontyHallCalculator();
            var result = montyHallCalculator.Calculate(model);

            return result;
        }
    }
}
