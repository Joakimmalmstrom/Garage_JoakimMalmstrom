using System;

namespace Garage_JoakimMalmstrom
{
    internal static class UI
    {
        public static void AddVehicleToGarageInfo()
        {
            Console.WriteLine("1. Add a Car");
            Console.WriteLine("2. Add a Bus");
            Console.WriteLine("3. Add a Boat");
            Console.WriteLine("4. Add a Airplane");
            Console.WriteLine("5. Add a Motorcycle");
            Console.WriteLine("--------------------");
        }

        public static void MainMenuInfo(GarageHandler garageHandler)
        {
            Console.WriteLine($"The parking capacity is: {garageHandler.Capacity}");
            Console.WriteLine($"The number of parked vehicles are: {garageHandler.Count}");
            Console.WriteLine("--------------------");
            Console.WriteLine("1. Add a vehicle to the garage");
            Console.WriteLine("2. Remove a vehicle from the garage");
            Console.WriteLine("3. Retrieve a list of parked vehicles");
            Console.WriteLine("4. Look for a vehicle registration number");
            Console.WriteLine("5. Look for a vehicle through properties");
            Console.WriteLine("--------------------");
            Console.WriteLine("6. Quit application");
            Console.WriteLine("--------------------");
        }

        internal static void SearchRegistrationNumberInfo()
        {
            Console.WriteLine($"Search Registration Number");
            Console.WriteLine("--------------------");
            Console.Write("Registration Number: ");
        }

        internal static void RemoveVehicleInfo()
        {
            Console.WriteLine($"Remove Vehicles");
            Console.WriteLine("--------------------");
            Console.Write("Type the correct registration number to remove vehicle: ");
        }

        internal static void GetParkedVehiclesInfo(GarageHandler garageHandler)
        {
            Console.WriteLine($"Parked Vehicles");
            Console.WriteLine("--------------------");
            Console.WriteLine($"Parking Capacity: {garageHandler.Capacity}");
            Console.WriteLine($"Parked Vehicles: {garageHandler.Count}");
            Console.WriteLine("--------------------");
        }

        public static void EnterToClear()
        {
            Console.ReadLine();
            Console.Clear();
        }

        public static void VehicleWasAdded(Vehicle vehicle)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine($"{vehicle} \nSuccessfully Added!");
            Console.WriteLine("--------------------");
        }

        public static void VehicleWasRemoved(Vehicle vehicle)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine($"{vehicle} \nSuccessfully Removed!");
            Console.WriteLine("--------------------");
        }
    }
}