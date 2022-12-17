using System.Timers;
using Data.Basic.Interfaces;

namespace Data.Basic.Implementations
{
    public class BasicTimer : IBasicTimer
    {
        System.Timers.Timer tmr;
        Action act;

        public BasicTimer(double interval, Action action)
        {
            tmr = new System.Timers.Timer();
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
