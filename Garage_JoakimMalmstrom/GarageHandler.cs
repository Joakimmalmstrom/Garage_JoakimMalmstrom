using System.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;

namespace Garage_JoakimMalmstrom
{
    internal class GarageHandler : Garage<Vehicle>
    {
        private Dictionary<string, Vehicle> regNumRegister = new Dictionary<string, Vehicle>();
        public GarageHandler(int capacity) : base(capacity)
        {

        }
        public void GetRandomVehicles()
        {
            string rRegNum = "ABC123";
            var boat = new Boat(rRegNum, "Red", 2, 35);
            regNumRegister.Add(rRegNum, boat);
            Add(boat);
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

            foreach (var item in regNumRegister)
            {
                if (item.Key == input)
                    Console.WriteLine($"Match Found: {item.Value}");
                else
                    Console.WriteLine($"Match not Found!"); 
            }
        }

        public bool IsGarageEmpty => Count <= 0;

        public bool IsGarageFull => Capacity <= Count;

        public void RemoveVehicle()
        {
            UI.RemoveVehicleInfo();

            string input = Console.ReadLine().ToUpper();

            foreach (var item in regNumRegister)
            {
                if (item.Key == input)
                {
                    regNumRegister.Remove(input);
                    var tempVehicle = item.Value;
                    Remove(tempVehicle);
                    UI.VehicleWasRemoved(tempVehicle);
                    return;
                }
            }
            Console.WriteLine("There's no vehicle with that registration number");
        }
        public void GetVehicleType(VehicleType vehicleType)
        {
            try
            {
                string regNumber, color;
                int numWheels;
                bool isCorrectFormat;

                AddVehicleQuestions(out regNumber, out color, out numWheels);

                switch (vehicleType)
                {
                    case VehicleType.Car:
                        Console.Write("Enter Car Model: ");
                        string model = Console.ReadLine();

                        var car = new Car(regNumber, color, numWheels, model);
                        regNumRegister.Add(regNumber, car);
                        Add(car);
                        UI.VehicleWasAdded(car);
                        break;

                    case VehicleType.Bus:
                        Console.Write("Enter Number of Seats: ");
                        int numSeats;
                        isCorrectFormat = int.TryParse(Console.ReadLine(), out numSeats);

                        if (isCorrectFormat)
                        {
                            var bus = new Bus(regNumber, color, numWheels, numSeats);
                            regNumRegister.Add(regNumber, bus);
                            Add(bus);
                            UI.VehicleWasAdded(bus);
                        }
                        else
                            throw new Exception("Invalid input!");
                        break;

                    case VehicleType.Boat:
                        Console.Write("Enter Length: ");
                        double length;
                        isCorrectFormat = double.TryParse(Console.ReadLine(), out length);

                        if (isCorrectFormat)
                        {
                            var boat = new Boat(regNumber, color, numWheels, length);
                            regNumRegister.Add(regNumber, boat);
                            Add(boat);
                            UI.VehicleWasAdded(boat);
                        }
                        else
                            throw new Exception("Invalid input!");
                        break;

                    case VehicleType.Airplane:
                        Console.Write("Enter Number of Engines: ");
                        int numEngines;
                        isCorrectFormat = int.TryParse(Console.ReadLine(), out numEngines);

                        if (isCorrectFormat)
                        {
                            var airplane = new Airplane(regNumber, color, numWheels, numEngines);
                            regNumRegister.Add(regNumber, airplane);
                            Add(airplane);
                        }
                        else
                            throw new Exception("Invalid input!");
                        break;

                    case VehicleType.Motorcycle:
                        Console.Write("Enter Type: ");
                        string type = Console.ReadLine();

                        var motorcycle = new Motorcycle(regNumber, color, numWheels, type);
                        regNumRegister.Add(regNumber, motorcycle);
                        Add(motorcycle);
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

        internal void SearchVehicleProperties()
        {
            Console.WriteLine("Search for Vehicle Properties");
            Console.WriteLine("--------------------");

            Console.WriteLine("1. Look through all vehicles");
            Console.WriteLine("2. Look through specific vehicles");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    SearchAllVehicles();
                    break;
                case "2":
                    SearchSpecificVehicle();
                    break;
                default:
                    Console.WriteLine("Unknown Input!");
                    break;
            }
        }

        private void SearchSpecificVehicle()
        {
            throw new NotImplementedException();
        }

        private void SearchAllVehicles()
        {
            bool isCompiled = true;
            do
            {
                Console.WriteLine("1. Look for Colors");
                Console.WriteLine("2. Look for Amount of Wheels");
                string input = Console.ReadLine();

                switch (input)
                {
                    
                    case "1":
                        foreach (var item in regNumRegister)
                        {
                            if (item.Value.Color == input)
                            {
                                // tempVariable or vehicles[] array = item.Value;
                            }
                        }
                        break;

                    case "2":
                        foreach (var item in regNumRegister)
                        {
                            //if (item.Value.NumWheels == int.TryParse(input, out input))
                            //{

                            //}
                        }
                        break;
                    default:
                        Console.WriteLine("Unknown Input!");
                        break;
                }
            } while (isCompiled);
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