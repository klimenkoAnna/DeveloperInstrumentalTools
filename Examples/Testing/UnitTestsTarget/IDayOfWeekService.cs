using System;

namespace UnitTestsTarget
{
    public interface IDayOfWeekService
    {
        bool IsWeekend(in DateTime date);
    }
}