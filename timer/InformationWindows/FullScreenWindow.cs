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
        int _width, _height, _widthCenter, _heightCenter, _sizePoints;
        double _factor;
        bool _isMaximised;

        /// <summary>
        /// Полноэкранное окно для отображения оставшегося времени
        /// </summary>
        public FullScreenWindow()
        {
            _factor = 1;
            InitializeComponent();
            _isMaximised = false;
        }

        private void FullScrennWindowLoad(object sender, EventArgs e)
        {
            _width = Size.Width;
            _height = Size.Height;
            _widthCenter = _width / 2;
            _heightCenter = _height / 2;
            separatorPictureBox.Top = _heightCenter - separatorPictureBox.Size.Height / 2;
            separatorPictureBox.Width = _width - 40;
            separatorPictureBox.Left = _widthCenter - separatorPictureBox.Width / 2;
            _sizePoints = GetSizePoints();
            timerLabel.Font = new Font("Calibri", _sizePoints);
            timerLabel.Left = _widthCenter - timerLabel.Size.Width / 2;
            timerLabel.Top = _heightCenter - timerLabel.Size.Height  - 30;
            currentTimeLabel.Font = new Font("Calibri", _sizePoints);
            currentTimeLabel.Left = _widthCenter - currentTimeLabel.Size.Width / 2;
            currentTimeLabel.Top = _heightCenter + 30;
            warningLabel.Left = 0;
            warningLabel.Width = _width;
            warningLabel.Top = 0;
            warningLabel.Height = _heightCenter - 15;
        }

        private int GetSizePoints()
        {
            return Convert.ToInt32(_factor * 90 * _heightCenter / 193);
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
                _width = Size.Width;
                _height = Size.Height;
                _widthCenter = _width / 2;
                _heightCenter = _height / 2;
                separatorPictureBox.Top = _heightCenter - separatorPictureBox.Size.Height / 2;
                separatorPictureBox.Width = _width - 40;
                separatorPictureBox.Left = _widthCenter - separatorPictureBox.Width / 2;
                _sizePoints = GetSizePoints();
                timerLabel.Font = timerLabel.Text == "ВРЕМЯ ИСТЕКЛО!" ? new Font("Calibri", _sizePoints - _sizePoints/3) : new Font("Calibri", _sizePoints);
                timerLabel.Left = _widthCenter - timerLabel.Size.Width / 2;
                timerLabel.Top = _heightCenter - timerLabel.Size.Height - 65;
                currentTimeLabel.Font = new Font("Calibri", _sizePoints);
                currentTimeLabel.Left = _widthCenter - currentTimeLabel.Size.Width / 2;
                currentTimeLabel.Top = _heightCenter + 65;
                warningLabel.Left = 0;
                warningLabel.Width = _width;
                warningLabel.Top = 0;
                warningLabel.Height = _heightCenter - 15;
                warningLabel.Height = (currentTimeLabel.Visible) ? _heightCenter - 15 : _height;
            }
            else
            {
                _isMaximised = false;
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.FixedToolWindow;
                _width = Size.Width;
                _height = Size.Height;
                _widthCenter = _width / 2;
                _heightCenter = _height / 2;
                separatorPictureBox.Top = _heightCenter - separatorPictureBox.Size.Height / 2;
                separatorPictureBox.Width = _width - 40;
                separatorPictureBox.Left = _widthCenter - separatorPictureBox.Width / 2;
                _sizePoints = GetSizePoints();
                timerLabel.Font = timerLabel.Text == "ВРЕМЯ ИСТЕКЛО!" ? new Font("Calibri", _sizePoints - _sizePoints / 4) : new Font("Calibri", _sizePoints);
                timerLabel.Left = _widthCenter - timerLabel.Size.Width / 2;
                timerLabel.Top = _heightCenter - timerLabel.Size.Height - 30;
                currentTimeLabel.Font = new Font("Calibri", _sizePoints);
                currentTimeLabel.Left = _widthCenter - currentTimeLabel.Size.Width / 2;
                currentTimeLabel.Top = _heightCenter + 30;
                warningLabel.Left = 0;
                warningLabel.Width = _width;
                warningLabel.Top = 0;
                warningLabel.Height = (currentTimeLabel.Visible) ? _heightCenter - 15 : _height;
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

        /// <summary>
        /// Корректирует положения текста в лейблах 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FixLabelsText(object sender, EventArgs e)
        {
            if (_isMaximised)
            {
                timerLabel.Left = (_widthCenter - timerLabel.Size.Width / 2);
                //timerLabel.Top = heightCenter - timerLabel.Size.Height - 65;
                timerLabel.Top = (currentTimeLabel.Visible) ? _heightCenter - timerLabel.Size.Height - 65 : _heightCenter - timerLabel.Size.Height/2;
                currentTimeLabel.Left = (_widthCenter - currentTimeLabel.Size.Width / 2);
                currentTimeLabel.Top = _heightCenter + 65;
            }
            else
            {
                timerLabel.Left = (_widthCenter - timerLabel.Size.Width / 2);
                //timerLabel.Top = heightCenter - timerLabel.Size.Height - 30;
                timerLabel.Top = (currentTimeLabel.Visible) ? _heightCenter - timerLabel.Size.Height - 30 : _heightCenter - timerLabel.Size.Height / 2;
                currentTimeLabel.Left = (_widthCenter - currentTimeLabel.Size.Width / 2);
                currentTimeLabel.Top = _heightCenter + 30;
            }
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
            _sizePoints = GetSizePoints();
            timerLabel.Font = timerLabel.Text == "ВРЕМЯ ИСТЕКЛО!" ? new Font("Calibri", _sizePoints - _sizePoints / 3) : new Font("Calibri", _sizePoints);
            warningLabel.Height = (currentTimeLabel.Visible) ? _heightCenter - 15 : _height;
            FixLabelsText(null, null);
        }

        /// <summary>
        /// Скрывает текущее время
        /// </summary>
        public void HideCurrentTimeLabel()
        {
            currentTimeLabel.Visible = false;
            separatorPictureBox.Visible = false;
            _factor = 1.05;
            _sizePoints = GetSizePoints();
            timerLabel.Font = timerLabel.Text == "ВРЕМЯ ИСТЕКЛО!" ? new Font("Calibri", _sizePoints - _sizePoints / 3) : new Font("Calibri", _sizePoints);
            warningLabel.Height = (currentTimeLabel.Visible) ? _heightCenter - 15 : _height;
            FixLabelsText(null, null);
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
        }

        /// <summary>
        /// Устаналивает предупредительную надпись в качестве текста 
        /// </summary>
        public void SetWarningTextToLabel()
        {
            SetDefaultColorToLabels();
            timerLabel.ForeColor = Color.Red;
            timerLabel.Font = new Font("Calibri", _sizePoints - _sizePoints/3);
            timerLabel.Text = "ВРЕМЯ ИСТЕКЛО!";
        }

        /// <summary>
        /// Устаналивает стандартную надпись в качестве текста 
        /// </summary>
        public void SetUsualTextToLabels()
        {
            timerLabel.ForeColor = Color.Black;
            timerLabel.Text = "0 : 00";
            timerLabel.Font = currentTimeLabel.Font;
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
            if (_isMaximised)
            {
                timerLabel.Left = (_widthCenter - timerLabel.Size.Width / 2);
                timerLabel.Top = (currentTimeLabel.Visible) ? _heightCenter - timerLabel.Size.Height - 65 : _heightCenter - timerLabel.Size.Height / 2;
                currentTimeLabel.Left = (_widthCenter - currentTimeLabel.Size.Width / 2);
                currentTimeLabel.Top = _heightCenter + 65;
            }
            else
            {
                timerLabel.Left = (_widthCenter - timerLabel.Size.Width / 2);
                timerLabel.Top = (currentTimeLabel.Visible) ? _heightCenter - timerLabel.Size.Height - 30 : _heightCenter - timerLabel.Size.Height / 2;
                currentTimeLabel.Left = (_widthCenter - currentTimeLabel.Size.Width / 2);
                currentTimeLabel.Top = _heightCenter + 30;
            }
        }

    }
}
