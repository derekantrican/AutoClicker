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
                    SetVisibleEventPanel(EventType.ClickEvent);
                    comboBoxMouseButton.SelectedIndex = (int)clickEvent.MouseButton;
                }
                else if (baseEvent is MouseMoveEvent mouseMoveEvent)
                {
                    SetVisibleEventPanel(EventType.MouseMoveEvent);
                }
                else if (baseEvent is WaitEvent waitEvent)
                {
                    SetVisibleEventPanel(EventType.WaitEvent);
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
                        ClickLocation = locationPickerClickEvent.Point,
                    });
                    break;
                case EventType.MouseMoveEvent:
                    ResultEventAction?.Invoke(new MouseMoveEvent
                    {
                        StartLocation = locationPickerStartLocation.Point,
                        EndLocation = locationPickerEndLocation.Point,
                    });
                    break;
                case EventType.WaitEvent:
                    ResultEventAction?.Invoke(new WaitEvent
                    {
                        WaitDuration = TimeSpan.FromMilliseconds((double)numericUpDownDurationMs.Value),
                    });
                    break;
            }

            this.Close();
        }
    }
}
