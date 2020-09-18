using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_JoakimMalmstrom
{
    public interface ICar : IVehicle
    {
        public string Model { get; set; }
    }
}
