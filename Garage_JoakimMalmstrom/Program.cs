using System;
using System.ComponentModel.DataAnnotations;

namespace Garage_JoakimMalmstrom
{
    class Program
    {
        static void Main(string[] args)
        {
            //IVehicle vehicle = new Bus("321", "321", 123, 5);

            //if (vehicle is IBus bus)
            //{
            //    bus.NumSeats = 3;
            //    Console.WriteLine(bus);
            //}

            int capacity;
            SetGarageCapacity(out capacity);
            var garageHandler = new GarageHandler(capacity);
            SetStartVehicles(garageHandler);

            MainMenu(garageHandler);
        }
        private static void SetGarageCapacity(out int capacity)
        {
            bool isCapacitySet = false;
            do
            {
                Console.Write("Enter the park capacity of the garage: ");

                bool success = int.TryParse(Console.ReadLine(), out capacity);
                if (success)
                    isCapacitySet = true;
                else
                    Console.WriteLine("Invalid format"!);

            } while (!isCapacitySet);
        }
        private static void SetStartVehicles(GarageHandler garageHandler)
        {
            bool isMenuActive = true;
            do
            {
                Console.Write("Would you like to populate the garage from the start? ");
                string input = Console.ReadLine();
                if (input == "Yes")
                {
                    garageHandler.GetRandomVehicles();
                    isMenuActive = false;
                }
                else if (input == "No")
                    isMenuActive = false;
                else
                    Console.WriteLine("Type Yes or No");

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
                            garageHandler.AddVehicle(GetVehicleType());
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
                            UI.SearchVehiclePropertiesInfo();

                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.Clear();
                                garageHandler.SearchAllVehicles();
                                break;

                            case "2":
                                Console.Clear();
                                garageHandler.SearchSpecificVehicle(GetVehicleType());
                                break;

                            default:
                                Console.WriteLine("Unknown input");
                                break;
                        }
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
        public static VehicleType GetVehicleType()
        {
            UI.AddVehicleToGarageInfo();

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    return VehicleType.Car;
                case "2":
                    Console.Clear();
                    return VehicleType.Bus;
                case "3":
                    Console.Clear();
                    return VehicleType.Boat;
                case "4":
                    Console.Clear();
                    return VehicleType.Airplane;
                case "5":
                    Console.Clear();
                    return VehicleType.Motorcycle;
                default:
                    Console.WriteLine("Invalid Command");
                    return GetVehicleType();
            }
        }
    }
}
