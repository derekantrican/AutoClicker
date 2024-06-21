using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoClicker.Objects
{
    public class WaitEvent : IBaseEvent
    {
        public TimeSpan WaitDuration { get; set; }

        public int RandomWaitMs { get; set; } = 350;

        public void PerformAction()
        {
            Thread.Sleep(WaitDuration.Add(TimeSpan.FromMilliseconds(new Random().Next(RandomWaitMs))));
        }

        public override string ToString()
        {
            return $"[Wait] {WaitDuration.TotalMilliseconds} ms";
        }
    }
}
