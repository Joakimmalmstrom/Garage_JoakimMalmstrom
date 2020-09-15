namespace Garage_JoakimMalmstrom
{
    internal class Airplane : Vehicle
    {
        public int NumEngines { get; set; }
        public Airplane(string regNumber, string color, int numWheels, int numEngines) : base(regNumber, color, numWheels)
        {
            NumEngines = numEngines;
        }

    }
}