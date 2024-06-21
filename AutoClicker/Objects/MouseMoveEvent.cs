using AutoClicker.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoClicker.Objects
{
    public class MouseMoveEvent : IBaseEvent
    {
        //Todo: convert to ImpreciseLocation (will break serialized objects)

        public CoordinateSystem StartCoordinateSystem { get; set; }
        public CoordinateSystem EndCoordinateSystem { get; set; }

        public Point StartLocation { get; set; }
        public Point EndLocation { get; set; }

        public Variance StartLocationVar { get; set; }
        public Variance EndLocationVar { get; set; }

        public void PerformAction()
        {
            Point adjustedStartLocation;
            if (StartCoordinateSystem == CoordinateSystem.Absolute)
            {
                adjustedStartLocation = new Point(StartLocation.X + Rand.Int(-StartLocationVar.X, StartLocationVar.X), StartLocation.Y + Rand.Int(-StartLocationVar.Y, StartLocationVar.Y));
            }
            else
            {
                adjustedStartLocation = new Point(Cursor.Position.X + StartLocation.X + Rand.Int(-StartLocationVar.X, StartLocationVar.X), Cursor.Position.Y + StartLocation.Y + Rand.Int(-StartLocationVar.Y, StartLocationVar.Y));
            }

            if (Cursor.Position != adjustedStartLocation)
            {
                MoveMouse(Cursor.Position.X, Cursor.Position.Y, adjustedStartLocation.X, adjustedStartLocation.Y);
            }

            if (EndCoordinateSystem == CoordinateSystem.Absolute)
            {
                MoveMouse(adjustedStartLocation.X, adjustedStartLocation.Y, EndLocation.X + Rand.Int(-EndLocationVar.X, EndLocationVar.X), EndLocation.Y + Rand.Int(-EndLocationVar.Y, EndLocationVar.Y));
            }
            else
            {
                MoveMouse(adjustedStartLocation.X, adjustedStartLocation.Y, Cursor.Position.X + EndLocation.X + Rand.Int(-EndLocationVar.X, EndLocationVar.X), Cursor.Position.Y + EndLocation.Y + Rand.Int(-EndLocationVar.Y, EndLocationVar.Y));
            }
        }

        public override string ToString()
        {
            return $"[MouseMove] Start: ({StartLocation.X}±{StartLocationVar.X}, {StartLocation.Y}±{StartLocationVar.Y}); End: ({EndLocation.X}±{EndLocationVar.X}, {EndLocation.Y}±{EndLocationVar.Y})";
        }

        public static void MoveMouse(int x, int y, int rx, int ry)
        {
            int mouseSpeed = Hypot(rx - x, ry - y) < 300 ? 5 : 15; //Move slower for shorter distances (more realistic)

            double randomSpeed = Math.Max((Rand.Int(mouseSpeed) / 2.0 + mouseSpeed) / 10.0, 0.1);

            WindMouse(x, y, rx, ry, 9.0, 3.0, 10.0 / randomSpeed,
                15.0 / randomSpeed, 10.0 * randomSpeed, 10.0 * randomSpeed);
        }

        static void WindMouse(double xs, double ys, double xe, double ye,
            double gravity, double wind, double minWait, double maxWait,
            double maxStep, double targetArea)
        {

            double dist, windX = 0, windY = 0, veloX = 0, veloY = 0, randomDist, veloMag, step;
            int oldX, oldY, newX = (int)Math.Round(xs), newY = (int)Math.Round(ys);

            double waitDiff = maxWait - minWait;
            double sqrt2 = Math.Sqrt(2.0);
            double sqrt3 = Math.Sqrt(3.0);
            double sqrt5 = Math.Sqrt(5.0);

            dist = Hypot(xe - xs, ye - ys);

            while (dist > 1.0)
            {

                wind = Math.Min(wind, dist);

                if (dist >= targetArea)
                {
                    int w = Rand.Int((int)Math.Round(wind) * 2 + 1);
                    windX = windX / sqrt3 + (w - wind) / sqrt5;
                    windY = windY / sqrt3 + (w - wind) / sqrt5;
                }
                else
                {
                    windX = windX / sqrt2;
                    windY = windY / sqrt2;
                    if (maxStep < 3)
                        maxStep = Rand.Int(3) + 3.0;
                    else
                        maxStep = maxStep / sqrt5;
                }

                veloX += windX;
                veloY += windY;
                veloX = veloX + gravity * (xe - xs) / dist;
                veloY = veloY + gravity * (ye - ys) / dist;

                if (Hypot(veloX, veloY) > maxStep)
                {
                    randomDist = maxStep / 2.0 + Rand.Int((int)Math.Round(maxStep) / 2);
                    veloMag = Hypot(veloX, veloY);
                    veloX = (veloX / veloMag) * randomDist;
                    veloY = (veloY / veloMag) * randomDist;
                }

                oldX = (int)Math.Round(xs);
                oldY = (int)Math.Round(ys);
                xs += veloX;
                ys += veloY;
                dist = Hypot(xe - xs, ye - ys);
                newX = (int)Math.Round(xs);
                newY = (int)Math.Round(ys);

                if (oldX != newX || oldY != newY)
                {
                    Cursor.Position = new Point(newX, newY);
                }

                step = Hypot(xs - oldX, ys - oldY);
                int wait = (int)Math.Round(waitDiff * (step / maxStep) + minWait);
                Thread.Sleep(wait);
            }

            int endX = (int)Math.Round(xe);
            int endY = (int)Math.Round(ye);
            if (endX != newX || endY != newY)
            {
                Cursor.Position = new Point(endX, endY);
            }
        }

        static double Hypot(double dx, double dy)
        {
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
