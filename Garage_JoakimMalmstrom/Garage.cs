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
using System.Runtime.Versioning;

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
            //if (vehicles.Length <= 0)
            //    vehicles = new T[capacity];

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
                if (v != null)
                    Console.WriteLine(v);
            }
        }

        public string SearchRegistrationNumber(string input)
        {
            foreach (var item in regNumRegister)
            {
                if (item.Key == input)
                    return $"Match Found: {item.Value}";
            }
            return $"Match NOT Found for: {input}";
        }

       
        public void OutputSearchFilter(string color, int wheels, SearchFilterType search)
        {
            foreach (var v in vehicles)
            {
                if (v != null)
                {
                    switch (search)
                    {
                        case SearchFilterType.All:
                            if (v.Color == color && v.NumWheels == wheels)
                                Console.WriteLine(v);
                            break;
                        case SearchFilterType.Color:
                            if (v.Color == color)
                                Console.WriteLine(v);
                            break;
                        case SearchFilterType.Wheels:
                            if (v.NumWheels == wheels)
                                Console.WriteLine(v);
                            break;
                        default:
                            break;
                    }

                }
            }
        }

        public void OutputVehicles()
        {
            Console.Clear();
            Console.WriteLine("Result");
            Console.WriteLine("--------------------");

            foreach (var v in vehicles)
            {
                Console.WriteLine(v);
            }
            Console.WriteLine("--------------------");
            Console.WriteLine("Search Complete!");
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