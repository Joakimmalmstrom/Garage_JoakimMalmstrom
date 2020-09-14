namespace Garage_JoakimMalmstrom
{
    internal class Airplane : Vehicle
    {
        public bool IsPrivateJet { get; set; }
        public Airplane(string regNumber, string color, int numWheels, bool isPrivateJet) : base(regNumber, color, numWheels)
        {
            IsPrivateJet = isPrivateJet;
        }

    }
}