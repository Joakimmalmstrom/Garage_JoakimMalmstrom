namespace Garage_JoakimMalmstrom
{
    internal class Boat : Vehicle
    {
        public float Length { get; set; }
        public Boat(string regNumber, string color, int numWheels, float length) : base(regNumber, color, numWheels)
        {
            Length = length;
        }


    }
}