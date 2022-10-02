using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortorovki
{
    public class SearchAlgorithm
    {
        //Линейный алгоритм поиска
        private static bool Exist(int[] array, int number) //поиск в int массиве опред значение
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    return true;
                }
            }
            return false;
        }

        private static int IndexOf(int[] array, int number) //полученипе индекса найденного значения  в int массиве
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    return i;
                }
            }
            return -1;
        }

        //бинарный поиск
        //итеративный
        public static int BinarySearch(int[] array, int value) //работает быстро
        {
            int low = 0;
            int high = array.Length;
            while (low<high)
            {
                int mid = (low + high) / 2; //индекс срединного элемента
                if (array[mid] == value)
                    return mid;
                if (array[mid] < value)
                    low = mid + 1;  //сдвигаем левую границу
                else
                    high = mid;
            }
            return -1;
        }
        //рекурсивный бинарный поиск, работает медленне
        public static int RecursiveBinarySearch(int[] array, int value)
        {
            return InternalRecursiveBinarySearch(0, array.Length);
            int InternalRecursiveBinarySearch(int low, int high)
            {
                if (low>=high) //выход из рекурсии
                {
                    return -1;
                }
                int mid = (low + high) / 2;
                if (array[mid] == value)
                    return mid;
                if (array[mid] < value)
                    return InternalRecursiveBinarySearch(mid + 1, high);
                return InternalRecursiveBinarySearch(low, mid);
            }
        }

    }
}
