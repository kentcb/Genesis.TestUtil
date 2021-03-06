﻿namespace System
{
    using Globalization;

    public static class StringExtensions
    {
        private static readonly string[] supportedDateTimeFormats = new[]
        {
            "yyyy-MM-dd HH:mm:ss.fffffff",
            "yyyy-MM-dd HH:mm:ss.ffffff",
            "yyyy-MM-dd HH:mm:ss.fffff",
            "yyyy-MM-dd HH:mm:ss.ffff",
            "yyyy-MM-dd HH:mm:ss.fff",
            "yyyy-MM-dd HH:mm:ss.ff",
            "yyyy-MM-dd HH:mm:ss.f",
            "yyyy-MM-dd HH:mm:ss",
            "yyyy-MM-dd"
        };

        private static readonly string[] supportedTimeSpanFormats = new[]
        {
            @"d\.hh\:mm\:ss\.fffffff",
            @"d\.hh\:mm\:ss\.ffffff",
            @"d\.hh\:mm\:ss\.fffff",
            @"d\.hh\:mm\:ss\.ffff",
            @"d\.hh\:mm\:ss\.fff",
            @"d\.hh\:mm\:ss\.ff",
            @"d\.hh\:mm\:ss\.f",
            @"d\.hh\:mm\:ss",
            @"d\.hh\:mm",
            @"hh\:mm\:ss\.fffffff",
            @"hh\:mm\:ss\.ffffff",
            @"hh\:mm\:ss\.fffff",
            @"hh\:mm\:ss\.ffff",
            @"hh\:mm\:ss\.fff",
            @"hh\:mm\:ss\.ff",
            @"hh\:mm\:ss\.f",
            @"hh\:mm\:ss",
            @"hh\:mm"
        };

        public static DateTime? ToDateTime(this string @this, DateTimeKind kind = DateTimeKind.Utc, DateTimeKind targetKind = DateTimeKind.Unspecified)
        {
            if (@this == null)
            {
                return null;
            }

            var result =
                DateTime.SpecifyKind(
                    DateTime.ParseExact(
                        @this,
                        supportedDateTimeFormats,
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None),
                    kind);

            switch (targetKind)
            {
                case DateTimeKind.Local:
                    result = result.ToLocalTime();
                    break;
                case DateTimeKind.Utc:
                    result = result.ToUniversalTime();
                    break;
            }

            return result;
        }

        public static TimeSpan? ToTimeSpan(this string @this)
        {
            if (@this == null)
            {
                return null;
            }

            return
                TimeSpan
                    .ParseExact(
                        @this,
                        supportedTimeSpanFormats,
                        CultureInfo.InvariantCulture,
                        TimeSpanStyles.None);
        }
    }
}