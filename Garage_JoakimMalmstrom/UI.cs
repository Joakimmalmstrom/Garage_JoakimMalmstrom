using System;

namespace Garage_JoakimMalmstrom
{
    internal static class UI
    {
        public static void AddVehicleToGarageInfo()
        {
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Bus");
            Console.WriteLine("3. Boat");
            Console.WriteLine("4. Airplane");
            Console.WriteLine("5. Motorcycle");
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

        internal static void PropertySearchInfo(string color, int wheels)
        {
            Console.WriteLine("1. Input for Color");
            Console.WriteLine("2. Input for Number of Wheels");
            Console.WriteLine("--------------------");
            Console.WriteLine("3. Compile Results");
            Console.WriteLine("--------------------");
            if (color != "" || wheels <= 0)
            Console.WriteLine($"Search Filter: Color: {color} || Number of Wheels: {wheels}");
        }

        internal static void SearchCompleteInfo()
        {
            Console.Clear();
            Console.WriteLine("Result");
            Console.WriteLine("--------------------");
        }

        public static void VehicleWasRemoved(IVehicle vehicle)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine($"{vehicle} \nSuccessfully Removed!");
            Console.WriteLine("--------------------");
        }

        public static void VehicleFailedRemoved(string input)
        {
            Console.WriteLine($"No match for registration number: {input}");
        }

        internal static void SearchVehiclePropertiesInfo()
        {
            Console.WriteLine("Search for Vehicle Properties");
            Console.WriteLine("--------------------");

            Console.WriteLine("1. Look through all vehicles");
            Console.WriteLine("2. Look through specific vehicles");
        }

        internal static void CarSearchInfo(string color, int wheels, string model)
        {
            Console.WriteLine("1. Input for Color");
            Console.WriteLine("2. Input for Number of Wheels");
            Console.WriteLine("3. Input for Model");
            Console.WriteLine("--------------------");
            Console.WriteLine("4. Compile Results");
            Console.WriteLine("--------------------");
            if (color != "" || wheels <= 0 || model != "")
                Console.WriteLine($"Search Filter: Color: {color} || Number of Wheels: {wheels} || Model: {model}");
        }

        internal static void BusSearchInfo(string color, int wheels, int seats)
        {
            Console.WriteLine("1. Input for Color");
            Console.WriteLine("2. Input for Number of Wheels");
            Console.WriteLine("3. Input for Number of Seats");
            Console.WriteLine("--------------------");
            Console.WriteLine("4. Compile Results");
            Console.WriteLine("--------------------");
            if (color != "" || wheels <= 0 || seats != 0)
                Console.WriteLine($"Search Filter: Color: {color} || Number of Wheels: {wheels} || Number of Seats: {seats}");
        }

        internal static void BoatInfo(string color, int wheels, double length)
        {
            Console.WriteLine("1. Input for Color");
            Console.WriteLine("2. Input for Number of Wheels");
            Console.WriteLine("3. Input for Length");
            Console.WriteLine("--------------------");
            Console.WriteLine("4. Compile Results");
            Console.WriteLine("--------------------");
            if (color != "" || wheels <= 0 || length != 0)
                Console.WriteLine($"Search Filter: Color: {color} || Number of Wheels: {wheels} || Length: {length}");
        }

        internal static void AirplaneInfo(string color, int wheels, int engines)
        {
            Console.WriteLine("1. Input for Color");
            Console.WriteLine("2. Input for Number of Wheels");
            Console.WriteLine("3. Input for Number of Engines");
            Console.WriteLine("--------------------");
            Console.WriteLine("4. Compile Results");
            Console.WriteLine("--------------------");
            if (color != "" || wheels <= 0 || engines != 0)
                Console.WriteLine($"Search Filter: Color: {color} || Number of Wheels: {wheels} || Number of Engines: {engines}");
        }

        internal static void MotorcycleInfo(string color, int wheels, string type)
        {
            Console.WriteLine("1. Input for Color");
            Console.WriteLine("2. Input for Number of Wheels");
            Console.WriteLine("3. Input for Type");
            Console.WriteLine("--------------------");
            Console.WriteLine("4. Compile Results");
            Console.WriteLine("--------------------");
            if (color != "" || wheels <= 0 || type != "")
                Console.WriteLine($"Search Filter: Color: {color} || Number of Wheels: {wheels} || Type: {type}");
        }
    }
}