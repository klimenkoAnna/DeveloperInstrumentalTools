using System;
using NUnit.Framework;
using UnitTestsTarget;

namespace UnitTestsKlimenko
{
    public class CalendarServiceTest
    {
        private CalendarService _calendarService;

        private static object[] _dateCasesToday =
        {
            new object[] {TestUtils.GetDate("06/11/2020"), TestUtils.GetDate("06/11/2020")},
            new object[] {TestUtils.GetDate("08/11/2020"), TestUtils.GetDate("09/11/2020")},
        };

        private static object[] _dateCasesTomorrow =
        {
            new object[] {TestUtils.GetDate("06/11/2020"), TestUtils.GetDate("09/11/2020")},
            new object[] {TestUtils.GetDate("07/11/2020"), TestUtils.GetDate("09/11/2020")},
            new object[] {TestUtils.GetDate("09/11/2020"), TestUtils.GetDate("10/11/2020")},
        };

        private static object[] _dateCasesYesterday =
        {
            new object[] {TestUtils.GetDate("06/11/2020"), TestUtils.GetDate("05/11/2020")},
            new object[] {TestUtils.GetDate("07/11/2020"), TestUtils.GetDate("06/11/2020")},
            new object[] {TestUtils.GetDate("09/11/2020"), TestUtils.GetDate("06/11/2020")},
        };

        [SetUp]
        public void Setup()
        {
            _calendarService = new CalendarService(new DayShiftService(new DayOfWeekService()));
        }

        [Test, TestCaseSource(nameof(_dateCasesToday))]
        public void TestWorkingToday(DateTime date, DateTime new_date)
        {
            Assert.AreEqual(new_date, _calendarService.GetWorkingToday(date));
        }

        [Test, TestCaseSource(nameof(_dateCasesTomorrow))]
        public void TestWorkingTomorrow(DateTime date, DateTime new_date)
        {
            Assert.AreEqual(new_date, _calendarService.GetWorkingTomorrow(date));
        }

        [Test, TestCaseSource(nameof(_dateCasesYesterday))]
        public void TestWorkingYesterday(DateTime date, DateTime new_date)
        {
            Assert.AreEqual(new_date, _calendarService.GetWorkingYesterday(date));
        }
    }
}