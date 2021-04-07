using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Arrays
{
    public class MultidimensionalArray
    {
        public void GetTransportEnums()
        {
            Random rand = new Random();
            int tranportEnumscount = Enum.GetNames(typeof(TransportEnum)).Length;
            TransportEnum[][] transportEnums = new TransportEnum[12][];
            for (int month =1; month <=12; month++)
            {
                int daysCount = DateTime.DaysInMonth(DateTime.Now.Year, month);
                transportEnums[month - 1] = new TransportEnum[daysCount];
                for (int day = 1; day <= daysCount; day++)
                {
                    int randomType = rand.Next(tranportEnumscount);
                    transportEnums[month - 1][day - 1] = (TransportEnum)randomType; 
                }
            }

            string[] monthNames = GetMonthNames();
            int monthNamesPart = monthNames.Max(n => n.Length) + 2; ;
            for (int month = 1; month <= transportEnums.Length; month++)
            {
                Console.Write(
                    $"{monthNames[month - 1]}:".PadRight(monthNamesPart));
                for (int day = 1; day <= transportEnums[month - 1].Length; day++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor =
                        transportEnums[month - 1][day - 1].GetColour();
                    Console.Write(transportEnums[month - 1][day - 1].GetChar());
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        private string[] GetMonthNames()
        {
            string[] names = new string[12];
            for(int month = 1; month <= 12; month++)
            {
                DateTime date = new DateTime(DateTime.Now.Year, month, 1);
                string name = date.ToString("MMMM");
                names[month - 1] = name;
            }
            return names;
        }
    }

    public static class TransportEnumExtension
    {
        public static char GetChar(this TransportEnum transport)
        {
            switch (transport)
            {
                case TransportEnum.BIKE: return 'B';
                case TransportEnum.BUS: return 'U';
                case TransportEnum.CAR: return 'C';
                case TransportEnum.SUBWAY: return 'S';
                case TransportEnum.WALK: return 'W';
                default: throw new Exception("Unknown Transport");
            }

        }

        public static ConsoleColor GetColour(this TransportEnum transport)
        {
            switch (transport)
            {
                case TransportEnum.BIKE: return ConsoleColor.Blue;
                case TransportEnum.BUS: return ConsoleColor.Black;
                case TransportEnum.CAR: return ConsoleColor.Green;
                case TransportEnum.SUBWAY: return ConsoleColor.Yellow;
                case TransportEnum.WALK: return ConsoleColor.Red;
                default: throw new Exception("Unknown Transport");
            }

        }
    }

    public enum TransportEnum
    {
        CAR,
        BUS,
        SUBWAY,
        BIKE,
        WALK
    }
}
