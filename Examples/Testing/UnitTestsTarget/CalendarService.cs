using System;

namespace UnitTestsTarget
{
    public class CalendarService
    {
        public CalendarService(IDayShiftService dayShiftService)
        {
            this.DayShiftService = dayShiftService;
        }

        private IDayShiftService DayShiftService { get; }
        
        public DateTime GetWorkingToday(DateTime? date)
        {
            return this.DayShiftService.GetShiftBusinessDay(date ?? DateTime.Today, 0);
        }
        
        public DateTime GetWorkingTomorrow(DateTime? date)
        {
            return this.DayShiftService.GetShiftBusinessDay(date ?? DateTime.Today, 1);
        }
        
        public DateTime GetWorkingYesterday(DateTime? date)
        {
            return this.DayShiftService.GetShiftBusinessDay(date ?? DateTime.Today, -1);
        }
    }
}