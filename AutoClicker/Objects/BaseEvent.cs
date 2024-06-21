using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClicker.Objects
{
    public enum EventType
    {
        ClickEvent,
        MouseMoveEvent,
        WaitEvent,
    }

    public interface IBaseEvent
    {
        void PerformAction();
    }
}
