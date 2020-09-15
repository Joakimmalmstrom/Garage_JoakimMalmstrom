namespace Garage_JoakimMalmstrom
{
    internal class Boat : Vehicle
    {
        public double Length { get; set; }
        public Boat(string regNumber, string color, int numWheels, double length) : base(regNumber, color, numWheels)
        {
            Length = length;
        }


    }
}