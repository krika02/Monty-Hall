using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Monty_Hall.Services;
using Monty_Hall.Models;

namespace Monty_Hall.Controllers
{
    [ApiController]
    public class MontyHallController : ControllerBase
    {
        private readonly IMontyHallCalculator _montyHallCalculator;

        public MontyHallController(IMontyHallCalculator montyHallCalculator)
        {
            _montyHallCalculator = montyHallCalculator;
        }

        /// <summary>
        /// Handel the Monty Hall-calculation request
        /// </summary>
        /// <param name="model">The input model from the user</param>
        /// <returns>A decimal value representing the winning procent in total from the user input parameters</returns>
        [HttpPost]
        [Route("monthyHall/calculate")]
        public decimal Calculate(MontyHallCalculationRequestModel model)
        {
            var result = _montyHallCalculator.Calculate(model);

            return result;
        }
    }
}
