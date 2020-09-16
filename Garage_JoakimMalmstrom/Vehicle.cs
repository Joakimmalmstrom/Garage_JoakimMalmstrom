using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Garage_JoakimMalmstrom
{
    abstract public class Vehicle
    {
        public string RegNum { get; set; }
        public string Color { get; set; }
        public int NumWheels { get; set; }

        public Vehicle(string regNum, string color, int numWheels)
        {
            RegNum = regNum;
            Color = color;
            NumWheels = numWheels;
        }

        public abstract override string ToString();
    }
}