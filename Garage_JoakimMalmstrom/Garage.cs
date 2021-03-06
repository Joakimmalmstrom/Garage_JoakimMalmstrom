﻿using System;
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
                if (item.Key.Equals(input))
                    return $"Match Found: {item.Value}";
            }
            return $"Match NOT Found for: {input}";
        }


        public void OutputSearchFilter(string color, int wheels, SearchFilterType search)
        {
            UI.SearchCompleteInfo();

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
            Console.WriteLine("--------------------");
        }

        public void OutputCar(string color, int wheels, string model, SearchFilterType search)
        {
            UI.SearchCompleteInfo();
            foreach (var v in vehicles)
            {
                if (v != null && v is Car car)
                {
                    switch (search)
                    {
                        case SearchFilterType.All:
                            if (car.Color.Equals(color) && car.NumWheels.Equals(wheels) && car.Model.Equals(model))
                                Console.WriteLine(car);
                            break;
                        case SearchFilterType.Color:
                            if (car.Color.Equals(color))
                                Console.WriteLine(car);
                            break;
                        case SearchFilterType.Wheels:
                            if (car.NumWheels.Equals(wheels))
                                Console.WriteLine(car);
                            break;
                        case SearchFilterType.Model:
                            if (car.Model.Equals(model))
                                Console.WriteLine(car);
                            break;
                        default:
                            break;
                    }
                }
            }
            Console.WriteLine("--------------------");
        }

        public void OutputBus(string color, int wheels, int seats, SearchFilterType search)
        {
            UI.SearchCompleteInfo();
            foreach (var v in vehicles)
            {
                if (v != null && v is Bus bus)
                {
                    switch (search)
                    {
                        case SearchFilterType.All:
                            if (bus.Color.Equals(color) && bus.NumWheels.Equals(wheels) && bus.NumSeats.Equals(seats))
                                Console.WriteLine(bus);
                            break;
                        case SearchFilterType.Color:
                            if (bus.Color.Equals(color))
                                Console.WriteLine(bus);
                            break;
                        case SearchFilterType.Wheels:
                            if (bus.NumWheels.Equals(wheels))
                                Console.WriteLine(bus);
                            break;
                        case SearchFilterType.Seats:
                            if (bus.NumSeats.Equals(seats))
                                Console.WriteLine(bus);
                            break;
                        default:
                            break;
                    }
                }
            }
            Console.WriteLine("--------------------");
        }

        public void OutputBoat(string color, int wheels, double length, SearchFilterType search)
        {
            UI.SearchCompleteInfo();
            foreach (var v in vehicles)
            {
                if (v != null && v is Boat boat)
                {
                    switch (search)
                    {
                        case SearchFilterType.All:
                            if (boat.Color.Equals(color) && boat.NumWheels.Equals(wheels) && boat.Length.Equals(length))
                                Console.WriteLine(boat);
                            break;
                        case SearchFilterType.Color:
                            if (boat.Color.Equals(color))
                                Console.WriteLine(boat);
                            break;
                        case SearchFilterType.Wheels:
                            if (boat.NumWheels.Equals(wheels))
                                Console.WriteLine(boat);
                            break;
                        case SearchFilterType.Length:
                            if (boat.Length.Equals(boat))
                                Console.WriteLine(boat);
                            break;
                        default:
                            break;
                    }
                }
            }
            Console.WriteLine("--------------------");
        }

        public void OutputAirplane(string color, int wheels, int engines, SearchFilterType search)
        {
            UI.SearchCompleteInfo();
            foreach (var v in vehicles)
            {
                if (v != null && v is Airplane airplane)
                {
                    switch (search)
                    {
                        case SearchFilterType.All:
                            if (airplane.Color.Equals(color) && airplane.NumWheels.Equals(wheels) && airplane.NumEngines.Equals(engines))
                                Console.WriteLine(airplane);
                            break;
                        case SearchFilterType.Color:
                            if (airplane.Color.Equals(color))
                                Console.WriteLine(airplane);
                            break;
                        case SearchFilterType.Wheels:
                            if (airplane.NumWheels.Equals(wheels))
                                Console.WriteLine(airplane);
                            break;
                        case SearchFilterType.Engines:
                            if (airplane.NumEngines.Equals(engines))
                                Console.WriteLine(airplane);
                            break;
                        default:
                            break;
                    }
                }
            }
            Console.WriteLine("--------------------");
        }

        public void OutputMotorcycle(string color, int wheels, string type, SearchFilterType search)
        {
            UI.SearchCompleteInfo();
            foreach (var v in vehicles)
            {
                if (v != null && v is Motorcycle motorcycle)
                {
                    switch (search)
                    {
                        case SearchFilterType.All:
                            if (motorcycle.Color.Equals(color) && motorcycle.NumWheels.Equals(wheels) && motorcycle.Type.Equals(type))
                                Console.WriteLine(motorcycle);
                            break;
                        case SearchFilterType.Color:
                            if (motorcycle.Color.Equals(color))
                                Console.WriteLine(motorcycle);
                            break;
                        case SearchFilterType.Wheels:
                            if (motorcycle.NumWheels.Equals(wheels))
                                Console.WriteLine(motorcycle);
                            break;
                        case SearchFilterType.Type:
                            if (motorcycle.Type.Equals(type))
                                Console.WriteLine(motorcycle);
                            break;
                        default:
                            break;
                    }
                }
            }
            Console.WriteLine("--------------------");
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