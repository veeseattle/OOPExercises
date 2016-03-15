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
        private double errorLimit;
        private double value;

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

        public double Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public double ErrorLimit
        {
            get { return this.errorLimit; }
            set { this.errorLimit = value; }
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
   
        /// <summary>
        /// Computes squared root of a double by running the method Math.Sqrt()
        /// </summary>
        /// <returns></returns>
        public static double ComputeSquareRootToo(Heron heron)
        {
            double guessedNumber = Math.Sqrt(heron.Value);
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
                double systemSqrt = SquareRootTest.ComputeSquareRootToo(newHeron);

                if (Math.Abs(heronSqrt - systemSqrt) > newHeron.ErrorLimit)
                {
                    Console.WriteLine("heronSqrt: {0}, systemSqrt: {1}", heronSqrt, systemSqrt);
                    Console.ReadLine();
                    throw new SystemException();
                }
            }
            Console.WriteLine("exited without an error");
            Console.ReadLine();
        }
    }

}