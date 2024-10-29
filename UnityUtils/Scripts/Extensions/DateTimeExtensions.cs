using System;

namespace UnityUtils {
    public static class DateTimeExtensions {
        /// <summary>
        /// Thanks, Adam, for refactoring this code
        /// Returns a new <see cref="DateTime"/> object with the specified year, month, and day.
        /// If any of the parameters are null, the corresponding value from the original <see cref="DateTime"/> is used.
        /// </summary>
        /// <param name="dt">The original <see cref="DateTime"/> object.</param>
        /// <param name="year">The new year value. If null, the original year is used.</param>
        /// <param name="month">The new month value. If null, the original month is used.</param>
        /// <param name="day">The new day value. If null, the original day is used.</param>
        /// <returns>A new <see cref="DateTime"/> object with the specified year, month, and day.</returns>
        public static DateTime WithDate(this DateTime dt, int? year = null, int? month = null, int? day = null) {
            int newYear = year ?? dt.Year;
            int newMonth = month ?? dt.Month;
            int newDay = day ?? dt.Day;

            // Ensure the new date is valid by clamping day if necessary
            int daysInMonth = DateTime.DaysInMonth(newYear, newMonth);
            newDay = Math.Min(newDay, daysInMonth);

            return new DateTime(newYear, newMonth, newDay, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }
    }
}