using System;
using System.ComponentModel.DataAnnotations;

namespace Garage_JoakimMalmstrom
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity;
            SetGarageCapacity(out capacity);
            var garageHandler = new GarageHandler(capacity);
            SetStartVehicles(garageHandler);

            MainMenu(garageHandler);
        }
        private static void SetGarageCapacity(out int capacity)
        {
            bool isInvalidNumber = true;
            do
            {
                Console.Write("Enter the park capacity of the garage: ");
                bool success = int.TryParse(Console.ReadLine(), out capacity);
                switch (success)
                {
                    case true:
                        Console.WriteLine($"The park capacity is {capacity}");
                        isInvalidNumber = false;
                        break;
                    default:
                        Console.WriteLine("Invalid number!");
                        break;
                }
            } while (isInvalidNumber);
        }
        private static void SetStartVehicles(GarageHandler garageHandler)
        {
            bool isMenuActive = true;
            do
            {
                Console.WriteLine("Would you like to populate the garage from the start? (Y/N)");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "Y":
                        // TO DO: Get random vehicles with random properties
                        garageHandler.Add(new Boat("ABC", "Red", 2, 5.2));
                        isMenuActive = false;
                        break;

                    case "N":
                        // Empty garage
                        isMenuActive = false;
                        break;
                    default:
                        Console.WriteLine("Unknown command!");
                        break;
                }
            } while (isMenuActive);
        }

        private static void MainMenu(GarageHandler garageHandler)
        {
            bool isMenuActive = true;
            
            Console.Clear();
            do
            {
                Console.WriteLine("1. Add a vehicle to the garage");
                Console.WriteLine("2. Remove a vehicle from the garage");
                Console.WriteLine("3. Retrieve a list of parked vehicles");
                Console.WriteLine("4. Look for a vehicle through licence plate");
                Console.WriteLine("5. Look for a vehicle through properties");
                Console.WriteLine("--------------------");
                Console.WriteLine("6. Quit application");
                Console.WriteLine("--------------------");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        // ADD VEHICLE METHOD
                        if (garageHandler.IsFull())
                            Console.WriteLine("Garage is full!");
                        else
                            AddVehicleToGarage(garageHandler);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Remove vehicle");
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Retrieve List");
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Licence plate search");
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Property search");
                        break;
                    case "6":
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Unknown command!");
                        break;
                }

            } while (isMenuActive);
        }

        private static void AddVehicleToGarage(GarageHandler garageHandler)
        {
            UI.AddVehicleToGarageInfo();

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    garageHandler.GetVehicleType(VehicleType.Car);
                    break;
                case "2":
                    Console.Clear();
                    garageHandler.GetVehicleType(VehicleType.Bus);
                    break;
                case "3":
                    Console.Clear();
                    garageHandler.GetVehicleType(VehicleType.Boat);
                    break;
                case "4":
                    Console.Clear();
                    garageHandler.GetVehicleType(VehicleType.Airplane);
                    break;
                case "5":
                    Console.Clear();
                    garageHandler.GetVehicleType(VehicleType.Motorcycle);
                    break;
                default:
                    Console.WriteLine("Invalid Command");
                    break;
            }
        }
    }
}
