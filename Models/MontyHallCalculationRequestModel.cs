
namespace Monty_Hall.Models
{
    public class MontyHallCalculationRequestModel
    {
        public int Door { get; set; }
        public int ChangeDoor { get; set; }
        public int Iterations { get; set; }
    }
}