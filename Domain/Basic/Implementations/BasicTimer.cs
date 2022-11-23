using System;
using System.Timers;
using Domain.Basic.Interfaces;

namespace Domain.Basic.Implementations
{
    public class BasicTimer : IBasicTimer
    {
        Timer tmr;
        Action act;

        public BasicTimer(double interval, Action action)
        {
            tmr = new Timer();
            tmr.Interval = interval;
            act = action;
            tmr.Elapsed += (sender, e) =>
            {
                act();
            };
        }

        public void Start()
        {
            tmr.Start();
        }
        public void Stop()
        {
            tmr.Stop();
        }
    }
}
