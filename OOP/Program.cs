using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    /// <summary>
    /// 
    /// </summary>
    class Heron
    {
        public double errorLimit;
        public double value;

        /// <summary>
        /// Heron constructor that takes error limit and value to compute in double. 
        /// Value to compute must be a positive number. 
        /// </summary>
        /// <param name="errorLimitValue"></param>
        /// <param name="valueToCompute"></param>
        public Heron(double errorLimitValue, double valueToCompute)
        {
            this.errorLimit = errorLimitValue;
            this.value = valueToCompute;

            if (this.value < 0)
            {
                throw new System.ArgumentException("Value to compute must be positive", "valueToCompute");
            }
        }

        /// <summary>
        /// Computes the square root of a double by taking the value of the number divided by 2 as a guess, 
        /// then takes the squared value of the guessed number and compares it against the original number.
        /// If the absolute value of the difference between the two is less than the error limit, the method
        /// returns the guessed number. 
        /// </summary>
        /// <returns></returns>
        public double ComputeSquareRoot()
        {
            double guessedNumber = this.value / 2.0;
            double guessedNumberSquared = guessedNumber * guessedNumber;

            while (Math.Abs(this.value - guessedNumberSquared) > this.errorLimit)
            {
                guessedNumber = (guessedNumber + this.value / guessedNumber) / 2;
                guessedNumberSquared = guessedNumber * guessedNumber;
            }

            return guessedNumber;
        }
    }

    class SquareRootTest
    {
        public Heron heron;
        
        public SquareRootTest(Heron heronToCompute)
        {
            this.heron = heronToCompute;
        }

        /// <summary>
        /// Computes squared root of a double by running the method Math.Sqrt()
        /// </summary>
        /// <returns></returns>
        public double ComputeSquareRootToo()
        {
            double guessedNumber = Math.Sqrt(this.heron.value);
            return guessedNumber;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            double randomNumber = 0;
            Random randGenerator = new Random();
            for (int i = 0; i < 10000; i++)
            {
                randomNumber = randGenerator.Next(0, 100000);
                Heron newHeron = new Heron(0.0001, randomNumber);
                double heronSqrt = newHeron.ComputeSquareRoot();
                SquareRootTest sqrtTest = new SquareRootTest(newHeron);
                double systemSqrt = sqrtTest.ComputeSquareRootToo();

                if (Math.Abs(heronSqrt - systemSqrt) > newHeron.errorLimit)
                {
                    Console.WriteLine("heronSqrt: {0}, systemSqrt: {1}", heronSqrt, systemSqrt);
                    Console.ReadLine();
                }
            }
            Console.WriteLine("exited without an error");
            Console.ReadLine();
        }
    }

}