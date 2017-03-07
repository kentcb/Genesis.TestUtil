namespace Genesis.TestUtil.UnitTests.System
{
    using global::System;
    using global::System.Globalization;
    using Xunit;

    public sealed class StringExtensionsFixture
    {
        [Theory]
        [InlineData(null, DateTimeKind.Utc, null)]
        [InlineData("2017-01-01", DateTimeKind.Utc, "2017-01-01 00:00:00.0000000")]
        [InlineData("2017-01-01 12:30:15", DateTimeKind.Utc, "2017-01-01 12:30:15.0000000")]
        [InlineData("2017-01-01 12:30:15.1", DateTimeKind.Utc, "2017-01-01 12:30:15.1000000")]
        [InlineData("2017-01-01 12:30:15.12", DateTimeKind.Utc, "2017-01-01 12:30:15.1200000")]
        [InlineData("2017-01-01 12:30:15.123", DateTimeKind.Utc, "2017-01-01 12:30:15.1230000")]
        [InlineData("2017-01-01 12:30:15.1234", DateTimeKind.Utc, "2017-01-01 12:30:15.1234000")]
        [InlineData("2017-01-01 12:30:15.12345", DateTimeKind.Utc, "2017-01-01 12:30:15.1234500")]
        [InlineData("2017-01-01 12:30:15.123456", DateTimeKind.Utc, "2017-01-01 12:30:15.1234560")]
        [InlineData("2017-01-01 12:30:15.1234567", DateTimeKind.Utc, "2017-01-01 12:30:15.1234567")]
        [InlineData(null, DateTimeKind.Local, null)]
        [InlineData("2016-02-12", DateTimeKind.Local, "2016-02-12 00:00:00.0000000")]
        [InlineData("2016-02-12 12:30:15", DateTimeKind.Local, "2016-02-12 12:30:15.0000000")]
        [InlineData("2016-02-12 12:30:15.1", DateTimeKind.Local, "2016-02-12 12:30:15.1000000")]
        [InlineData("2016-02-12 12:30:15.12", DateTimeKind.Local, "2016-02-12 12:30:15.1200000")]
        [InlineData("2016-02-12 12:30:15.123", DateTimeKind.Local, "2016-02-12 12:30:15.1230000")]
        [InlineData("2016-02-12 12:30:15.1234", DateTimeKind.Local, "2016-02-12 12:30:15.1234000")]
        [InlineData("2016-02-12 12:30:15.12345", DateTimeKind.Local, "2016-02-12 12:30:15.1234500")]
        [InlineData("2016-02-12 12:30:15.123456", DateTimeKind.Local, "2016-02-12 12:30:15.1234560")]
        [InlineData("2016-02-12 12:30:15.1234567", DateTimeKind.Local, "2016-02-12 12:30:15.1234567")]
        public void to_date_time_works_as_expected(string input, DateTimeKind kind, string expected)
        {
            var result = input.ToDateTime(kind);

            Assert.Equal(expected == null ? (DateTime?)null : DateTime.ParseExact(expected, "yyyy-MM-dd HH:mm:ss.fffffff", CultureInfo.InvariantCulture), result);
        }

        [Theory]
        [InlineData(DateTimeKind.Utc, DateTimeKind.Unspecified)]
        [InlineData(DateTimeKind.Utc, DateTimeKind.Utc)]
        [InlineData(DateTimeKind.Utc, DateTimeKind.Local)]
        [InlineData(DateTimeKind.Local, DateTimeKind.Unspecified)]
        [InlineData(DateTimeKind.Local, DateTimeKind.Utc)]
        [InlineData(DateTimeKind.Local, DateTimeKind.Local)]
        [InlineData(DateTimeKind.Unspecified, DateTimeKind.Unspecified)]
        [InlineData(DateTimeKind.Unspecified, DateTimeKind.Utc)]
        [InlineData(DateTimeKind.Unspecified, DateTimeKind.Local)]
        public void to_date_can_change_the_target_kind(DateTimeKind kind, DateTimeKind targetKind)
        {
            var result = "2017-01-01".ToDateTime(kind, targetKind).Value;

            Assert.Equal(targetKind == DateTimeKind.Unspecified ? kind : targetKind, result.Kind);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("01:30", "0.01:30:00.0000000")]
        [InlineData("01:30:28", "0.01:30:28.0000000")]
        [InlineData("01:30:28.1", "0.01:30:28.1000000")]
        [InlineData("01:30:28.12", "0.01:30:28.1200000")]
        [InlineData("01:30:28.123", "0.01:30:28.1230000")]
        [InlineData("01:30:28.1234", "0.01:30:28.1234000")]
        [InlineData("01:30:28.12345", "0.01:30:28.1234500")]
        [InlineData("01:30:28.123456", "0.01:30:28.1234560")]
        [InlineData("01:30:28.1234567", "0.01:30:28.1234567")]
        [InlineData("3.01:30", "3.01:30:00.0000000")]
        [InlineData("3.01:30:28", "3.01:30:28.0000000")]
        [InlineData("3.01:30:28.1", "3.01:30:28.1000000")]
        [InlineData("3.01:30:28.12", "3.01:30:28.1200000")]
        [InlineData("3.01:30:28.123", "3.01:30:28.1230000")]
        [InlineData("3.01:30:28.1234", "3.01:30:28.1234000")]
        [InlineData("3.01:30:28.12345", "3.01:30:28.1234500")]
        [InlineData("3.01:30:28.123456", "3.01:30:28.1234560")]
        [InlineData("3.01:30:28.1234567", "3.01:30:28.1234567")]
        public void to_time_span_works_as_expected(string input, string expected)
        {
            var result = input.ToTimeSpan();

            Assert.Equal(expected == null ? (TimeSpan?)null : TimeSpan.ParseExact(expected, @"d\.hh\:mm\:ss\.fffffff", CultureInfo.InvariantCulture), result);
        }
    }
}