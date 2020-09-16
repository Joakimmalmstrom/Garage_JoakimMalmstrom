using System;
using System.Collections.Generic;
using System.Runtime.Versioning;

namespace Garage_JoakimMalmstrom
{
    public class Car : Vehicle
    {
        public string Model { get; set; }

        public Car(string regNum, string color, int numWheels, string model) : base(regNum, color, numWheels)
        {
            Model = model;
        }

        public override string ToString()
        {
            return $"Vehicle: {this.GetType().Name} | Regnr: {RegNum} | Color: {Color} | Number of Wheels: {NumWheels} | Model: {Model}";
        }
    }
}