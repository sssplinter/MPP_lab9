using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;


namespace Lab9
{
    public class DynamicList<T> : IEnumerable
    {
        private const int ArrAccretion = 100;
        
        private T[] _arr;
        public int Count { get; set; }

        public T this[int index]
        {
            get
            {
                if (_arr != null && _arr.Length > index)
                {
                    return _arr[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (_arr != null)
                {
                    if (_arr.Length < index)
                    {
                        ReorganizeArr();
                    }

                    _arr[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("DynamicList was not initialised");
                }
            }
        }

        public DynamicList()
        {
            _arr = new T[ArrAccretion];
            Count = 0;
        }

        public void Add(T newItem)
        {
            if (Count == _arr.Length)
            {
                ReorganizeArr();
            }

            _arr[Count] = newItem;
            Count++;
        }

        public void Remove(T removableItem)
        {
            for (var i = 0; i < Count; i++)
            {
                if (_arr[i].Equals(removableItem))
                {
                    ShiftArray(i);
                    Count--;
                }
            }
        }

        public void RemoveAt(int index)
        {
            if (Count > index)
            {
                ShiftArray(index);
                Count--;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Clear()
        {
            
            Array.Clear(_arr, 0, _arr.Length);
            Array.Resize(ref _arr, 0);
            Count = 0;
        }

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        private void ReorganizeArr()
        {
            var newSize = _arr.Length + ArrAccretion;
            Array.Resize(ref _arr, newSize);
        }

        private void ShiftArray(int index)
        {
            for (var i = index; i < Count; i++)
            {
                _arr[i] = _arr[i + 1];
            }

            _arr[Count] = default(T);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            
            for(var i = 0; i < Count; i++)
            {
                builder.Append(_arr[i] + "\n");
            }

            return builder.ToString();
        }
    }
}