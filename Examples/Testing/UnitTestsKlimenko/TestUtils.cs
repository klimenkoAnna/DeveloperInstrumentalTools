using System;
using System.Globalization;

namespace UnitTestsKlimenko
{
    public static class TestUtils
    {
        private static readonly CultureInfo DATE_PROVIDER = CultureInfo.CurrentCulture;
        private static readonly String DATE_TIME_FORMAT = "dd/MM/yyyy HH:mm:ss";
        private static readonly String DATE_FORMAT = "dd/MM/yyyy";

        public static DateTime GetDateTime(String dateTimeString)
        {
            return DateTime.ParseExact(dateTimeString, DATE_TIME_FORMAT, DATE_PROVIDER);
        }

        public static DateTime GetDate(String dateTimeString)
        {
            return DateTime.ParseExact(dateTimeString, DATE_FORMAT, DATE_PROVIDER);
        }
    }
}