using System.Collections.Generic;

namespace Garage_JoakimMalmstrom
{
    internal class Motorcycle : Vehicle, IMotorcycle
    {
        public string Type { get; set; }
        public Motorcycle(string regNum, string color, int numWheels, string type) : base(regNum, color, numWheels)
        {
            Type = type;
        }

        public override string ToString()
        {
            return $"Vehicle: {this.GetType().Name} | Regnr: {RegNum} | Color: {Color} | Number of Wheels: {NumWheels} | Type: {Type}";

        }
    }
}