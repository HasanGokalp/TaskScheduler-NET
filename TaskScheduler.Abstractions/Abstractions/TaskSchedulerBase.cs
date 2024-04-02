namespace TaskScheduler.Abstractions.Abstractions
{
    public abstract class TaskSchedulerBase<T> : System.Timers.Timer, IDisposable
    {
        public TimeSpan Time { get; set; }
        protected TaskSchedulerBase(TimeSpan timeSpan, Action action)
        {
            Time = timeSpan;
            Reset();
            Elapsed += (e, s) => Task.Run(() => action());
        }
        protected TaskSchedulerBase(TimeSpan timeSpan, Func<T> func, Action<T> action) 
        {
            Time = timeSpan;
            Reset();
            Elapsed += (e, s) => 
            {
                Task.Factory.StartNew(func)
                    .ContinueWith(prevTask => action(prevTask.Result));
            };
        }
        private void Reset()
        {
            Stop();
            Interval = GetInterval();
            Enabled = true;
            Start();
        }

        protected abstract double GetInterval();

        protected override void Dispose(bool disposing) 
        {
            Stop();
            base.Dispose(disposing);
        }
    }
}
