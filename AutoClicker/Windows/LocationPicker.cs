using System;
using System.Drawing;
using System.Windows.Forms;
using AutoClicker.Helpers;
using AutoClicker.Objects;

namespace AutoClicker.Windows
{
    public partial class LocationPicker : UserControl
    {
        public LocationPicker()
        {
            InitializeComponent();

            comboBoxCoordinateSystem.SelectedIndex = 0;
        }

        //Todo: convert to ImpreciseLocation (will break serialized objects)
        public void SetValues(CoordinateSystem coordinateSystem, Point point, Variance variance)
        {
            CoordinateSystem = coordinateSystem;
            Point = point;
            XVariance = variance.X;
            YVariance = variance.Y;
        }

        public string Title
        {
            get { return groupBox.Text; }
            set { groupBox.Text = value; }
        }

        public CoordinateSystem CoordinateSystem
        {
            get { return (CoordinateSystem)Enum.Parse(typeof(CoordinateSystem), comboBoxCoordinateSystem.Text); }
            set { comboBoxCoordinateSystem.Text = value.ToString(); }
        }

        public int X
        {
            get { return Convert.ToInt32(textBoxX.Text); }
            set { textBoxX.Text = value.ToString(); }
        }

        public int Y
        {
            get { return Convert.ToInt32(textBoxY.Text); }
            set { textBoxY.Text = value.ToString(); }
        }

        public Point Point
        {
            get { return new Point(X, Y); }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public int XVariance
        {
            get { return Convert.ToInt32(textBoxVarX.Text); }
            set { textBoxVarX.Text = value.ToString(); }
        }

        public int YVariance
        {
            get { return Convert.ToInt32(textBoxVarY.Text); }
            set { textBoxVarY.Text = value.ToString(); }
        }

        private void buttonPick_Click(object sender, EventArgs e)
        {
            MouseLocationHelper.LocationChangeCallback += SaveChosenPoint;
        }

        private void SaveChosenPoint(Point point)
        {
            X = point.X;
            Y = point.Y;

            MouseLocationHelper.LocationChangeCallback -= SaveChosenPoint;
        }
    }
}
