using System.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;

namespace Garage_JoakimMalmstrom
{
    internal class GarageHandler : Garage<IVehicle>
    {
        public GarageHandler(int capacity) : base(capacity)
        {

        }
        public void GetRandomVehicles()
        {

            string regNumber = "ABC123";
            string color = "Red";
            int numWheels = 4;
            string model = "Batmobile";

            IVehicle car = new Car(regNumber, color, numWheels, model);
            IVehicle car2 = new Car("123", "Red", 4, "bla");
            IVehicle car3 = new Car("1234", "Blue", 4, "blaha");

            if (Capacity >= 3)
            {
                Add(regNumber, car);
                Add("123", car2);
                Add("1234", car3);    
            }
            else
            {
                Console.WriteLine("Need a capacity of 3 to have random vehicles in it!");
                Console.WriteLine("You'll have 0 vehicles in the garage");
                UI.EnterToClear();
            }

        }

        public void GetParkedVehicles()
        {
            UI.GetParkedVehiclesInfo(this);

            ParkedVehicles();
        }

        public void SearchRegistrationNumber()
        {
            UI.SearchRegistrationNumberInfo();

            string input = Console.ReadLine().ToUpper();

            Console.WriteLine(SearchRegistrationNumber(input));
        }

        public bool IsGarageEmpty => Count <= 0;

        public bool IsGarageFull => Capacity <= Count;

        public void RemoveVehicle()
        {
            UI.RemoveVehicleInfo();

            string input = Console.ReadLine().ToUpper();

            if (!Remove(input))
                UI.VehicleFailedRemoved(input);
        }

        public void AddVehicle(VehicleType vehicleType)
        {
            try
            {
                string regNumber, color;
                int numWheels;
                bool success;

                AddVehicleQuestions(out regNumber, out color, out numWheels);

                switch (vehicleType)
                {
                    case VehicleType.Car:
                        AddCar(regNumber, color, numWheels);
                        break;

                    case VehicleType.Bus:
                        success = AddBus(regNumber, color, numWheels);
                        break;

                    case VehicleType.Boat:
                        success = AddBoat(regNumber, color, numWheels);
                        break;

                    case VehicleType.Airplane:
                        success = AddAirplane(regNumber, color, numWheels);
                        break;

                    case VehicleType.Motorcycle:
                        Console.Write("Enter Type: ");
                        string type = Console.ReadLine();

                        var motorcycle = new Motorcycle(regNumber, color, numWheels, type);
                        Add(regNumber, motorcycle);
                        UI.VehicleWasAdded(motorcycle);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        private bool AddAirplane(string regNumber, string color, int numWheels)
        {
            bool success;
            Console.Write("Enter Number of Engines: ");
            int numEngines;
            success = int.TryParse(Console.ReadLine(), out numEngines);

            if (success)
            {
                var airplane = new Airplane(regNumber, color, numWheels, numEngines);
                Add(regNumber, airplane);
                UI.VehicleWasAdded(airplane);
            }
            else
                throw new Exception("Invalid input!");
            return success;
        }

        private bool AddBoat(string regNumber, string color, int numWheels)
        {
            bool success;
            Console.Write("Enter Length: ");
            double length;
            success = double.TryParse(Console.ReadLine(), out length);

            if (success)
            {
                var boat = new Boat(regNumber, color, numWheels, length);
                Add(regNumber, boat);
                UI.VehicleWasAdded(boat);
            }
            else
                throw new Exception("Invalid input!");
            return success;
        }

        private bool AddBus(string regNumber, string color, int numWheels)
        {
            bool success;
            Console.Write("Enter Number of Seats: ");
            int numSeats;
            success = int.TryParse(Console.ReadLine(), out numSeats);

            if (success)
            {
                var bus = new Bus(regNumber, color, numWheels, numSeats);
                Add(regNumber, bus);
                UI.VehicleWasAdded(bus);
            }
            else
                throw new Exception("Invalid input!");
            return success;
        }

        private void AddCar(string regNumber, string color, int numWheels)
        {
            Console.Write("Enter Car Model: ");
            string model = Console.ReadLine();

            var car = new Car(regNumber, color, numWheels, model);
            Add(regNumber, car);
            UI.VehicleWasAdded(car);
        }

        // !! NOT DONE !!
        // Is where I couldn't find a good solution. I did bool-checks for every input and a enum to go with it.
        // Tried googling "C# search filter" but couldn't find any answer to my problem.
        public void SearchSpecificVehicle(VehicleType vehicleType)
        {
            string input = Console.ReadLine();
            string color = "";
            int wheels = 0;
            string model = "";

            bool compileSearch = false;

            bool colorFilter = false;
            bool wheelFilter = false;
            bool modelFilter = false;

            SearchFilterType search = new SearchFilterType();

            switch (vehicleType)
            {
                case VehicleType.Car:
                    do
                    {
                        UI.CarSearchInfo(color, wheels, model);

                        switch (input)
                        {
                            case "1":
                                GetVehicleColor(out color, out colorFilter, out search);
                                break;
                            case "2":
                                wheels = GetVehicleWheels(ref wheelFilter, ref search);
                                break;
                            case "3":
                                Console.Clear();
                                Console.WriteLine("Input a Model");
                                model = Console.ReadLine();
                                Console.WriteLine($"{model} model added to the search filter");

                                modelFilter = true;
                                search = SearchFilterType.Model;
                                break;
                            case "4":
                                Console.Clear();
                                Console.WriteLine("Function not implemented");
                                compileSearch = true;
                                UI.EnterToClear();
                                break;
                            default:
                                break;
                        }
                    } while (!compileSearch);
                    break;
                default:
                    break;
            }
        }
        public void SearchFilterAllVehicles()
        {
            string color = "";
            int wheels = 0;
            bool isSearching = true;
            bool colorFilter = false;
            bool wheelFilter = false;

            SearchFilterType search = new SearchFilterType();

            do
            {
                UI.PropertySearchInfo(color, wheels);

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        GetVehicleColor(out color, out colorFilter, out search);
                        break;

                    case "2":
                        wheels = GetVehicleWheels(ref wheelFilter, ref search);
                        break;

                    case "3":
                        if (colorFilter && wheelFilter)
                            search = SearchFilterType.All;
                        Console.Clear();

                        OutputSearchFilter(color, wheels, search);

                        isSearching = false;
                        break;
                    default:
                        Console.WriteLine("Unknown input!");
                        break;
                }
            } while (isSearching);
        }

        private static void GetVehicleColor(out string color, out bool colorFilter, out SearchFilterType search)
        {
            Console.Clear();
            Console.Write("Input a Color: ");
            color = Console.ReadLine();
            Console.WriteLine($"{color} color added to the search filter");

            colorFilter = true;
            search = SearchFilterType.Color;
        }

        private static int GetVehicleWheels(ref bool wheelFilter, ref SearchFilterType search)
        {
            int wheels;
            Console.Clear();

            Console.Write("Input Number of Wheels: ");
            string numInput = Console.ReadLine();
            bool success = int.TryParse(numInput, out wheels);
            if (success)
            {
                Console.WriteLine($"{wheels} number of wheels added to the search filter");
                UI.EnterToClear();
                wheelFilter = true;
                search = SearchFilterType.Wheels;
            }
            else
                Console.WriteLine("Wrong format!");

            UI.EnterToClear();
            return wheels;
        }

        private static void AddVehicleQuestions(out string regNumber, out string color, out int numWheels)
        {
            Console.Write("Enter Registration Number: ");
            regNumber = Console.ReadLine().ToUpper();

            Console.Write("Enter Color: ");
            color = Console.ReadLine();

            Console.Write("Enter Number of Wheels: ");
            bool isCorrectFormat = int.TryParse(Console.ReadLine(), out numWheels);
            if (!isCorrectFormat)
                throw new Exception("Invalid input!");
        }
    }
}