using System;
using System.Globalization;

namespace DateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            CommonDateTimeScenarios();
        }


        static void CommonDateTimeScenarios()
        {
            var offset = TimeSpan.FromHours(-11);
            var startDate = DateTimeOffset.UtcNow.ToOffset(DateTimeOffset.Now.Offset);
            var endDate = new System.DateTime(2020,3,23,10,55,55);
           var result =  startDate.CompareTo(endDate);
            Console.WriteLine(startDate.ToString("O"));
        }

        static void  DateCalculations()
        {
            //Time Differnce

            var timeSpan = new TimeSpan(60, 40, 4000);
            var startDate = DateTimeOffset.UtcNow;
            var endDate = startDate.AddMinutes(20).AddSeconds(24);

            var differnce = endDate - startDate;

            var calendar = CultureInfo.InvariantCulture.Calendar;
            var startCalendar = DateTimeOffset.UtcNow;
            var week = calendar.GetWeekOfYear(startCalendar.DateTime, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

            Console.WriteLine(week);



            var isoWeek = ISOWeek.GetWeekOfYear(DateTimeOffset.UtcNow.DateTime);
            Console.WriteLine(isoWeek);

            //Last Bit

            var dateTimeUTC = DateTimeOffset.UtcNow;
            Console.WriteLine(dateTimeUTC);
            Console.WriteLine(dateTimeUTC.ToLocalTime());
            var datenow = System.DateTime.Now.ToString();
            var dateUTC = System.DateTime.Parse(datenow, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal).ToUniversalTime();
            var date = DateTimeOffset.Parse(datenow, CultureInfo.GetCultureInfo("en"));
            var date2 = System.DateTimeOffset.Now.ToString("dd MMMM yyyy", CultureInfo.GetCultureInfo("sv-SE"));
            var time = DateTimeOffset.Now;

            Console.WriteLine(dateUTC);

            // Get Timezone 

            foreach (var timezone in TimeZoneInfo.GetSystemTimeZones())
            {
                if (timezone.GetUtcOffset(time) == time.Offset)
                {
                    Console.WriteLine(timezone);
                }
            }

            //Convert from one time zone to another

            var now = System.DateTime.Now;
            var timeZoneInfos = TimeZoneInfo.GetSystemTimeZones();

            foreach (var timezone in timeZoneInfos)
            {
                var converted = TimeZoneInfo.ConvertTime(now, timezone);
                Console.WriteLine($"{ timezone.Id}-{converted}");
            }
            Console.ReadLine();
        }
    }
}
