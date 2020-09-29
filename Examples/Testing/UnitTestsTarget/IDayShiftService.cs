using System;

namespace UnitTestsTarget
{
    public interface IDayShiftService
    {
        DateTime GetShiftBusinessDay(DateTime date, int shift);
    }
}