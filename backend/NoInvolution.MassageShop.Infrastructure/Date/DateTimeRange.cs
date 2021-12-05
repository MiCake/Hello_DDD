namespace NoInvolution.MassageShop.Infrastructure.Date
{
    /// <summary>
    /// 时间段类
    /// </summary>
    public class DateTimeRange
    {
        //时间段开始时间
        private readonly DateTime _startTime;
        public DateTime StartTime
        {
            get { return _startTime; }
        }

        //时间段结束时间
        private readonly DateTime _endTime;
        public DateTime EndTime
        {
            get { return _endTime; }
        }

        /// <summary>
        /// 最小时间段
        /// </summary>
        public static DateTimeRange Min
        {
            get { return new DateTimeRange(DateTime.MinValue, DateTime.MinValue); }
        }

        /// <summary>
        /// 最大时间段
        /// </summary>
        public static DateTimeRange Max
        {
            get { return new DateTimeRange(DateTime.MinValue, DateTime.MaxValue); }
        }

        /// <summary>
        /// 该时间段的天数
        /// </summary>
        public double Days => (EndTime - StartTime).TotalDays;

        #region Ctor

        /// <summary>
        /// 时间段【保证输入的两个时间点大小可以构成正确的的时间段】
        /// </summary>
        /// <param name="startTime">时间段开始时间</param>
        /// <param name="endTime">时间段结束时间</param>
        /// <param name="isTransform">true:如果大小相反则自动交换  false:大小相反则抛出异常</param>
        public DateTimeRange(DateTime startTime, DateTime endTime, bool isTransform)
        {
            var tempStartTime = startTime;
            var tempEndTime = endTime;

            //是否顺序错误
            bool isOrderMiss = false;
            if (tempStartTime.CompareTo(tempEndTime) > 0)
            {
                isOrderMiss = true;
                tempStartTime = endTime;
                tempEndTime = startTime;
            }

            if (isOrderMiss && !isTransform)
                throw new Exception("DateTimeRange:StartTime is more than EndTime!");

            _startTime = tempStartTime;
            _endTime = tempEndTime;

        }

        /// <summary>
        /// 时间段
        /// </summary>
        /// <param name="startTime">时间段开始时间</param>
        /// <param name="endTime">时间段结束时间</param>
        public DateTimeRange(DateTime startTime, DateTime endTime)
            : this(startTime, endTime, true)
        {

        }

        #endregion

        /// <summary>
        /// 获取时间段重叠部分. 如果没有重叠 返回为null
        /// </summary>
        /// <param name="timeRange">比较的时间段</param>
        /// <param name="isIncludeLimit">是否要认为两点相同为重叠</param>
        /// <returns></returns>
        public DateTimeRange GetAlphalRange(DateTimeRange timeRange, bool isIncludeLimit = false)
        {
            DateTimeRange reslut = null;

            DateTime bStartTime = _startTime;
            DateTime oEndTime = _endTime;
            DateTime sStartTime = timeRange.StartTime;
            DateTime eEndTime = timeRange.EndTime;

            bool isAlphal = isIncludeLimit ?
                            bStartTime <= eEndTime && oEndTime >= sStartTime :
                            bStartTime < eEndTime && oEndTime > sStartTime;

            if (isAlphal)
            {
                // 一定有重叠部分
                DateTime sTime = sStartTime >= bStartTime ? sStartTime : bStartTime;
                DateTime eTime = oEndTime >= eEndTime ? eEndTime : oEndTime;

                reslut = new DateTimeRange(sTime, eTime);
            }
            return reslut;
        }

        /// <summary>
        /// 获取多个时间段重叠部分. 如果没有重叠 返回为null
        /// </summary>
        /// <param name="timeRangeList">比较的时间段</param>
        /// <param name="isIncludeLimit">是否要认为两点相同为重叠</param>
        /// <returns></returns>
        public DateTimeRange GetAlphalRange(List<DateTimeRange> timeRangeList, bool isIncludeLimit = false)
        {
            DateTimeRange reslut = this;

            foreach (var timeRange in timeRangeList)
            {
                var tempReslut = reslut.GetAlphalRange(timeRange, isIncludeLimit);
                if (tempReslut == null) return null;
                reslut = tempReslut;
            }
            return reslut;
        }

        /// <summary>
        /// 获取该时间段的小时数
        /// </summary>
        public double GetRangeHours()
        {
            return (_endTime - _startTime).TotalHours;
        }

        /// <summary>
        /// 获取该时间段的分钟数
        /// </summary>
        public double GetRangeMinutes()
        {
            return (_endTime - _startTime).TotalMinutes;
        }

        /// <summary>
        /// 获取两者时间中小的时间段
        /// </summary>
        /// <param name="compareRange">需要比较的时间段</param>
        public DateTimeRange GetMinTimeRange(DateTimeRange compareRange)
        {
            if (GetRangeMinutes() > compareRange.GetRangeMinutes())
                return compareRange;

            return this;
        }

        /// <summary>
        /// 获取两者时间中小的时间段
        /// </summary>
        /// <param name="compareRangeList">需要比较的时间段</param>
        public DateTimeRange GetMinTimeRange(List<DateTimeRange> compareRangeList)
        {
            var minResult = this;

            foreach (var compareRange in compareRangeList)
            {
                if (minResult.GetRangeMinutes() > compareRange.GetRangeMinutes())
                    minResult = compareRange;
            }
            return minResult;
        }

        /// <summary>
        /// 判断时间点是否在该时间段内
        /// </summary>
        public bool IsTimeInRange(DateTime iTime)
        {
            return _startTime.CompareTo(iTime) <= 0 && _endTime.CompareTo(iTime) >= 0;
        }

        /// <summary>
        /// 判断两段时间是否存在完全包含关系
        /// </summary>
        public bool IsAllInclude(DateTimeRange compareRange)
        {
            return compareRange.StartTime >= StartTime && compareRange.EndTime <= EndTime || StartTime >= compareRange.StartTime && EndTime <= compareRange.EndTime;
        }

        /// <summary>
        /// 判断该时间段是否完全覆盖了另一条时间段
        /// </summary>
        /// <param name="compareRange">比较的时间段</param>
        /// <returns></returns>
        public bool IsCoverTimeRange(DateTimeRange compareRange)
        {
            return StartTime <= compareRange.StartTime && EndTime >= compareRange.EndTime;
        }

        /// <summary>
        /// 尝试将两个时间段进行融合为一条新的时间段
        /// </summary>
        /// <param name="mixRange">需要融合的时间段</param>
        /// <param name="newTimeRange">融合后的新时间段，融合失败返回为null</param>
        public bool TryMixTimeRange(DateTimeRange mixRange, out DateTimeRange newTimeRange)
        {
            bool result = false;
            newTimeRange = null;

            DateTime bStartTime = _startTime;
            DateTime oEndTime = _endTime;
            DateTime sStartTime = mixRange.StartTime;
            DateTime eEndTime = mixRange.EndTime;

            if (bStartTime <= eEndTime && oEndTime >= sStartTime)
            {
                DateTime newStartTime = bStartTime >= sStartTime ? sStartTime : bStartTime;
                DateTime newEndTime = _endTime >= eEndTime ? _endTime : eEndTime;

                newTimeRange = new DateTimeRange(newStartTime, newEndTime);
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 尝试将两个时间段进行融合为一条新的时间段.如果不存在融合关系将抛出异常<see cref="ArgumentException"/>
        /// </summary>
        /// <param name="mixRange">需要融合的时间段</param>
        /// <returns>融合后的新时间段</returns>
        public DateTimeRange MixTimeRange(DateTimeRange mixRange)
        {
            DateTimeRange newRange = null;
            if (TryMixTimeRange(mixRange, out newRange))
                return newRange;
            else
                throw new ArgumentException("try mix datetimerange wrong!");
        }

        /// <summary>
        /// 尝试将该时间段于其他时间段相融合
        /// </summary>
        /// <param name="mixTimeRanges">需要融合的时间段集合</param>
        /// <param name="newTimeRange">融合后的新时间段，融合失败返回为null</param>
        public bool TryMixTimeRangeList(List<DateTimeRange> mixTimeRanges, out DateTimeRange newTimeRange)
        {
            bool result = false;
            DateTimeRange tempTimeRange = this;

            mixTimeRanges = mixTimeRanges.OrderBy(s => s.StartTime).ToList();
            foreach (var mixRange in mixTimeRanges)
            {
                result = tempTimeRange.TryMixTimeRange(mixRange, out tempTimeRange);
                if (!result) break;
            }
            if (result == false) tempTimeRange = null;
            newTimeRange = tempTimeRange;
            return result;
        }

        /// <summary>
        /// 将DateTimeRange显式转换为double类型[返回为时间段的小时数]
        /// </summary>
        /// <param name="timeRange"></param>
        public static explicit operator double(DateTimeRange timeRange)
        {
            if (timeRange == null) return 0;
            return timeRange.GetRangeHours();
        }
    }
}
