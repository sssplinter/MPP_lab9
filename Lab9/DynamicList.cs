using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab9
{
    public class DynamicList<T> : IEnumerable
    {
        private const int ArrAccretion = 100;

        private T[] _arr;
        private int _currentIndex;
        public int Count => _currentIndex;

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
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public DynamicList()
        {
            _arr = new T[ArrAccretion];
            _currentIndex = 0;
        }

        public void Add(T newItem)
        {
            if (_currentIndex == _arr.Length)
            {
                ReorganizeArr();
            }

            _arr[_currentIndex] = newItem;
            _currentIndex++;
        }

        public void Remove(T removableItem)
        {
            for (var i = 0; i < _currentIndex; i++)
            {
                if (_arr[i].Equals(removableItem))
                {
                    ShiftArray(i);
                    _currentIndex--;
                }
            }
        }

        public void RemoveAt(int index)
        {
            if (_currentIndex > index)
            {
                ShiftArray(index);
                _currentIndex--;
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
            _currentIndex = 0;
        }

        private void ReorganizeArr()
        {
            var newSize = _arr.Length + ArrAccretion;
            Array.Resize(ref _arr, newSize);
        }

        private void ShiftArray(int index)
        {
            for (var i = index; i < _currentIndex; i++)
            {
                _arr[i] = _arr[i + 1];
            }

            // _arr[_currentIndex] = default(T);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            for (var i = 0; i < _currentIndex; i++)
            {
                builder.Append(_arr[i] + "\n");
            }

            return builder.ToString();
        }


        private IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < _currentIndex; i++)
            {
                yield return _arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}