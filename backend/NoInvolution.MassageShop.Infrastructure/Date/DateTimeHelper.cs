namespace NoInvolution.MassageShop.Infrastructure.Date
{
    /// <summary>
    /// 日期类型的帮助类
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        /// 将日期的DateTime和时间的DateTime合并成一个完整的DateTime
        /// </summary>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime SplicingDateAndTime(DateTime date, DateTime time)
            => new(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);

        /// <summary>
        /// 获取该日期的起始时间
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetDayStartTime(DateTime date)
            => new(date.Year, date.Month, date.Day, 0, 0, 0);

        /// <summary>
        /// 获取该日期的截至时间
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetDayEndTime(DateTime date)
            => new(date.Year, date.Month, date.Day, 23, 59, 59);
    }
}
