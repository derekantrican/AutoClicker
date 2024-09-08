
using System.Threading;

namespace AutoClicker.Objects
{
    public enum EventType
    {
        ClickEvent,
        MouseMoveEvent,
        WaitEvent,
        ImageValidation,
    }

    public interface IBaseEvent
    {
        bool PerformAction(CancellationToken cancellationToken);
    }
}
