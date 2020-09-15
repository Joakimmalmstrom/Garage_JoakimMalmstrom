using Garage_JoakimMalmstrom;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace GarageUnitTests
{
    [TestClass]
    public class GarageTests
    {
        [TestMethod]
        public void AddVehicle_IncreaseCount()
        {
            var garage = new Garage<Car>(2);
            
            garage.AddVehicle(new Car("123", "red", 4, "dsa"));
            garage.AddVehicle(new Car("123", "red", 4, "dsa"));
        }
    }
}
