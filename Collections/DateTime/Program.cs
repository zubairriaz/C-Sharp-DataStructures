using System;
using System.Globalization;

namespace DateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            //Last Bit

            var dateTimeUTC = DateTimeOffset.UtcNow;
            Console.WriteLine(dateTimeUTC);
            Console.WriteLine(dateTimeUTC.ToLocalTime());
            var datenow = System.DateTime.Now.ToString();
            var dateUTC = System.DateTime.Parse(datenow, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal).ToUniversalTime();
            var date =DateTimeOffset.Parse(datenow,CultureInfo.GetCultureInfo("en"));
            var date2 = System.DateTimeOffset.Now.ToString("dd MMMM yyyy", CultureInfo.GetCultureInfo("sv-SE"));
            var time = DateTimeOffset.Now;
             
            Console.WriteLine(dateUTC);

            // Get Timezone 

            foreach(var timezone in TimeZoneInfo.GetSystemTimeZones())
            {
                if(timezone.GetUtcOffset(time) == time.Offset)
                {
                    Console.WriteLine(timezone);
                }
            }

            //Convert from one time zone to another

            var now = System.DateTime.Now;
            var timeZoneInfos = TimeZoneInfo.GetSystemTimeZones();

            foreach(var timezone in timeZoneInfos)
            {  
                var converted = TimeZoneInfo.ConvertTime(now, timezone);
                Console.WriteLine($"{ timezone.Id}-{converted}");
            }
            Console.ReadLine();
        }
    }
}
