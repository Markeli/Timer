namespace Timer.InformationWindows
{
    partial class FullScreenWindow
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FullScreenWindow));
            this.timerLabel = new System.Windows.Forms.Label();
            this.currentTimeLabel = new System.Windows.Forms.Label();
            this.separatorPictureBox = new System.Windows.Forms.PictureBox();
            this.warningLabel = new System.Windows.Forms.Label();
            this.warningTimer = new System.Windows.Forms.Timer(this.components);
            this.repeatTimer = new System.Windows.Forms.Timer(this.components);
            this.LabelPositionTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.separatorPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.timerLabel.Font = new System.Drawing.Font("Calibri", 90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timerLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.timerLabel.Location = new System.Drawing.Point(193, 60);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(331, 146);
            this.timerLabel.TabIndex = 37;
            this.timerLabel.Text = "0 : 00";
            this.timerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.timerLabel.TextChanged += new System.EventHandler(this.FixLabelsText);
            this.timerLabel.DoubleClick += new System.EventHandler(this.TimerLabelDoubleClick);
            // 
            // currentTimeLabel
            // 
            this.currentTimeLabel.AutoSize = true;
            this.currentTimeLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.currentTimeLabel.Font = new System.Drawing.Font("Calibri", 90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentTimeLabel.Location = new System.Drawing.Point(193, 244);
            this.currentTimeLabel.Name = "currentTimeLabel";
            this.currentTimeLabel.Size = new System.Drawing.Size(392, 146);
            this.currentTimeLabel.TabIndex = 38;
            this.currentTimeLabel.Text = "00 : 00";
            this.currentTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.currentTimeLabel.TextChanged += new System.EventHandler(this.FixLabelsText);
            this.currentTimeLabel.DoubleClick += new System.EventHandler(this.CurrentTimeLabelDoubleClick);
            // 
            // separatorPictureBox
            // 
            this.separatorPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("separatorPictureBox.Image")));
            this.separatorPictureBox.Location = new System.Drawing.Point(218, 209);
            this.separatorPictureBox.Name = "separatorPictureBox";
            this.separatorPictureBox.Size = new System.Drawing.Size(297, 15);
            this.separatorPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.separatorPictureBox.TabIndex = 39;
            this.separatorPictureBox.TabStop = false;
            this.separatorPictureBox.DoubleClick += new System.EventHandler(this.SeparatorPictureBoxDoubleClick);
            // 
            // warningLabel
            // 
            this.warningLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.warningLabel.Location = new System.Drawing.Point(34, 36);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(610, 152);
            this.warningLabel.TabIndex = 40;
            this.warningLabel.DoubleClick += new System.EventHandler(this.WarningLabelDoubleClick);
            // 
            // warningTimer
            // 
            this.warningTimer.Interval = 1000;
            this.warningTimer.Tick += new System.EventHandler(this.WarningTimerTick);
            // 
            // repeatTimer
            // 
            this.repeatTimer.Interval = 1000;
            this.repeatTimer.Tick += new System.EventHandler(this.RepeatTimerTick);
            // 
            // LabelPositionTimer
            // 
            this.LabelPositionTimer.Enabled = true;
            this.LabelPositionTimer.Interval = 1;
            this.LabelPositionTimer.Tick += new System.EventHandler(this.LabelPositionTimer_Tick);
            // 
            // FullScreenWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(680, 395);
            this.Controls.Add(this.separatorPictureBox);
            this.Controls.Add(this.currentTimeLabel);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.warningLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FullScreenWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " Окно 1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FullScrennWindowLoad);
            this.DoubleClick += new System.EventHandler(this.FullScrennWindowDoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.separatorPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox separatorPictureBox;
        public System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.Timer warningTimer;
        private System.Windows.Forms.Timer repeatTimer;
        private System.Windows.Forms.Label currentTimeLabel;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Timer LabelPositionTimer;
    }
}