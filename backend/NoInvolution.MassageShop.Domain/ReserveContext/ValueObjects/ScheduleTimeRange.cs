using MiCake.DDD.Domain;

namespace NoInvolution.MassageShop.Domain.ReserveContext
{
    /// <summary>
    /// 排班时间
    /// </summary>
    /// <param name="StartTime"></param>
    /// <param name="EndTime"></param>
    public record ScheduleTimeRange(DateTime StartTime, DateTime EndTime) : IValueObject
    {
        public static ScheduleTimeRange Create(DateTime start, DateTime endTime)
        {
            if (start > endTime)
            {
                throw DomainExceptionDescriber.DataError("排班时间");
            }

            return new ScheduleTimeRange(start, endTime);
        }

        public double GetHour()
            => (EndTime - StartTime).TotalHours;
    }

    public class Women
    {
        public string Name { get; set; } = "BiaoMei";

        public People MyBoyFriend { get; private set; }

        public void SetBoyFriend(People people)
        {
            if (people.Age > 27)
            {
                throw new Exception("我不接受");
            }

            // 更多要求

            MyBoyFriend = people;
        }
    }

    public class People
    {
        public int Age { get; set; }
    }
}
