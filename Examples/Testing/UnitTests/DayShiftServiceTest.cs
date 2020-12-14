using System;
using FluentAssertions;
using NUnit.Framework;
using UnitTestsTarget;

namespace UnitTests
{
    public class DayShiftServiceTest
    {
        private DayShiftService _dayShiftService;


        [SetUp]
        public void Setup()
        {
            _dayShiftService = new DayShiftService(new DayOfWeekService());
        }

        private static object[] _dateCasesBusiness =
        {
            new object[] {TestUtils.GetDate("06/11/2020"), 1, TestUtils.GetDate("09/11/2020")},
            new object[] {TestUtils.GetDate("06/11/2020"), -1, TestUtils.GetDate("05/11/2020")},
            new object[] {TestUtils.GetDate("09/11/2020"), 1, TestUtils.GetDate("10/11/2020")},
            new object[] {TestUtils.GetDate("09/11/2020"), -1, TestUtils.GetDate("06/11/2020")},
            new object[] {TestUtils.GetDate("06/11/2020"), 0, TestUtils.GetDate("06/11/2020")},

        };
        
        private static object[] _dateCasesHoliday =
        {
            new object[] { 1, TestUtils.GetDate("08/11/2020"), TestUtils.GetDate("09/11/2020")},
            new object[] { 1, TestUtils.GetDate("07/11/2020"), TestUtils.GetDate("09/11/2020")},
            new object[] { 1, TestUtils.GetDate("06/11/2020"), TestUtils.GetDate("06/11/2020")},
            new object[] {-1, TestUtils.GetDate("08/11/2020"), TestUtils.GetDate("06/11/2020")},
            new object[] {-1, TestUtils.GetDate("07/11/2020"), TestUtils.GetDate("06/11/2020")},
            new object[] {0, TestUtils.GetDate("06/11/2020"), TestUtils.GetDate("06/11/2020")},

        };

        [Test, TestCaseSource(nameof(_dateCasesBusiness))]
        public void GetShiftBusinessDayTest(DateTime date, int shift, DateTime new_date)
        {
           // Assert.AreEqual(new_date, _dayShiftService.GetShiftBusinessDay(date, shift));
            new_date.Should().Be(_dayShiftService.GetShiftBusinessDay(date, shift));

        }
        
        [Test, TestCaseSource(nameof(_dateCasesHoliday))]
        public void ShiftWhileHolidayTest(int shift, DateTime date, DateTime newDate)
        {
            //Assert.AreEqual(newDate, _dayShiftService.ShiftWhileHoliday(shift, date));
            newDate.Should().Be(_dayShiftService.ShiftWhileHoliday(shift, date));

        }
    }
}