using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Garage_JoakimMalmstrom
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private int capacity;
        private T[] vehicles;
        private int count;

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

        public bool IsFull()
        {
            if (Count >= Capacity)
                return true;
            else
                return false;
        }

        public void Add(T item)
        {
            vehicles[count++] = item;
        }

        public void ParkedVehicles()
        {
            foreach (var v in vehicles)
            {
                Console.WriteLine(v);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var v in vehicles)
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