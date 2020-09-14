namespace Garage_JoakimMalmstrom
{
    internal class Car : Vehicle
    {
        public string Model { get; set; }
        public Car(string regNumber, string color, int numWheels, string model) : base(regNumber, color, numWheels)
        {
            Model = model;
        }
    }
}