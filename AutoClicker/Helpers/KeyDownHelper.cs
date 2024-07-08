using System;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace AutoClicker.Helpers
{
    public static class KeyDownHelper
    {
        public static Action<KeyEventArgs> KeyDownCallback;

        public static void Init()
        {
            Hook.GlobalEvents().KeyDown += KeyDownHelper_KeyDown;
        }

        private static void KeyDownHelper_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownCallback?.Invoke(e);
        }
    }
}
