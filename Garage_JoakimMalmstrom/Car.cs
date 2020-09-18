using System;
using System.Collections.Generic;
using System.Runtime.Versioning;

namespace Garage_JoakimMalmstrom
{
    public class Car : Vehicle, ICar
    {
        public string Model { get; set; }

        public Car(string regNum, string color, int numWheels, string model) : base(regNum, color, numWheels)
        {
            Model = model;
            var vehicle = new Boat("321", "321", 321, 321);
        }

        public override string ToString()
        {
            return $"Vehicle: {this.GetType().Name} | Regnr: {RegNum} | Color: {Color} | Number of Wheels: {NumWheels} | Model: {Model}";
        }
    }
}