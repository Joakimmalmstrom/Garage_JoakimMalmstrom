using System;
using System.Collections.Generic;
using System.Runtime.Versioning;

namespace Garage_JoakimMalmstrom
{
    public class Car : Vehicle
    {
        public string Model { get; set; }

        public Car(string regNumber, string color, int numWheels, string model) : base(regNumber, color, numWheels)
        {
            Model = model;
        }

        public override string ToString()
        {
            return $"Regnr: {RegNumber} - Color: {Color} - NumWheels: {NumWheels} - Model: {Model}";
        }
    }
}