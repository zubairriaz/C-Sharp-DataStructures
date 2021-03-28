using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling
{
    class CalculatorException : Exception
    {
        private static readonly string DefaultMessage = "An error occurred during calculation. Ensure that the operator is supported in the valid ranges for the requested operation.";


        public CalculatorException() : base(DefaultMessage)
        {

        }

        public CalculatorException(string message) :base (message)
        {

        }

        public CalculatorException(string message, Exception innerException) : base(message , innerException)
        {
                
        }

        public CalculatorException(Exception innerException): base(DefaultMessage , innerException)
        {

        }

    }
}
