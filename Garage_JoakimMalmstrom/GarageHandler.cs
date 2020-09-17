using System.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;

namespace Garage_JoakimMalmstrom
{
    internal class GarageHandler : Garage<Vehicle>
    {
        public GarageHandler(int capacity) : base(capacity)
        {

        }
        public void GetRandomVehicles()
        {
            string regNumber = "ABC123";
            var boat = new Boat(regNumber, "Red", 2, 35);
            Add(regNumber, boat);
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

            Console.WriteLine(SearchNumber(input));
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
                        Console.Write("Enter Car Model: ");
                        string model = Console.ReadLine();

                        var car = new Car(regNumber, color, numWheels, model);
                        Add(regNumber, car);
                        UI.VehicleWasAdded(car);
                        break;

                    case VehicleType.Bus:
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
                        break;

                    case VehicleType.Boat:
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
                        break;

                    case VehicleType.Airplane:
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

        public void SearchSpecificVehicle(VehicleType vehicleType)
        {
            string input = Console.ReadLine();
            switch (vehicleType)
            {
                case VehicleType.Car:
                    // all cars
                    // cars with color
                    // cars with wheels
                    // cars with 
                default:
                    break;
            }
        }

        public void SearchAllVehicles()
        {
            PropertySearch();
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