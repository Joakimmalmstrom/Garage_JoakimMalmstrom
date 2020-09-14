using System.Collections;
using System;

namespace Garage_JoakimMalmstrom
{
    internal class GarageHandler 
    {
        public GarageHandler(int capacity)
        {

        }

        public void AddVehicle(VehicleType vehicle)
        {
            try
            {
                Console.Write("Enter Registration Number: ");
                string regNumber = Console.ReadLine();
                Console.Write("Enter Color: ");
                string color = Console.ReadLine();
                Console.Write("Enter Number of Wheels: ");
                int numWheels = int.Parse(Console.ReadLine());

                switch (vehicle)
                {
                    case VehicleType.Car:
                        Console.Write("Enter Car Model: ");
                        string model = Console.ReadLine();
                        var car = new Car(regNumber, color, numWheels, model);

                        break;

                    case VehicleType.Bus:
                        Console.Write("Enter Number of Seats: ");
                        int numSeats;
                        bool success = int.TryParse(Console.ReadLine(), out numSeats);

                        if (success)
                        {
                            var bus = new Bus(regNumber, color, numWheels, numSeats);
                        }
                        else
                            AddVehicle(vehicle);

                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                AddVehicle(vehicle);
            }
        }
    }
}