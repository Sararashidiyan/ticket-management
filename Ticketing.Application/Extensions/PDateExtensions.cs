using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Application.Extensions
{
    public static class PDateExtensions
    {
        public static string ToPersianDate(this DateTime dt, string timeFormat = "")
        {
            var PC = new PersianCalendar();
            var date = $"{PC.GetYear(dt)}/{PC.GetMonth(dt):00}/{PC.GetDayOfMonth(dt):00}";
            if (timeFormat != "")
                date = $"{date} {dt.ToString(timeFormat)}";
            return date;
        }
       
    }
}
