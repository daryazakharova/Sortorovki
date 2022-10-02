using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortorovki
{
    public class Prime
    {
        private static readonly int[] Predefined =
        {
            3,7,11,17,23,29,37,47,59,71,89,107,163,197,239,293
        };

        public static IEnumerable<int> Sieve(int max) //Решето Эратосфена
        {
            bool[] composite = new bool[max + 1];
            for (int p = 2; p <= max; p++)
            {
                if (composite[p]) continue;
                yield return p;
                for (int i = p*p; i <= max; i+=p)
                {
                    composite[i] = true;
                }

                     
            }
            //Program.cs:
            //foreach (var prime in Prime.Sieve(30))
            //{
            //    Console.WriteLine(prime);
            //}
            //Console.Read();
        }

        public static int MinPrime => Predefined[0];
        private const int HashPrime = 101;

        public static int GetPrime(int min)
        {
            if (min < 0)
                throw new ArgumentException();

            for (int i = 0; i < Predefined.Length; i++)
            {
                int prime = Predefined[i];
                if (prime >= min) return prime;
            }
            for (int i = min|1; i < int.MaxValue; i+=2)
            {
                if (IsPrime(i) &&(i-1)%HashPrime!=0)
                {
                    return i;
                }
            }
            return min;
        }
        
        private static bool IsPrime(int candidate)
        {
            if (candidate%2 !=0)
            {
                int limit = (int)Math.Sqrt(candidate);
                for (int divisor = 3; divisor <=limit; divisor+=2)
                {
                    if (candidate % divisor == 0)
                        return false;

                }
                return true;
            }
            return candidate == 2;
        }

        public const int MaxPrimeArrayLength = 0x7FEFFFFD;
        public static int ExpandPrime(int oldSize) //вычисление новой размерности для массива цепочек
        {
            int newSize = 2 * oldSize;
            if ((uint)newSize > MaxPrimeArrayLength && MaxPrimeArrayLength > oldSize)
                return MaxPrimeArrayLength;
            return GetPrime(newSize);
        }

        internal static int ReducePrime(int oldSize)
        {
            int newSize = oldSize / 2;
            if (newSize > MaxPrimeArrayLength && MaxPrimeArrayLength > oldSize)
                return MaxPrimeArrayLength;

            return GetPrime(newSize);
        }
    }
}
