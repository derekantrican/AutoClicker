using System;
using System.Threading;

namespace AutoClicker.Objects
{
    public class WaitEvent : IBaseEvent
    {
        public TimeSpan WaitDuration { get; set; }

        public int VarianceMs { get; set; } = 350;

        public void PerformAction()
        {
            Thread.Sleep(WaitDuration.Add(TimeSpan.FromMilliseconds(new Random().Next(VarianceMs))));
        }

        //Todo: should move cursor randomly while waiting

        public override string ToString()
        {
            return $"[Wait] {WaitDuration.TotalMilliseconds}±{VarianceMs} ms";
        }
    }
}
