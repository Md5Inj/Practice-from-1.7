using System;
using System.Threading;
namespace _1._9_delegates_threads
{
    class Clock 
    {
        public event EventHandler<TimeIsOverEventArgs> TimeOver = delegate { };
        public event EventHandler<TimeIsStartEventArgs> TimeStart = delegate { };
        public int TimeOut { get; set; }
        public Clock(int time) 
        {
            this.TimeOut = time * 1000;
        }

        public void Start(string msg, string chiefName, string workerName)
        {
            onTimerStart(new TimeIsStartEventArgs() { Message = msg, Name = chiefName });
            Thread.Sleep(this.TimeOut);
            onTimeIsOver(new TimeIsOverEventArgs() { Message = msg, Name = workerName });
        }

        private void onTimeIsOver(TimeIsOverEventArgs eventArgs)
        {
            EventHandler<TimeIsOverEventArgs> temp = TimeOver;
            temp.Invoke(this, eventArgs);
        }

        private void onTimerStart(TimeIsStartEventArgs eventArgs)
        {
            EventHandler<TimeIsStartEventArgs> temp = TimeStart;
            temp.Invoke(this, eventArgs);
        }
    }
}