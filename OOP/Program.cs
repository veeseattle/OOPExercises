using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Heron
    {
        public int errorLimit;
        public int value; 

        public Heron (int errorLimitValue, int valueToCompute)
        {
            this.errorLimit = errorLimitValue;
            this.value = valueToCompute;

            if (this.value < 0)
            {
                throw new System.ArgumentException("Value to compute must be positive", "valueToCompute");
            }         
        }
        public int ComputeSquareRoot()
        {
            int result = 0;
            int guessedNumber = this.value / 2;
            int guessedNumberSquared =  guessedNumber * guessedNumber;

            while (Math.Abs(this.value - guessedNumberSquared) > this.errorLimit)
            {
                guessedNumber = (guessedNumber + this.value / guessedNumber) / 2;
                guessedNumberSquared = guessedNumber * guessedNumber;
            }
            
            result = guessedNumber;
            return result;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Heron myNewHeron = new Heron(1, 64);
            int myNewHeronSqrt = myNewHeron.ComputeSquareRoot();
            Console.WriteLine("value of sqrt: {0}", myNewHeronSqrt);
            Console.ReadLine();
        }
    }
}
