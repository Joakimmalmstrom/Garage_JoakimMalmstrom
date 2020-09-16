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
                Console.Write("Would you like to populate the garage from the start? ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "Yes":
                        // TO DO: Get random vehicles with random properties
                        // TO DO: Another function than add here
                        garageHandler.GetRandomVehicles();
                        isMenuActive = false;
                        break;

                    case "No":
                        isMenuActive = false;
                        break;
                    default:
                        Console.WriteLine("Type 'Yes' or 'No'");
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
                UI.MainMenuInfo(garageHandler);

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        if (garageHandler.IsGarageFull)
                            Console.WriteLine("Garage is full!");
                        else
                            AddVehicleToGarage(garageHandler);
                        UI.EnterToClear();
                        break;

                    case "2":
                        Console.Clear();
                        garageHandler.RemoveVehicle();
                        UI.EnterToClear();
                        break;

                    case "3":
                        Console.Clear();
                        if (garageHandler.IsGarageEmpty)
                            Console.WriteLine("Garage is empty!");
                        else
                            garageHandler.GetParkedVehicles();
                        UI.EnterToClear();
                        break;

                    case "4":
                        Console.Clear();
                        if (garageHandler.IsGarageEmpty)
                            Console.WriteLine("Garage is empty!");
                        else
                            garageHandler.SearchRegistrationNumber();
                        UI.EnterToClear();
                        break;

                    case "5":
                        Console.Clear();
                        if (garageHandler.IsGarageEmpty)
                            Console.WriteLine("Garage is empty!");
                        else
                            garageHandler.SearchVehicleProperties();
                        UI.EnterToClear();
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

        // TO DO: Move this to GarageHandler
        // TO DO: Swap name to GetVehicleType
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
