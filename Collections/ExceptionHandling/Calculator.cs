using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling
{
    public class Calculator
    {
        public int Calculate (int number1 , int number2 , string operation)
        {
            var nonNullOperation = operation ?? throw new ArgumentNullException(nameof(operation));
            if (nonNullOperation == "/")
            {
                return Divide(number1, number2);
            }
            else
            {
                throw new CalculatorException(new ArgumentOutOfRangeException(nameof(operation), "The mathematical operator is not supported"));
                //Console.WriteLine("Unknown Operation");
                //return 0;
            }
        }

        private int Divide(int number1, int number2)
        {
            try
            {
                return number1 / number2;
            }
            catch(DivideByZeroException ex)
            {
                throw new ArithmeticException("An Error Occurred during the Calculation", ex);
                Console.WriteLine("Something is wrong");


            }
            
        }
    }
}
