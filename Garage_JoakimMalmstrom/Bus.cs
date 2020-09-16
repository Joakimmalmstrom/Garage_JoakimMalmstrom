using System.Collections.Generic;

namespace Garage_JoakimMalmstrom
{
    internal class Bus : Vehicle
    {
        public int NumSeats { get; set; }
        public Bus(string regNum, string color, int numWheels, int numSeats) : base(regNum, color, numWheels)
        {
            NumSeats = numSeats;
        }

        public override string ToString()
        {
            return $"Vehicle: {this.GetType().Name} | Regnr: {RegNum} | Color: {Color} | Number of Wheels: {NumWheels} | Number of Seats: {NumSeats}";

        }
    }
}