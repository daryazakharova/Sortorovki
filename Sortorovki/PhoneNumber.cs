using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortorovki
{
    public class PhoneNumber
    {   //при использовании классов в ключах словаря, свойства прописывать без сет
        //чтобы не было возможности изменения значений после их создания
        public PhoneNumber(string areaCode, string exchange, string number)
        {
            AreaCode = areaCode;
            Exchange = exchange;
            Number = number;
        }

        public string AreaCode { get; } 
        public string Exchange { get; }
        public string Number { get; }

        //Реализация семантического сравнения
        public override bool Equals(object? obj) //переопределили метод  Equals для сравнения одинаковых внутренних значений в словаре
        {
            var number = obj as PhoneNumber;
            if (number == null)
                return false;

            return string.Equals(AreaCode, number.AreaCode)
                && string.Equals(Exchange, number.Exchange)
                 && string.Equals(Number, number.Number);
        }

        public static bool operator ==(PhoneNumber left, PhoneNumber right)
            {
            if(object.ReferenceEquals(left,right))
            return true;
              if(object.ReferenceEquals(null, right))
            return false;
            return left.Equals(right);
            }
        public static bool operator !=(PhoneNumber left, PhoneNumber right)
        {
                return !(left == right);
        }

        //Реализация Сравнения по хешкоду
        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;
                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^
                    (!object.ReferenceEquals(null, AreaCode) ? AreaCode.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^
                   (!object.ReferenceEquals(null, Exchange) ? Exchange.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^
                   (!object.ReferenceEquals(null, Number) ? Number.GetHashCode() : 0);
                return hash;
            }
          
        }

    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Ssn { get; set; }
    }


}
