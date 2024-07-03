using System.Collections.Generic;

namespace AutoClicker.Objects
{
    public class SaveData
    {
        public SavedWindow TargetWindow { get; set; }
        public List<IBaseEvent> Actions { get; set; }
    }

    public class SavedWindow
    {
        public string Title { get; set; }
        public Rect Bounds { get; set; }
    }
}
