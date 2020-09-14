using System.Collections;
using System;

namespace Garage_JoakimMalmstrom
{
    public class Garage<T> where T : Vehicle, IEnumerable
    {
        // Interface IEnumerable

        private int capacity;
        private Vehicle[] vehicles;

        public int Capacity
        {
            get { return capacity; }
            set
            {
                if (vehicles.Length == value)
                {
                    throw new Exception("The garage is full!");
                }
                capacity = value;
            }
        }

        public Garage(int capacity)
        {
            Capacity = capacity;
        }

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}