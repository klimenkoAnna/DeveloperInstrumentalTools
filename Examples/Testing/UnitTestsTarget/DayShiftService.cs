using System;
using System.Globalization;

namespace UnitTestsTarget
{
    public class DayShiftService : IDayShiftService
    {
        private IDayOfWeekService DayOfWeekService { get; }
        
        public DayShiftService(IDayOfWeekService dayOfWeekService)
        {
            this.DayOfWeekService = dayOfWeekService;
        }

        public DateTime GetShiftBusinessDay(DateTime date, int shift)
        {
            var result = date.AddDays(shift);
            
            result = this.ShiftWhileHoliday(shift, result);

            return result;
        }

        private DateTime ShiftWhileHoliday(int shift, DateTime result)
        {
            while (this.DayOfWeekService.IsWeekend(result))
            {
                result = shift >= 0 
                    ? result.AddDays(1) 
                    : result.AddDays(-1);
            }

            return result;
        }
    }
}