using System.Collections;
using System;
using System.Collections.Generic;

namespace Garage_JoakimMalmstrom
{
    internal class GarageHandler : Garage<Vehicle>
    {
        public GarageHandler(int capacity) : base(capacity)
        {
            
        }

        public void GetVehicleType(VehicleType vehicle)
        {
            try
            {
                string regNumber, color;
                int numWheels;
                VehicleQuestions(out regNumber, out color, out numWheels);
                bool isCorrectFormat;

                switch (vehicle)
                {
                    case VehicleType.Car:
                        Console.Write("Enter Car Model: ");
                        string model = Console.ReadLine();
                        
                        Add(new Car(regNumber, color, numWheels, model));
                        break;

                    case VehicleType.Bus:
                        Console.Write("Enter Number of Seats: ");
                        int numSeats;
                        isCorrectFormat = int.TryParse(Console.ReadLine(), out numSeats);

                        if (isCorrectFormat)
                            Add(new Bus(regNumber, color, numWheels, numSeats));
                        else
                            GetVehicleType(vehicle);
                        break;

                    case VehicleType.Boat:
                        Console.Write("Enter Length: ");
                        double length;
                        isCorrectFormat = double.TryParse(Console.ReadLine(), out length);

                        if (isCorrectFormat)
                            Add(new Boat(regNumber, color, numWheels, length));
                        else
                            GetVehicleType(vehicle);
                        break;

                    case VehicleType.Airplane:
                        Console.Write("Enter Number of Engines: ");
                        int numEngines;
                        isCorrectFormat = int.TryParse(Console.ReadLine(), out numEngines);

                        if (isCorrectFormat)
                            Add(new Airplane(regNumber, color, numWheels, numEngines));
                        else
                            GetVehicleType(vehicle);
                        break;

                    case VehicleType.Motorcycle:
                        Console.Write("Enter Type: ");
                        string type = Console.ReadLine();

                        Add(new Motorcycle(regNumber, color, numWheels, type));
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                GetVehicleType(vehicle);
            }
        }

        private static void VehicleQuestions(out string regNumber, out string color, out int numWheels)
        {
            Console.Write("Enter Registration Number: ");
            regNumber = Console.ReadLine();
            Console.Write("Enter Color: ");
            color = Console.ReadLine();
            Console.Write("Enter Number of Wheels: ");
            numWheels = int.Parse(Console.ReadLine());
        }
    }
}