using AutoClicker.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoClicker.Windows
{
    public partial class LocationPicker : UserControl
    {
        public LocationPicker()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return groupBox.Text; }
            set { groupBox.Text = value; }
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

        private void buttonPick_Click(object sender, EventArgs e)
        {
            MouseLocationHelper.LocationPickCallback += SaveChosenPoint;
        }

        private void SaveChosenPoint(Point point)
        {
            X = point.X;
            Y = point.Y;

            MouseLocationHelper.LocationPickCallback -= SaveChosenPoint;
        }
    }
}
