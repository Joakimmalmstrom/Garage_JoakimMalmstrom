using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Garage_JoakimMalmstrom
{
    public interface IVehicle
    {
        string RegNum { get; set; }
        string Color { get; set; }
        int NumWheels { get; set; }
        string ToString();

    }
}