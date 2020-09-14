namespace Garage_JoakimMalmstrom
{
    internal class Bus : Vehicle
    {
        public int NumSeats { get; set; }
        public Bus(string regNumber, string color, int numWheels, int numSeats) : base(regNumber, color, numWheels)
        {
            NumSeats = numSeats;
        }

        public override Vehicle AddVehicle(Vehicle vehicle)
        {
            return vehicle;
        }
    }
}