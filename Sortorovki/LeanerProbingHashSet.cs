using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortorovki
{
   public class LeanerProbingHashSet<TKey, TValue> //Метод линейного пробирования для коллизий
    {
        private const int DefaultCapacity = 4;
        public int Count { get; private set; }
        public int Capacity { get; private set; }
        private TKey[] _keys;
        private TValue[] _values;

        public LeanerProbingHashSet(int capacity)
        {
            Capacity = capacity;
            _keys = new TKey[capacity];
            _values = new TValue[capacity];
        }

        public LeanerProbingHashSet():this(DefaultCapacity)
        {
        }

        private int Hash(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff) % Capacity; //взятие индекса основанного на хэш-функции
            //вычислили хэш и пребразовали в индекс
            //& 0x7fffffff - для избежания отрицательный хешей применена битовая маска
        }

        public bool Contains(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Key can`t be null");
            for (int i = Hash(key); _keys[i] != null; i=(i+1)%Capacity)
            {
                if (_keys[i].Equals(key))
                {
                    return true;
                }
            }
            return false; 
        }

        public TValue Get(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Key can`t be null");
            for (int i = Hash(key); _keys[i] != null; i = (i + 1) % Capacity)
            {
                if (_keys[i].Equals(key))
                {
                    return _values[i];
                }
            }
            throw new ArgumentNullException("Key was not found");
        }

        public bool TryGet(TKey key, out int index)
        {
            if (key == null)
                throw new ArgumentNullException("Key can`t be null");
            for (int i = Hash(key); _keys[i] != null; i = (i + 1) % Capacity)
            {
                if (_keys[i].Equals(key))
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }

        public void Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Key can`t be null");
            if (!TryGet(key, out int index))
                return;
            _keys[index] = default(TKey);
            _values[index] = default(TValue);

            index = (index + 1) % Capacity;

            while (_keys[index] != null)
            {
                TKey keyToRehash = _keys[index];
                TValue valueToRehash = _values[index];

                _keys[index] = default(TKey);
                _values[index] = default(TValue);

                Count--;
                Add(keyToRehash, valueToRehash);
                index = (index + 1) % Capacity;
            }
            Count--;
            if (Count > 0 && Count <= Capacity / 8)
                Resize(Capacity/2);
        }

        private void Resize(int capasity)
        {
            var temp = new LeanerProbingHashSet<TKey, TValue>(capasity);
            for (int i = 0; i < Capacity; i++)
            {
                if (_keys[i]!=null)
                {
                    temp.Add(_keys[i], _values[i]);
                }
            }
            _keys = temp._keys;
            _values = temp._values;
            Capacity = temp.Capacity;
        }

        private void Add(TKey? key, TValue? value)
        {
            if (key == null)
                throw new ArgumentNullException("Key can`t be null");
            if (value == null)
            {
                Remove(key);
                return;
            }
            if (Count>=Capacity/2)
            {
                Resize(2*Capacity);
            }
            int i;
            for (i = Hash(key); _keys[i] != null; i = (i + 1) % Capacity)
            {
                if (_keys[i].Equals(key))
                {
                    _values[i] = value; 
                    return;
                }
            }
            _keys[i] = key;
            _values[i] = value;
            Count++;
        }
        public IEnumerable<TKey> Keys() //возвращение всех ключей
        {
            var q = new Queue<TKey>();
            for (int i = 0; i < Capacity; i++)
            {

                if (_keys[i] != null)
                {
                    q.Enqueue(_keys[i]);
                }
            }
            return q;
        }
    }
}
