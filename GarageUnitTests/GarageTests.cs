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
        public void Add_IncreaseCount()
        {
            var garage = new Garage<Vehicle>(2);

            garage.Add(new Car("123", "red", 4, "dsa"));
            var expectedCount = 1;
            var actualCount = garage.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void IsFull_ReturnTrue()
        {
            var garage = new Garage<Vehicle>(0);
            bool isFull;

            if (garage.Count >= garage.Capacity)
                isFull = true;
            else
                isFull = false;

            Assert.IsTrue(isFull);
        }
    }
}
