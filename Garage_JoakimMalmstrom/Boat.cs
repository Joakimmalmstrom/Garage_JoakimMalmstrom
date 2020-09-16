using System.Collections.Generic;

namespace Garage_JoakimMalmstrom
{
    internal class Boat : Vehicle
    {
        public double Length { get; set; }
        public Boat(string regNum, string color, int numWheels, double length) : base(regNum, color, numWheels)
        {
            Length = length;
        }
        
        public override string ToString()
        {
            return $"Vehicle: {this.GetType().Name} | Regnr: {RegNum} | Color: {Color} | Number of Wheels: {NumWheels} | Length: {Length}";
        }
    }
}