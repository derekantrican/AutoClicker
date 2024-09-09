using System;
using System.Drawing;
using System.Windows.Forms;
using AutoClicker.Helpers;
using AutoClicker.Objects;

namespace AutoClicker.Windows
{
	public partial class LocationIndicator : Form
	{
		public LocationIndicator()
		{
			InitializeComponent();
		}

		bool showDashedBorder = false;
		public void SetLocation(ImpreciseLocation location)
		{
			if (location.Variance != null && location.Variance.X > 0 && location.Variance.Y > 0)
			{
				this.Width = location.Variance.X * 2;
				this.Height = location.Variance.Y * 2;

				//Adjust "X" indicator for smaller Variance so that the "X" doesn't obscure the panel's border
				// (for really small action variance areas, the "X" may not be visible because it is too small)
				int margin = 5;
				if (pictureBox.Width > panel.Width - margin * 2 || pictureBox.Height > panel.Height - margin * 2)
				{
					pictureBox.Width = this.Width - margin * 2;
					pictureBox.Height = this.Height - margin * 2;
					pictureBox.Location = new Point(panel.Left + margin, panel.Top + margin);
				}

				showDashedBorder = true;
				panel.Invalidate(); //Repaint
			}

			this.Left = location.X - this.Width / 2;
			this.Top = location.Y - this.Height / 2;
		}

		public void SetLocationWithReferenceLocation(ImpreciseLocation location, Point reference)
		{
			SetLocation(location);
			float degrees = (float)(Math.Atan2(reference.Y - location.Y, reference.X - location.X) * 180.0 / Math.PI);
			pictureBox.Image = Properties.Resources._out.RotateImage(degrees);
		}

		public void SetPointAndArea(Point point, Size area)
		{
			showDashedBorder = true;

			pictureBox.Width = (int)Math.Min(25, Math.Max(10, area.Width * .3));
			pictureBox.Height = pictureBox.Width;

			this.Width = area.Width + pictureBox.Width / 2;
			this.Height = area.Height + pictureBox.Height / 2;

			//Todo: maybe the pictureBox shouldn't be in the panel by default (just "over" the panel?) so we don't have to do this?
			panel.Controls.Remove(pictureBox);
			this.Controls.Add(pictureBox);
			pictureBox.Location = new Point(0, 0);
			pictureBox.BringToFront();

			this.Left = point.X - pictureBox.Width / 2;
			this.Top = point.Y - pictureBox.Height / 2;

			panel.Dock = DockStyle.None;
			panel.Left = pictureBox.Width / 2;
			panel.Top = pictureBox.Height / 2;
			panel.Width = area.Width;
			panel.Height = area.Height;
		}

		private void panel_Paint(object sender, PaintEventArgs e)
		{
			if (showDashedBorder)
			{
				int width = 2;
				ControlPaint.DrawBorder(e.Graphics, this.panel.ClientRectangle,
					Color.Red, width, ButtonBorderStyle.Dashed,
					Color.Red, width, ButtonBorderStyle.Dashed,
					Color.Red, width, ButtonBorderStyle.Dashed,
					Color.Red, width, ButtonBorderStyle.Dashed);
			}
		}
	}
}
