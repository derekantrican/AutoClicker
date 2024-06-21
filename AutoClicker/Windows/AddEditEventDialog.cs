using System;
using System.Drawing;
using System.Windows.Forms;
using AutoClicker.Objects;

namespace AutoClicker.Windows
{
    public partial class AddEditEventDialog : Form
    {
        public AddEditEventDialog(IBaseEvent baseEvent)
        {
            InitializeComponent();

            InitControls(baseEvent);
        }

        private readonly Point leftPanelLocation = new Point(0, 35);

        public Action<IBaseEvent> ResultEventAction;

        public void InitControls(IBaseEvent baseEvent)
        {
            this.Width = 270;
            panelClickEvent.Location = leftPanelLocation;
            panelMouseMoveEvent.Location = leftPanelLocation;
            panelWaitEvent.Location = leftPanelLocation;

            if (baseEvent == null)
            {
                comboBoxEventType.SelectedIndex = 0;
                comboBoxMouseButton.SelectedIndex = 0;

                panelMouseMoveEvent.Visible = false;
                panelWaitEvent.Visible = false;
            }
            else
            {
                if (baseEvent is ClickEvent clickEvent)
                {
                    comboBoxEventType.SelectedIndex = 0;
                    SetVisibleEventPanel(EventType.ClickEvent);
                    comboBoxMouseButton.SelectedIndex = (int)clickEvent.MouseButton;
                    locationPickerClickEvent.SetValues(clickEvent.CoordinateSystem, clickEvent.ClickLocation, clickEvent.ClickLocationVar);
                }
                else if (baseEvent is MouseMoveEvent mouseMoveEvent)
                {
                    comboBoxEventType.SelectedIndex = 1;
                    SetVisibleEventPanel(EventType.MouseMoveEvent);
                    locationPickerStartLocation.SetValues(mouseMoveEvent.StartCoordinateSystem, mouseMoveEvent.StartLocation, mouseMoveEvent.StartLocationVar);
                    locationPickerEndLocation.SetValues(mouseMoveEvent.EndCoordinateSystem, mouseMoveEvent.EndLocation, mouseMoveEvent.EndLocationVar);
                }
                else if (baseEvent is WaitEvent waitEvent)
                {
                    comboBoxEventType.SelectedIndex = 2;
                    SetVisibleEventPanel(EventType.WaitEvent);
                    numericUpDownDurationMs.Value = (decimal)waitEvent.WaitDuration.TotalMilliseconds;
                    numericUpDownVarMs.Value = waitEvent.VarianceMs;
                }
            }
        }

        private void comboBoxEventType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetVisibleEventPanel((EventType)comboBoxEventType.SelectedIndex);
        }

        private void SetVisibleEventPanel(EventType eventType)
        {
            switch (eventType)
            {
                case EventType.ClickEvent:
                    panelClickEvent.Visible = true;
                    panelMouseMoveEvent.Visible = false;
                    panelWaitEvent.Visible = false;
                    break;
                case EventType.MouseMoveEvent:
                    panelMouseMoveEvent.Visible = true;
                    panelClickEvent.Visible = false;
                    panelWaitEvent.Visible = false;
                    break;
                case EventType.WaitEvent:
                    panelWaitEvent.Visible = true;
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
                        CoordinateSystem = locationPickerClickEvent.CoordinateSystem,
                        ClickLocation = locationPickerClickEvent.Point,
                        ClickLocationVar = new Variance(locationPickerClickEvent.XVariance, locationPickerClickEvent.YVariance),
                    });
                    break;
                case EventType.MouseMoveEvent:
                    ResultEventAction?.Invoke(new MouseMoveEvent
                    {
                        StartCoordinateSystem = locationPickerStartLocation.CoordinateSystem,
                        EndCoordinateSystem = locationPickerEndLocation.CoordinateSystem,
                        StartLocation = locationPickerStartLocation.Point,
                        EndLocation = locationPickerEndLocation.Point,
                        StartLocationVar = new Variance(locationPickerStartLocation.XVariance, locationPickerStartLocation.YVariance),
                        EndLocationVar = new Variance(locationPickerEndLocation.XVariance, locationPickerEndLocation.YVariance),
                    });
                    break;
                case EventType.WaitEvent:
                    ResultEventAction?.Invoke(new WaitEvent
                    {
                        WaitDuration = TimeSpan.FromMilliseconds((double)numericUpDownDurationMs.Value),
                        VarianceMs = (int)numericUpDownVarMs.Value,
                    });
                    break;
            }

            this.Close();
        }
    }
}
