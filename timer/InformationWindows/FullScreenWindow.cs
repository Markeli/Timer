using System;
using System.Drawing;
using System.Windows.Forms;

namespace Timer.InformationWindows
{
    /// <summary>
    /// Полноэкранное окно для отображения оставшегося времени
    /// </summary>
    public partial class FullScreenWindow : Form
    {
        public readonly string TimeIsOverLabel = "ВРЕМЯ\nИСТЕКЛО";

        double _factor;
        bool _isMaximised;

        private new int Width
        {
            get { return Size.Width; }
        }

        private int CenterX
        {
            get { return Size.Width/2; }
        }

        private new int Height
        {
            get { return Size.Height; }
        }

        private int CenterY
        {
            get {return Size.Height / 2;}
        }


        private int FontSizePoints
        {
            get { return Convert.ToInt32(_factor*90*CenterY/193); }
        }

        /// <summary>
        /// Полноэкранное окно для отображения оставшегося времени
        /// </summary>
        public FullScreenWindow()
        {
            _factor = 1;
            _isMaximised = false;
            InitializeComponent();
            RefreshSeparator();
        }

        private void FullScrennWindowLoad(object sender, EventArgs e)
        {
            FullRefresh();
        }
        
        /// <summary>
        /// Обрабатывает двойной щелчок мышью по форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Переключается из полноэкранного режима в обычный и наоборот</remarks>
        public void FullScrennWindowDoubleClick(object sender, EventArgs e)
        {
            if (!_isMaximised)
            {
                _isMaximised = true;
                WindowState = FormWindowState.Maximized;
                FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                _isMaximised = false;
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.FixedToolWindow;
            }
            RefreshSeparator();
            RefreshWarningBackground();
            RefreshLabels();
        }

        /// <summary>
        /// Обновление положений надписей, разделителя и фона предупреждающей надписи
        /// </summary>
        private void FullRefresh(object sender, EventArgs args)
        {
            FullRefresh();
        }

        /// <summary>
        /// Обновление положений надписей, разделителя и фона предупреждающей надписи
        /// </summary>
        private void FullRefresh()
        {
            RefreshLabels();
            RefreshSeparator();
            RefreshWarningBackground();
        }

        /// <summary>
        /// Обновление положения разделителя
        /// </summary>
        private void RefreshSeparator()
        {
            separatorPictureBox.Top = CenterY - separatorPictureBox.Size.Height / 2;
            separatorPictureBox.Width = Width - 40;
            separatorPictureBox.Left = CenterX - separatorPictureBox.Width / 2;
        }

        /// <summary>
        /// Обновляет положение фона предупреждающей надписи
        /// </summary>
        private void RefreshWarningBackground()
        {
            warningLabel.Left = 0;
            warningLabel.Width = Width;
            warningLabel.Top = 0;
            warningLabel.Height = (currentTimeLabel.Visible) ? CenterY - separatorPictureBox.Height / 2 : Height;
        }

        /// <summary>
        /// Обновляет положение надписей и размера шрифта
        /// </summary>
        private void RefreshLabels()
        {
            currentTimeLabel.Left = (CenterX - currentTimeLabel.Size.Width / 2);
            currentTimeLabel.Top = CenterY + CenterY / 2 - currentTimeLabel.Height / 2 - separatorPictureBox.Height/2;
            currentTimeLabel.Font = new Font("Calibri", FontSizePoints);

            timerLabel.Left = (CenterX - timerLabel.Size.Width / 2);
            timerLabel.Top = (currentTimeLabel.Visible)
                ? (CenterY - timerLabel.Size.Height - separatorPictureBox.Height) / 2
                : timerLabel.Top = CenterY - timerLabel.Size.Height / 2;
            timerLabel.Font = timerLabel.Text == TimeIsOverLabel ? new Font("Calibri", FontSizePoints - FontSizePoints / 3) : new Font("Calibri", FontSizePoints);
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
        
        /// <summary>
        /// Возвращает статус видимости окна
        /// </summary>
        public bool CurrentTimeLabelVisible
        {
            get { return currentTimeLabel.Visible; }
        }

        /// <summary>
        /// Показывает текущее время
        /// </summary>
        public void ShowCurrentTimeLabel()
        {
            currentTimeLabel.Visible = true;
            separatorPictureBox.Visible = true;
            _factor = 1;
            FullRefresh();
        }

        /// <summary>
        /// Скрывает текущее время
        /// </summary>
        public void HideCurrentTimeLabel()
        {
            currentTimeLabel.Visible = false;
            separatorPictureBox.Visible = false;
            _factor = 1.50;
            FullRefresh();
        }

        /// <summary>
        /// Запускает предупредительный таймер
        /// </summary>
        /// <remarks>Тот, который срабатывает за n секунд до конца выступления </remarks>
        public void StartWarningTimer()
        {
            if (!warningTimer.Enabled) { warningTimer.Start(); }
        }

        /// <summary>
        /// Останавливает предупредительный таймер
        /// </summary>
        /// <remarks>Тот, который срабатывает за n секунд до конца выступления </remarks>
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

        /// <summary>
        /// Устанавливает стандартный цвет текстам
        /// </summary>
        public void SetDefaultColorToLabels()
        {
            warningLabel.BackColor = SystemColors.ControlLight;
            timerLabel.BackColor = SystemColors.ControlLight;
            timerLabel.ForeColor = Color.Black;
        }

        /// <summary>
        /// Устаналивает предупредительную надпись в качестве текста 
        /// </summary>
        public void SetWarningTextToLabel()
        {
            SetDefaultColorToLabels();
            timerLabel.ForeColor = Color.Black;
            warningLabel.BackColor = Color.Red;
            timerLabel.BackColor = Color.Red;
            timerLabel.Text = TimeIsOverLabel;
            FullRefresh();
        }
        
        /// <summary>
        /// Устаналивает стандартную надпись в качестве текста 
        /// </summary>
        public void SetDefaultTextToLabels()
        {
            timerLabel.Text = "0 : 00";
            FullRefresh();
        }

        /// <summary>
        /// Запускает таймер повторения
        /// </summary>
        public void StartRepeatTimer()
        {
            if (!repeatTimer.Enabled) { repeatTimer.Start(); }
        }

        /// <summary>
        /// Останавливает таймер повторения
        /// </summary>
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
            FullRefresh();
        }
    }
}
