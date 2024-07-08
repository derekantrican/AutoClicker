using System.Drawing;

namespace AutoClicker.Objects
{
    public enum CoordinateSystem //Rather than "Absolute" and "Relative" we might want to describe these (both in UI & code) as "Absolute" and "Distance"
    {
        Absolute,
        Relative,
    }

    public class ImpreciseLocation
    {
        public CoordinateSystem CoordinateSystem { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public Variance Variance { get; set; }
    }
}
