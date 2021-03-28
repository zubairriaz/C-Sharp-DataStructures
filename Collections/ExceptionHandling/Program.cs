using System;

using static System.Console;
namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Enter first Number");
            int number1 = int.Parse(ReadLine());

            WriteLine("Enter second Number");
            int number2 = int.Parse(ReadLine());

            WriteLine("Enter operation");
            string operation = ReadLine().ToUpperInvariant();
            try
            {
                var calculator = new Calculator();
                int result = calculator.Calculate(number1, number2, operation);
                DisplayResult(result);
            }
            catch(ArgumentNullException ex)
            {
                WriteLine($"Operation was not provided {ex }");

            }
            catch (ArgumentOutOfRangeException ex)
            {
                WriteLine($"Operation was not supported {ex }");

            }
            catch (Exception ex)
            {
                WriteLine($"Something went wrong {ex }");
            }
            

            

            WriteLine("\nPress Enter to exit");
            ReadLine();
        }

        private static void DisplayResult(int result)
        {
            WriteLine($"Result is {result}");
        }
    }
}
