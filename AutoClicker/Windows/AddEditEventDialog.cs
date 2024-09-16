using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AutoClicker.Helpers;
using AutoClicker.Objects;
using Gma.System.MouseKeyHook;

namespace AutoClicker.Windows
{
    public partial class AddEditEventDialog : Form
    {
		private IKeyboardMouseEvents keyboardMouseEvents;
		Point? relativeTo;

        public AddEditEventDialog(IBaseEvent baseEvent, Point? relativeTo)
        {
            InitializeComponent();

			keyboardMouseEvents = Hook.GlobalEvents();
			this.relativeTo = relativeTo;

            InitControls(baseEvent);
        }

        private readonly Point leftPanelLocation = new Point(0, 35);

        public Action<IBaseEvent> ResultEventAction;

        public void InitControls(IBaseEvent baseEvent)
        {
            this.Width = 250;
            panelClickEvent.Location = leftPanelLocation;
            panelMouseMoveEvent.Location = leftPanelLocation;
            panelWaitEvent.Location = leftPanelLocation;
            panelImageValidation.Location = leftPanelLocation;

            if (baseEvent == null)
            {
                this.Text = "Add Event";

                comboBoxEventType.SelectedIndex = 0;
                comboBoxMouseButton.SelectedIndex = 0;

                panelMouseMoveEvent.Visible = false;
                panelWaitEvent.Visible = false;
            }
            else
            {
                this.Text = $"Edit Event ({baseEvent})";

                if (baseEvent is ClickEvent clickEvent)
                {
                    comboBoxEventType.SelectedIndex = 0;
                    SetVisibleEventPanel(EventType.ClickEvent);
                    comboBoxMouseButton.SelectedIndex = (int)clickEvent.MouseButton;
                    locationPickerClickEvent.ChosenLocation = clickEvent.Location;
                }
                else if (baseEvent is MouseMoveEvent mouseMoveEvent)
                {
                    comboBoxEventType.SelectedIndex = 1;
                    SetVisibleEventPanel(EventType.MouseMoveEvent);
                    locationPickerStartLocation.ChosenLocation = mouseMoveEvent.StartLocation;
                    locationPickerEndLocation.ChosenLocation = mouseMoveEvent.EndLocation;
                }
                else if (baseEvent is WaitEvent waitEvent)
                {
                    comboBoxEventType.SelectedIndex = 2;
                    SetVisibleEventPanel(EventType.WaitEvent);
                    numericUpDownDurationMs.Value = (decimal)waitEvent.WaitDuration.TotalMilliseconds;
                    numericUpDownVarMs.Value = waitEvent.VarianceMs;
                }
                else if (baseEvent is ImageValidation imageValidation)
                {
					comboBoxEventType.SelectedIndex = 3;
					SetVisibleEventPanel(EventType.ImageValidation);
                    pictureBoxImage.Image = imageValidation.Image;
					labelImageInfo.Text = $"Width: {imageValidation.Image.Width}\n\nHeight: {imageValidation.Image.Height}";
					textBoxImageLocX.Text = imageValidation.CheckAreaLocation.X.ToString();
                    textBoxImageLocY.Text = imageValidation.CheckAreaLocation.Y.ToString();
                    textBoxCheckAreaWidth.Text = imageValidation.CheckAreaSize.Width.ToString();
					textBoxCheckAreaHeight.Text = imageValidation.CheckAreaSize.Height.ToString();
				}
            }
        }

        private void comboBoxEventType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetVisibleEventPanel((EventType)comboBoxEventType.SelectedIndex);
        }

        private void SetVisibleEventPanel(EventType eventType)
        {
            buttonShowPoint.Visible = true;

            switch (eventType)
            {
                case EventType.ClickEvent:
                    panelClickEvent.Visible = true;
                    panelMouseMoveEvent.Visible = false;
                    panelWaitEvent.Visible = false;
					panelImageValidation.Visible = false;
					break;
                case EventType.MouseMoveEvent:
                    panelMouseMoveEvent.Visible = true;
                    panelClickEvent.Visible = false;
                    panelWaitEvent.Visible = false;
					panelImageValidation.Visible = false;
					break;
                case EventType.WaitEvent:
                    panelWaitEvent.Visible = true;
                    panelMouseMoveEvent.Visible = false;
                    panelClickEvent.Visible = false;
					panelImageValidation.Visible = false;

                    buttonShowPoint.Visible = false;
					break;
                case EventType.ImageValidation:
                    panelImageValidation.Visible = true;
					panelWaitEvent.Visible = false;
					panelMouseMoveEvent.Visible = false;
					panelClickEvent.Visible = false;
					break;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            switch ((EventType)comboBoxEventType.SelectedIndex)
            {
                case EventType.ClickEvent:
                    ResultEventAction?.Invoke(new ClickEvent
                    {
                        MouseButton = (MouseButton)comboBoxMouseButton.SelectedIndex,
                        Location = locationPickerClickEvent.ChosenLocation,
                    });
                    break;
                case EventType.MouseMoveEvent:
                    ResultEventAction?.Invoke(new MouseMoveEvent
                    {
                        StartLocation = locationPickerStartLocation.ChosenLocation,
                        EndLocation = locationPickerEndLocation.ChosenLocation,
                    });
                    break;
                case EventType.WaitEvent:
                    ResultEventAction?.Invoke(new WaitEvent
                    {
                        WaitDuration = TimeSpan.FromMilliseconds((double)numericUpDownDurationMs.Value),
                        VarianceMs = (int)numericUpDownVarMs.Value,
                    });
                    break;
                case EventType.ImageValidation:
                    Size checkAreaSize = new Size(Convert.ToInt32(textBoxCheckAreaWidth.Text), Convert.ToInt32(textBoxCheckAreaHeight.Text));
                    if (checkAreaSize.Width < pictureBoxImage.Image.Width || checkAreaSize.Height < pictureBoxImage.Image.Height)
                    {
                        MessageBox.Show("The \"Area to check\" size must be bigger than the reference image");
                        return;
                    }

					ResultEventAction?.Invoke(new ImageValidation
                    {
                        CheckAreaLocation = new Point(Convert.ToInt32(textBoxImageLocX.Text), Convert.ToInt32(textBoxImageLocY.Text)),
                        CheckAreaSize = new Size(Convert.ToInt32(textBoxCheckAreaWidth.Text), Convert.ToInt32(textBoxCheckAreaHeight.Text)),
                        Image = new Bitmap(pictureBoxImage.Image),
                    });
                    break;
            }

            this.Close();
        }

		private void buttonUploadImage_Click(object sender, EventArgs e)
		{
            //Todo: this should be a screenshot tool instead that will save both the image & the location from where it was taken
			using (OpenFileDialog dialog = new OpenFileDialog())
			{
                dialog.Filter = "Images|*.png;*.jpg;*.bmp;*.gif;*.exif;*.tiff"; //These are the filetypes allowed by the Bitmap constructor
				dialog.RestoreDirectory = true;

				if (dialog.ShowDialog() == DialogResult.OK)
				{
                    Bitmap bitmap = new Bitmap(dialog.FileName);

                    List<Color> pixels = bitmap.GetPixelMap().To1dList();
                    if (pixels.Any(p => p.A < 255))
                    {
                        MessageBox.Show($"Your image has some transparent or partially-transparent pixels, which are currently not supported. Please choose a different image");
                        return;
                    }

                    pictureBoxImage.Image = bitmap;
                    labelImageInfo.Text = $"Width: {bitmap.Width}\n\nHeight: {bitmap.Height}";
				}
			}
		}

        bool showingIndicators = false;
        List<Form> indicators = new List<Form>();

		private void buttonShowPoint_MouseDown(object sender, MouseEventArgs e)
		{
            if (!showingIndicators)
            {
				switch ((EventType)comboBoxEventType.SelectedIndex)
                {
                    case EventType.WaitEvent:
                        //Do nothing
                        return;
                    case EventType.ClickEvent:
						LocationIndicator clickLocation = new LocationIndicator();
						clickLocation.Show();
                        clickLocation.SetLocation(locationPickerClickEvent.ChosenLocation.ShiftRelativeIfNeeded(relativeTo));
						indicators.Add(clickLocation);
						break;
                    case EventType.MouseMoveEvent:
						LocationIndicator mouseMoveStart = new LocationIndicator();
						mouseMoveStart.Show();
                        mouseMoveStart.SetLocationWithReferenceLocation(locationPickerStartLocation.ChosenLocation.ShiftRelativeIfNeeded(relativeTo),
                            locationPickerEndLocation.ChosenLocation.ShiftRelativeIfNeeded(relativeTo).Point);
                        indicators.Add(mouseMoveStart);

                        Point? endRelativeTo = null;
                        if (locationPickerEndLocation.ChosenLocation.CoordinateSystem == CoordinateSystem.Relative)
                        {
                            if (locationPickerStartLocation.ChosenLocation.CoordinateSystem == CoordinateSystem.Absolute)
                            {
                                endRelativeTo = locationPickerStartLocation.ChosenLocation.Point;
                            }
                            else
                            {
                                endRelativeTo = locationPickerStartLocation.ChosenLocation.ShiftRelativeIfNeeded(relativeTo).Point;
                            }
                        }

						LocationIndicator mouseMoveEnd = new LocationIndicator();
						mouseMoveEnd.Show();
                        mouseMoveEnd.SetLocation(locationPickerEndLocation.ChosenLocation.ShiftRelativeIfNeeded(endRelativeTo));
						indicators.Add(mouseMoveEnd);
						break;
                    case EventType.ImageValidation:
						LocationIndicator imageValidationLocationIndicator = new LocationIndicator();
						imageValidationLocationIndicator.Show();
                        imageValidationLocationIndicator.SetPointAndArea(new Point(Convert.ToInt32(textBoxImageLocX.Text), Convert.ToInt32(textBoxImageLocY.Text)),
                            new Size(Convert.ToInt32(textBoxCheckAreaWidth.Text), Convert.ToInt32(textBoxCheckAreaHeight.Text)));
						indicators.Add(imageValidationLocationIndicator);
						break;
                }

				showingIndicators = true;
			}
		}

		private void buttonShowPoint_MouseUp(object sender, MouseEventArgs e)
		{
            if (showingIndicators)
            {
                foreach (Form indicator in indicators.ToList() /*make copy*/)
                {
                    indicator.Close();
                    indicators.Remove(indicator);
                }

                showingIndicators = false;
            }
		}

		private void buttonScreenshot_Click(object sender, EventArgs e)
		{
            Bitmap bitmap = new Bitmap(Convert.ToInt32(textBoxCheckAreaWidth.Text), Convert.ToInt32(textBoxCheckAreaHeight.Text));
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(new Point(Convert.ToInt32(textBoxImageLocX.Text), Convert.ToInt32(textBoxImageLocY.Text)), Point.Empty, bitmap.Size);
            }

            pictureBoxImage.Image = bitmap;
            labelImageInfo.Text = $"Width: {bitmap.Width}\n\nHeight: {bitmap.Height}";
		}

		private void buttonImageValidationPointPick_Click(object sender, EventArgs e)
		{
			keyboardMouseEvents.MouseClick += SaveChosenImageValidationPoint;
			buttonImageValidationPointPick.Enabled = false;
			buttonImageValidationPointPick.Text = "Picking...";
		}

		private void SaveChosenImageValidationPoint(object sender, MouseEventArgs e)
		{
		    textBoxImageLocX.Text = e.X.ToString();
			textBoxImageLocY.Text = e.Y.ToString();

			keyboardMouseEvents.MouseClick -= SaveChosenImageValidationPoint;
			buttonImageValidationPointPick.Enabled = true;
			buttonImageValidationPointPick.Text = "Pick";
		}
	}
}
