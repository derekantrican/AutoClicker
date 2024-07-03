
namespace AutoClicker.Objects
{
    public struct Rect
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }

        public override string ToString()
        {
            return $"Location: ({Left}, {Top}), Width: {Right - Left}, Height: {Bottom - Top}";
        }
    }
}
