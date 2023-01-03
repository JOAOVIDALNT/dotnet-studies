using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace generic_classes.Models
{
    public class MeuArray<T>
    {
        private static int capacity = 10;
        private T[] _array = new T[capacity];
        private int counter = 0;

        public void AddElementToArray(T element)
        {
            if (counter + 1 < 11)
            {
                _array[counter] = element;
            }
            counter++;
        }

        public T this[int index]
        {
            get {return _array[index];}
            set {_array[index] = value;}
        }
    }
}