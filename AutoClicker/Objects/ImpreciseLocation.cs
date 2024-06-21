using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Point Location { get; set; }

        public Variance Variance { get; set; }
    }
}
