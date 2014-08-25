using System;
using System.Drawing;
using System.Windows.Forms;

namespace timer
{
    public partial class Window2 : Form
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Window2Load(object sender, EventArgs e)
        {
            Height = 150;
            Width = Screen.AllScreens[0].Bounds.Width;
            Left = Screen.AllScreens[0].Bounds.Left;
            Top = Screen.AllScreens[0].Bounds.Height - Height;
            int heightCenter = Height / 2;
            currentSpeakerLabel.Top = heightCenter - currentSpeakerLabel.Height / 2;
            currentSpeakerLabel.Left = Left + 15;
            timerLabel.Top = currentSpeakerLabel.Top;
            timerLabel.Left = Width - 15 - timerLabel.Width;
        }

        private void Window2_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }

        private void TimerLabelDoubleClick(object sender, EventArgs e)
        {
            Close();
        }

        private void CurrentSpeakerLabelDoubleClick(object sender, EventArgs e)
        {
            Close();
        }

        public void UpdateLabelsText(string currenrSpeakersName, string time)
        {
            currentSpeakerLabel.Text = currenrSpeakersName;
            timerLabel.Text = time;
        }

        private void CurrentSpeakerLabelTextChanged(object sender, EventArgs e)
        {
            currentSpeakerLabel.Top = Height / 2 - currentSpeakerLabel.Height / 2;
            currentSpeakerLabel.Left = Left + 15;
            currentSpeakerLabel.Font = new Font("Calibri", 90);
            currentSpeakerLabel.Text = currentSpeakerLabel.Text.ToUpper();
            while (currentSpeakerLabel.Width > Width - 35 - timerLabel.Width)
            {
                currentSpeakerLabel.Font = new Font("Calibri", currentSpeakerLabel.Font.SizeInPoints-5);
                currentSpeakerLabel.Top = Height / 2 - currentSpeakerLabel.Height / 2;
                currentSpeakerLabel.Left = Left + 15;
            }
        }

        public  void TimerLabelTextChanged(object sender, EventArgs e)
        {
            timerLabel.Left = Width - 15 - timerLabel.Width;
        }

        private void Window2_Shown(object sender, EventArgs e)
        {
            TimerLabelTextChanged(this, null);
        }
    }
}
