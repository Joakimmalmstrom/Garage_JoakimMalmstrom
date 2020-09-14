namespace Garage_JoakimMalmstrom
{
    abstract public class Vehicle
    {
        public string RegNumber { get; set; }
        public string Color { get; set; }
        public int NumWheels { get; set; }

        public Vehicle(string regNumber, string color, int numWheels)
        {
            RegNumber = regNumber;
            Color = color;
            NumWheels = numWheels;
        }
    }
}