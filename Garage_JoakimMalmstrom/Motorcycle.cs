namespace Garage_JoakimMalmstrom
{
    internal class Motorcycle : Vehicle
    {
        public string Type { get; set; }
        public Motorcycle(string regNumber, string color, int numWheels, string type) : base(regNumber, color, numWheels)
        {
            Type = type;
        }

    }
}