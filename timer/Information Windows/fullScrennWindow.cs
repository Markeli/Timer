using System;
using System.Drawing;
using System.Windows.Forms;

namespace timer
{
    public partial class fullScrennWindow : Form
    {
        int width, height, widthCenter, heightCenter, sizePoints;
        double factor;
        bool isMaximised;

        public fullScrennWindow()
        {
            factor = 1;
            InitializeComponent();
            isMaximised = false;
        }

        private void FullScrennWindowLoad(object sender, EventArgs e)
        {
            width = this.Size.Width;
            height = this.Size.Height;
            widthCenter = width / 2;
            heightCenter = height / 2;
            separatorPictureBox.Top = heightCenter - separatorPictureBox.Size.Height / 2;
            separatorPictureBox.Width = width - 40;
            separatorPictureBox.Left = widthCenter - separatorPictureBox.Width / 2;
            sizePoints = GetSizePoints();
            timerLabel.Font = new System.Drawing.Font("Calibri", sizePoints);
            timerLabel.Left = widthCenter - timerLabel.Size.Width / 2;
            timerLabel.Top = heightCenter - timerLabel.Size.Height  - 30;
            currentTimeLabel.Font = new System.Drawing.Font("Calibri", sizePoints);
            currentTimeLabel.Left = widthCenter - currentTimeLabel.Size.Width / 2;
            currentTimeLabel.Top = heightCenter + 30;
            warningLabel.Left = 0;
            warningLabel.Width = width;
            warningLabel.Top = 0;
            warningLabel.Height = heightCenter - 15;
        }

        private int GetSizePoints()
        {
            return Convert.ToInt32(factor * 90 * heightCenter / 193);
        }

        public void FullScrennWindowDoubleClick(object sender, EventArgs e)
        {
            if (!isMaximised)
            {
                isMaximised = true;
                WindowState = FormWindowState.Maximized;
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                width = this.Size.Width;
                height = this.Size.Height;
                widthCenter = width / 2;
                heightCenter = height / 2;
                separatorPictureBox.Top = heightCenter - separatorPictureBox.Size.Height / 2;
                separatorPictureBox.Width = width - 40;
                separatorPictureBox.Left = widthCenter - separatorPictureBox.Width / 2;
                sizePoints = GetSizePoints();
                if (timerLabel.Text == "ВРЕМЯ ИСТЕКЛО!")
                {
                    timerLabel.Font = new System.Drawing.Font("Calibri", sizePoints - sizePoints/3);
                }
                else
                {
                    timerLabel.Font = new System.Drawing.Font("Calibri", sizePoints);
                }
                timerLabel.Left = widthCenter - timerLabel.Size.Width / 2;
                timerLabel.Top = heightCenter - timerLabel.Size.Height - 65;
                currentTimeLabel.Font = new System.Drawing.Font("Calibri", sizePoints);
                currentTimeLabel.Left = widthCenter - currentTimeLabel.Size.Width / 2;
                currentTimeLabel.Top = heightCenter + 65;
                warningLabel.Left = 0;
                warningLabel.Width = width;
                warningLabel.Top = 0;
                warningLabel.Height = heightCenter - 15;
            }
            else
            {
                isMaximised = false;
                WindowState = FormWindowState.Normal;
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                width = this.Size.Width;
                height = this.Size.Height;
                widthCenter = width / 2;
                heightCenter = height / 2;
                separatorPictureBox.Top = heightCenter - separatorPictureBox.Size.Height / 2;
                separatorPictureBox.Width = width - 40;
                separatorPictureBox.Left = widthCenter - separatorPictureBox.Width / 2;
                sizePoints = GetSizePoints();
                if (timerLabel.Text == "ВРЕМЯ ИСТЕКЛО!")
                {
                    timerLabel.Font = new System.Drawing.Font("Calibri", sizePoints - sizePoints / 4);
                }
                else
                {
                    timerLabel.Font = new System.Drawing.Font("Calibri", sizePoints);
                }
                timerLabel.Left = widthCenter - timerLabel.Size.Width / 2;
                timerLabel.Top = heightCenter - timerLabel.Size.Height - 30;
                currentTimeLabel.Font = new System.Drawing.Font("Calibri", sizePoints);
                currentTimeLabel.Left = widthCenter - currentTimeLabel.Size.Width / 2;
                currentTimeLabel.Top = heightCenter + 30;
                warningLabel.Left = 0;
                warningLabel.Width = width;
                warningLabel.Top = 0;
                warningLabel.Height = heightCenter - 15;
            }
        }

        private void TimerLabelDoubleClick(object sender, EventArgs e)
        {
            FullScrennWindowDoubleClick(this, null);
        }

        private void SeparatorPictureBoxDoubleClick(object sender, EventArgs e)
        {
            FullScrennWindowDoubleClick(this, null);
        }

        private void CurrentTimeLabelDoubleClick(object sender, EventArgs e)
        {
            FullScrennWindowDoubleClick(this, null);
        }

        private void WarningLabelDoubleClick(object sender, EventArgs e)
        {
            FullScrennWindowDoubleClick(this, null);
        }

        public void UpdateTimerLabelText(string labelsTime)
        {
            timerLabel.Text = labelsTime;
        }

        public void UpdateCurrentTimeLabelsText(string labelsTime)
        {
            currentTimeLabel.Text = labelsTime;
        }

        private void LabelsTextChanged(object sender, EventArgs e)
        {
            if (isMaximised)
            {
                timerLabel.Left = (widthCenter - timerLabel.Size.Width / 2);
                //timerLabel.Top = heightCenter - timerLabel.Size.Height - 65;
                timerLabel.Top = (currentTimeLabel.Visible) ? heightCenter - timerLabel.Size.Height - 65 : heightCenter - timerLabel.Size.Height/2;
                currentTimeLabel.Left = (widthCenter - currentTimeLabel.Size.Width / 2);
                currentTimeLabel.Top = heightCenter + 65;
            }
            else
            {
                timerLabel.Left = (widthCenter - timerLabel.Size.Width / 2);
                //timerLabel.Top = heightCenter - timerLabel.Size.Height - 30;
                timerLabel.Top = (currentTimeLabel.Visible) ? heightCenter - timerLabel.Size.Height - 30 : heightCenter - timerLabel.Size.Height / 2;
                currentTimeLabel.Left = (widthCenter - currentTimeLabel.Size.Width / 2);
                currentTimeLabel.Top = heightCenter + 30;
            }
        }

        public bool CurrentTimeLabelVisible
        {
            get { return currentTimeLabel.Visible; }
        }

        public void ShowCurrentTimeLabel()
        {
            currentTimeLabel.Visible = true;
            separatorPictureBox.Visible = true;
            factor = 1;
            sizePoints = GetSizePoints();
            if (timerLabel.Text == "ВРЕМЯ ИСТЕКЛО!")
            {
                timerLabel.Font = new System.Drawing.Font("Calibri", sizePoints - sizePoints / 3);
            }
            else
            {
                timerLabel.Font = new System.Drawing.Font("Calibri", sizePoints);
            }
            LabelsTextChanged(null, null);
        }

        public void HideCurrentTimeLabel()
        {
            currentTimeLabel.Visible = false;
            separatorPictureBox.Visible = false;
            factor = 1.25;
            sizePoints = GetSizePoints();
            if (timerLabel.Text == "ВРЕМЯ ИСТЕКЛО!")
            {
                timerLabel.Font = new System.Drawing.Font("Calibri", sizePoints - sizePoints / 3);
            }
            else
            {
                timerLabel.Font = new System.Drawing.Font("Calibri", sizePoints);
            }
            LabelsTextChanged(null, null);
        }

        public void StartWarningTimer()
        {
            if (!warningTimer.Enabled) { warningTimer.Start(); }
        }

        public void StopWarningTimer()
        {
            if (warningTimer.Enabled) { warningTimer.Stop(); }
        }

        private void WarningTimerTick(object sender, EventArgs e)
        {
            if (warningLabel.BackColor == SystemColors.ControlLight)
            {
                warningLabel.BackColor = Color.Yellow;
                timerLabel.BackColor = Color.Yellow;
            }
            else
            {
                warningLabel.BackColor = SystemColors.ControlLight;
                timerLabel.BackColor = SystemColors.ControlLight;
            }
        }

        public void SetDefaultColorToLabels()
        {
            warningLabel.BackColor = SystemColors.ControlLight;
            timerLabel.BackColor = SystemColors.ControlLight;
        }

        public void SetWarningTextToLabel()
        {
            SetDefaultColorToLabels();
            timerLabel.ForeColor = Color.Red;
            timerLabel.Font = new System.Drawing.Font("Calibri", sizePoints - sizePoints/3);
            timerLabel.Text = "ВРЕМЯ ИСТЕКЛО!";
        }

        public  void SetUsualTextToLabels()
        {
            timerLabel.ForeColor = Color.Black;
            timerLabel.Text = "0 : 00";
            timerLabel.Font = currentTimeLabel.Font;
        }

        public void StartRepeatTimer()
        {
            if (!repeatTimer.Enabled) { repeatTimer.Start(); }
        }

        public void StopRepeatTimer()
        {
            if (repeatTimer.Enabled) { repeatTimer.Stop(); }
        }

        private void RepeatTimerTick(object sender, EventArgs e)
        {
            if (warningLabel.BackColor == SystemColors.ControlLight)
            {
                warningLabel.BackColor = Color.Red;
                timerLabel.BackColor = Color.Red;
            }
            else
            {
                warningLabel.BackColor = SystemColors.ControlLight;
                timerLabel.BackColor = SystemColors.ControlLight;
            }
        }

        private void LabelPositionTimer_Tick(object sender, EventArgs e)
        {
            if (isMaximised)
            {
                timerLabel.Left = (widthCenter - timerLabel.Size.Width / 2);
                timerLabel.Top = (currentTimeLabel.Visible) ? heightCenter - timerLabel.Size.Height - 65 : heightCenter - timerLabel.Size.Height / 2;
                currentTimeLabel.Left = (widthCenter - currentTimeLabel.Size.Width / 2);
                currentTimeLabel.Top = heightCenter + 65;
            }
            else
            {
                timerLabel.Left = (widthCenter - timerLabel.Size.Width / 2);
                timerLabel.Top = (currentTimeLabel.Visible) ? heightCenter - timerLabel.Size.Height - 30 : heightCenter - timerLabel.Size.Height / 2;
                currentTimeLabel.Left = (widthCenter - currentTimeLabel.Size.Width / 2);
                currentTimeLabel.Top = heightCenter + 30;
            }
        }

    }
}
