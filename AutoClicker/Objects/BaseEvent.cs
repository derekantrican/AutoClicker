
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
