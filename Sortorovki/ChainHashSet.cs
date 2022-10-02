using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortorovki
{
   public class ChainHashSet<TKey,TValue>
    {
        //Разрешение коллизий  в словаре методом "Раздельные цепочки"
        private SequentialSearchSt<TKey, TValue>[] _chains; 

        private const int DefaultCapacity = 4;
        public int Count { get; private set; }
        public int Capacity { get; private set; }

        public ChainHashSet( int capacity)
        {
            Capacity = capacity;
            _chains = new SequentialSearchSt<TKey, TValue>[capacity];//массив цепочек
            for (int i = 0; i < capacity; i++) 
            {
                _chains[i] = new SequentialSearchSt<TKey, TValue>();
            }
        }

        public ChainHashSet():this(Prime.MinPrime)
        {
        }

        private int Hash(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff)% Capacity; //взятие индекса основанного на хэш-функции
            //вычислили хэш и пребразовали в индекс
            //& 0x7fffffff - для избежания отрицательный хешей применена битовая маска

        }
     
        public TValue Get(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Key can`t be null");
            int index = Hash(key); //взяли индекс по котрому ключ лежит в массиве
            //имея индекс получимдоступ к цепочки и запросим значение
            if (_chains[index].TryGet(key,out TValue val))
            {
                return val;    //Разрешение коллизий методом "Раздельные цепочки"
            }
            throw new ArgumentNullException("Key was is not found");
        }

        public bool Contains(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Key can`t be null");
            int index = Hash(key);
          return  _chains[index].TryGet(key, out TValue val);
        }

        public bool Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Key can`t be null");
            int index = Hash(key);
            if (_chains[index].Contains(key))
            {
                Count--;
                _chains[index].Remove(key);
                if (Capacity > DefaultCapacity && Count <= 2 * Capacity) //дополнили после написания класса Prime
                    Resize(Prime.ReducePrime(Capacity));                 //

                return true;
            }
            return false;
        }

        public void Add(TKey key, TValue val)
        {
            if (key == null)
                throw new ArgumentNullException("Key can`t be null");
            if (val==null)
            {
                Remove(key); //при передачи val==null происходит удаление пары ключ-значение
                return;      //можно просто запретить передачу val==null
            }
            //необходимо позаботиться о том, чтобы держать массив правильного размера
            //один подход: если длина массива достигает 10 и более, тогда лучше удвоить размер[] цепочек
            //это позволит иметь норм распределение хэша
            if (Count >= 10 * Capacity) Resize(Prime.ExpandPrime(Capacity)); //Resize(2*Capacity)

            int index = Hash(key);
            if (!_chains[index].Contains(key))
            {
                Count++;
            }
            _chains[index].Add(key, val);
        }

        private void Resize(int chains) //для увеличения размера  надо создать новую таблицу большего размера и скопировать туда данные
        {
            var temp = new ChainHashSet< TKey, TValue> (chains);
            for (int i = 0; i < Capacity; i++)
            {
                foreach (TKey key in _chains[i].Keys())
                {
                    if (_chains[i].TryGet(key, out TValue val))
                    {
                        temp.Add(key, val); //Add приведет к реколькуляции хэшов
                    }
                }
            }
            Capacity = temp.Capacity;
            Count = temp.Count;
            _chains = temp._chains;
        }

        public IEnumerable<TKey> Keys() //возвращение всех ключей
        {
            var queue = new LinkedQueue<TKey>();
            for (int i = 0; i < Capacity; i++)
            {
                foreach (TKey key in _chains[i].Keys())
                {
                    queue.EnQueue(key);
                }
            }
            return queue;
        }
    }
}
