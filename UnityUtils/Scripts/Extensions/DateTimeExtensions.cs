using System;

namespace UnityUtils {
    public static class DateTimeExtensions {
        /// <summary>
        /// Changes the year of a <see cref="DateTime"/>.
        /// </summary>
        /// <param name="dt">The original date time, to change.</param>
        /// <param name="newYear">The new year.</param>
        /// <remarks>Source: https://stackoverflow.com/a/41805608</remarks>
        /// <returns>The adjusted <see cref="DateTime"/>.</returns>
        public static DateTime ChangeYear(this DateTime dt, int newYear) => dt.AddYears(newYear - dt.Year);

        /// <summary>
        /// Changes the month of a <see cref="DateTime"/>.
        /// </summary>
        /// <param name="dt">The original date time, to change.</param>
        /// <param name="newMonth">The new month.</param>
        /// <remarks>Adjusted from https://stackoverflow.com/a/41805608</remarks>
        /// <returns>The adjusted <see cref="DateTime"/>.</returns>
        public static DateTime ChangeMonth(this DateTime dt, int newMonth) => dt.AddMonths(newMonth - dt.Month);

        /// <summary>
        /// Changes the month of a <see cref="DateTime"/>.
        /// </summary>
        /// <param name="dt">The original date time, to change.</param>
        /// <param name="newDay">The new day.</param>
        /// <remarks>Adjusted from https://stackoverflow.com/a/41805608</remarks>
        /// <returns>The adjusted <see cref="DateTime"/>.</returns>
        public static DateTime ChangeDay(this DateTime dt, int newDay) => dt.AddDays(newDay - dt.Day);
    }
}