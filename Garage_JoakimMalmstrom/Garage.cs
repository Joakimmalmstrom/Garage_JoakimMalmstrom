using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace Garage_JoakimMalmstrom
{
    public class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        private int capacity;
        private T[] vehicles;
        private int count;

        private Dictionary<string, T> regNumRegister = new Dictionary<string, T>();

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public Garage(int capacity)
        {
            Capacity = capacity;
            vehicles = new T[capacity];
        }

        public void Add(string regNumber, T vehicle)
        {
            if (vehicles.Length <= 0)
                vehicles = new T[capacity];

            vehicles[count++] = vehicle;
            regNumRegister.Add(regNumber, vehicle);
        }

        public bool Remove(string input)
        {
            foreach (var v in vehicles)
            {
                if (v != null && v.RegNum == input)
                {
                    regNumRegister.Remove(input);
                    vehicles = vehicles.Where(t => t != null && t.RegNum != v.RegNum).ToArray();
                    count--;

                    UI.VehicleWasRemoved(v);
                    return true;
                }
            }
            return false;
        }

        public void ParkedVehicles()
        {
            foreach (var v in vehicles)
            {
                Console.WriteLine(v);
            }
        }

        public string SearchNumber(string input)
        {
            foreach (var item in regNumRegister)
            {
                if (item.Key == input)
                    return $"Match Found: {item.Value}";
            }
            return $"Match NOT Found for: {input}";
        }

        // REWRITE WITH INTERFACE
        //public void PropertySearch()
        //{
        //    string color = "";
        //    int wheels = 0;
        //    bool isSearching = true;

        //    do
        //    {
        //        UI.PropertySearchInfo(color, wheels);

        //        string input = Console.ReadLine();

        //        switch (input)
        //        {
        //            case "1":
        //                Console.Clear();
        //                Console.Write("Input a Color: ");
        //                color = Console.ReadLine();
        //                Console.WriteLine($"{color} color added to the search filter");
        //                UI.EnterToClear();
        //                break;

        //            case "2":
        //                Console.Clear();
        //                Console.Write("Input Number of Wheels: ");
        //                string numInput = Console.ReadLine();
        //                bool success = int.TryParse(numInput, out wheels);
        //                if (success)
        //                {
        //                    Console.WriteLine($"{wheels} number of wheels added to the search filter");
        //                    UI.EnterToClear();
        //                    break;
        //                }
        //                else
        //                    Console.WriteLine("Wrong format!");
        //                UI.EnterToClear();
        //                break;

        //            case "3":
        //                var tempVehicles = from vehicle in vehicles
        //                                   where vehicle != null && vehicle.Color == color && vehicle.NumWheels == wheels
        //                                   select vehicle;

        //                OutputVehicles(tempVehicles);
        //                isSearching = false;
        //                break;

        //            case "4":
        //                var colorVehicles = from vehicle in vehicles
        //                                    where vehicle != null && vehicle.Color == color
        //                                    select vehicle;
        //                OutputVehicles(colorVehicles);
        //                isSearching = false;
        //                break;

        //            case "5":
        //                var wheelVehicles = from vehicle in vehicles
        //                                    where vehicle != null && vehicle.NumWheels == wheels
        //                                    select vehicle;

        //                OutputVehicles(wheelVehicles);
        //                isSearching = false;
        //                break;
        //            default:
        //                Console.WriteLine("Unknown input!");
        //                break;
        //        }
        //    } while (isSearching);
        //}

        public void SpecificVehicleSearch(VehicleType vehicleType)
        {
            switch (vehicleType)
            {
                case VehicleType.Car:
                    Console.WriteLine("inside cars");
                    Console.ReadLine();
                    // 1. Search Color (T)
                    // 2. Search NumWheels (T)
                    // 3. Search Model ()
                    // -------------------------------
                    // 4. Output SearchFilters based on Input
                    // 5. PrintAllCars(); (T)
                    break;
                case VehicleType.Bus:
                    break;
                case VehicleType.Boat:
                    break;
                case VehicleType.Airplane:
                    break;
                case VehicleType.Motorcycle:
                    break;
                default:
                    break;
            }
        }

        //private IEnumerable<T> CheckAllSpecificVehicles(string className)
        //{
        //    var v = from vehicle in vehicles
        //            where vehicle != null && vehicle.GetType().Name == className
        //            select vehicle;
        //    return v;
        //}

        public void OutputVehicles(T tempVehicle)
        {
            //Console.Clear();
            //Console.WriteLine("Result");
            //Console.WriteLine("--------------------");
            //foreach (T v in tempVehicle)
            //{
            //    Console.WriteLine(v);
            //}
            //Console.WriteLine("--------------------");
            //Console.WriteLine("Search Complete!");
        }


        public IEnumerator<T> GetEnumerator()
        {
            foreach (T v in vehicles)
            {
                yield return v;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}