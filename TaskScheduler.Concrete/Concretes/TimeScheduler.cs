using TaskScheduler.Abstractions.Abstractions;

namespace TaskScheduler.Concretes.Concretes
{
    public class TimeScheduler<T> : TaskSchedulerBase<T> where T : class
    {
        public TimeScheduler(TimeSpan timeSpan, Action action) : base(timeSpan, action)
        {
            
        }
        public TimeScheduler(TimeSpan timeSpan, Func<T> func, Action<T> action) : base(timeSpan, func, action)
        {

        }

        protected override double GetInterval()
        {
            //DateTime nextRunOn =
            //DateTime.Today.AddHours(Time.Hours).AddMinutes(Time.Minutes).AddSeconds(Time.Seconds);
            //if (nextRunOn < DateTime.Now)
            //{
            //    nextRunOn = nextRunOn.AddMinutes(1);
            //}
            //if (nextRunOn < DateTime.Now)
            //{
            //    nextRunOn = nextRunOn.AddDays(1);
            //}
            //return (nextRunOn - DateTime.Now).TotalMilliseconds;

            return 5000;
        }
    }
}
