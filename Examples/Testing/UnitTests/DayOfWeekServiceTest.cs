using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Mail;
using FluentAssertions;
using NUnit.Framework;
using UnitTestsTarget;

namespace UnitTests
{
    public class Tests
    {
        private DayOfWeekService _dayOfWeekService;
   
        static object[] _dateTimeCases =
        {
            new object[] { TestUtils.GetDateTime("04/11/2020 12:00:00"), false },
            new object[] { TestUtils.GetDateTime("06/11/2020 12:00:00"), false },
            new object[] { TestUtils.GetDateTime("06/11/2020 23:59:59"), false },
            new object[] { TestUtils.GetDateTime("07/11/2020 00:01:00"), true },
            new object[] { TestUtils.GetDateTime("07/11/2020 12:00:00"), true },
            new object[] { TestUtils.GetDateTime("08/11/2020 23:59:59"), true },
            new object[] { TestUtils.GetDateTime("09/11/2020 00:00:00"), false },
            new object[] { TestUtils.GetDateTime("12/11/2020 12:00:00"), false },
        };

        [SetUp]
        public void Setup()
        {
            _dayOfWeekService  = new DayOfWeekService();
        }

        [Test, TestCaseSource(nameof(_dateTimeCases))]
        public void TestDayOfWeek(DateTime date, bool isWeekend)
        {
            //Assert.AreEqual(isWeekend, _dayOfWeekService.IsWeekend(date));
            isWeekend.Should().Be(_dayOfWeekService.IsWeekend(date));

        }
    }
}