using Garage_JoakimMalmstrom;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace GarageUnitTests
{
    [TestClass]
    public class GarageTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var garagetest = new Garage<Vehicle>(2);
        }
    }
}
