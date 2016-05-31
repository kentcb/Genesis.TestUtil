namespace System
{
    using Globalization;

    public static class StringExtensions
    {
        private static readonly string[] supportedDateTimeFormats = new[]
        {
            "yyyy-MM-dd HH:mm:ss",
            "yyyy-MM-dd"
        };

        public static DateTime? ToDateTime(this string @this)
        {
            if (@this == null)
            {
                return null;
            }

            return
                DateTime.SpecifyKind(
                    DateTime.ParseExact(
                        @this,
                        supportedDateTimeFormats,
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None),
                    DateTimeKind.Utc);
        }
    }
}