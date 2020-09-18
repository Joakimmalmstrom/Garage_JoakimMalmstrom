using System.Collections.Generic;

namespace Garage_JoakimMalmstrom
{
    internal class Airplane : Vehicle, IAirplane
    {
        public int NumEngines { get; set; }
        public Airplane(string regNum, string color, int numWheels, int numEngines) : base(regNum, color, numWheels)
        {
            NumEngines = numEngines;
        }

        public override string ToString()
        {
            return $"Vehicle: {this.GetType().Name} | Regnr: {RegNum} | Color: {Color} | Number of Wheels: {NumWheels} | Number of Engines: {NumEngines}";
        }
    }
}