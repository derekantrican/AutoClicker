using System;
using System.Drawing;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace AutoClicker.Helpers
{
    public static class MouseLocationHelper
    {
        public static Action<Point> LocationChangeCallback;

        public static void Init()
        {
            Hook.GlobalEvents().MouseClick += MouseLocationHelper_MouseClick;
        }

        private static void MouseLocationHelper_MouseClick(object sender, MouseEventArgs e)
        {
            LocationChangeCallback?.Invoke(new Point(e.X, e.Y));
        }
    }
}
