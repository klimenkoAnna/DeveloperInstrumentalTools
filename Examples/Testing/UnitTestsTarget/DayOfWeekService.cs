using System;
using System.Globalization;
using System.Linq;

namespace UnitTestsTarget
{
    public class DayOfWeekService : IDayOfWeekService
    {
        private DayOfWeek[] Weekend { get; } = { DayOfWeek.Saturday, DayOfWeek.Sunday };
        
        public bool IsWeekend(in DateTime date)
        {
            return this.Weekend.Contains(CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(date));
        }
    }
}