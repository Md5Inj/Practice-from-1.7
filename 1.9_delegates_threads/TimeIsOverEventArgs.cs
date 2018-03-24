using System;

namespace _1._9_delegates_threads
{
    public class TimeIsOverEventArgs : EventArgs
    {
        public string Message { get; set; }
        public string Name {get; set;}
    }


    public class TimeIsStartEventArgs : EventArgs
    {
        public string Message { get; set; }
        public string Name {get; set;}
    }
}