using System;
using System.Drawing;
using System.Windows.Forms;

namespace Timer.InformationWindows
{
    /// <summary>
    /// Окно таймера, которое появляется внизу экрана
    /// </summary>
    public partial class BottomWindow : Form
    {
        /// <summary>
        /// Окно таймера, которое появляется внизу экрана
        /// </summary>
        public BottomWindow()
        {
            InitializeComponent();
        }

        private void BottomWindowLoad(object sender, EventArgs e)
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

        /// <summary>
        /// Корректирует положение надписи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FixLabelPosition(object sender, EventArgs e)
        {
            timerLabel.Left = Width - 15 - timerLabel.Width;
        }

        private void Window2_Shown(object sender, EventArgs e)
        {
            FixLabelPosition(this, null);
        }
    }
}
