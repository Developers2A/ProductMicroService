using System;
using System.Globalization;

namespace Postex.SharedKernel.Utilities
{
    public static class DateTimeExtensions
    {
        public static DateTime PersianDateStringToDateTime(this string persianDate)
        {
            PersianCalendar pc = new();

            var persianDateSplitedParts = persianDate.Split(" ")[0].Split('/');
            if (persianDate.Contains(":"))
            {
                var persianTimeSplitedParts = persianDate.Split(" ")[1].Split(':');
                DateTime dateTime = new(int.Parse(persianDateSplitedParts[0]), int.Parse(persianDateSplitedParts[1]), int.Parse(persianDateSplitedParts[2]), int.Parse(persianTimeSplitedParts[0]), int.Parse(persianTimeSplitedParts[1]), 0, pc);
                return DateTime.Parse(dateTime.ToString(CultureInfo.CreateSpecificCulture("en-US")));
            }
            else
            {
                DateTime dateTime = new(int.Parse(persianDateSplitedParts[0]), int.Parse(persianDateSplitedParts[1]), int.Parse(persianDateSplitedParts[2]), pc);
                return DateTime.Parse(dateTime.ToString(CultureInfo.CreateSpecificCulture("en-US")));
            }
        }
    }
}
