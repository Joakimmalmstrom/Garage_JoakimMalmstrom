using System.Collections;

namespace Garage_JoakimMalmstrom
{
    internal class Garage<T> : IEnumerable
    {
        // Begränsas till fordon
        // Interface IEnumerable

        private Vehicle[] vehicles;

        public int Capacity { get; set; }

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