using System;
using System.Windows.Forms;
using AutoClicker.Objects;
using Gma.System.MouseKeyHook;

namespace AutoClicker.Windows
{
    public partial class LocationPicker : UserControl
    {
        private IKeyboardMouseEvents keyboardMouseEvents;

        public LocationPicker()
        {
            InitializeComponent();

            keyboardMouseEvents = Hook.GlobalEvents();
			comboBoxCoordinateSystem.SelectedIndex = 0;
        }

        public string Title
        {
            get { return groupBox.Text; }
            set { groupBox.Text = value; }
        }

        public ImpreciseLocation ChosenLocation
        {
            get
            {
                return new ImpreciseLocation
                {
                    CoordinateSystem = CoordinateSystem,
                    X = X,
                    Y = Y,
                    Variance = new Variance(XVariance, YVariance),
                };
            }
            set
            {
                CoordinateSystem = value.CoordinateSystem;
                X = value.X;
                Y = value.Y;
                XVariance = value.Variance?.X ?? 0;
                YVariance = value.Variance?.Y ?? 0;
            }
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
            keyboardMouseEvents.MouseClick += SaveChosenPoint; 
            buttonPick.Enabled = false;
            buttonPick.Text = "Picking...";
        }

        private void SaveChosenPoint(object sender, MouseEventArgs e)
        {
			X = e.X;
            Y = e.Y;

			keyboardMouseEvents.MouseClick -= SaveChosenPoint;
			buttonPick.Enabled = true;
			buttonPick.Text = "Pick";
		}
    }
}
