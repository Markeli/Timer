namespace timer
{
    partial class Window2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window2));
            this.currentSpeakerLabel = new System.Windows.Forms.Label();
            this.timerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // currentSpeakerLabel
            // 
            this.currentSpeakerLabel.AutoSize = true;
            this.currentSpeakerLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.currentSpeakerLabel.Font = new System.Drawing.Font("Calibri", 90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentSpeakerLabel.Location = new System.Drawing.Point(-23, 80);
            this.currentSpeakerLabel.Name = "currentSpeakerLabel";
            this.currentSpeakerLabel.Size = new System.Drawing.Size(0, 146);
            this.currentSpeakerLabel.TabIndex = 38;
            this.currentSpeakerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.currentSpeakerLabel.TextChanged += new System.EventHandler(this.CurrentSpeakerLabelTextChanged);
            this.currentSpeakerLabel.DoubleClick += new System.EventHandler(this.CurrentSpeakerLabelDoubleClick);
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.timerLabel.Font = new System.Drawing.Font("Calibri", 90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timerLabel.Location = new System.Drawing.Point(350, 63);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(331, 146);
            this.timerLabel.TabIndex = 39;
            this.timerLabel.Text = "0 : 00";
            this.timerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.timerLabel.TextChanged += new System.EventHandler(this.TimerLabelTextChanged);
            this.timerLabel.DoubleClick += new System.EventHandler(this.TimerLabelDoubleClick);
            // 
            // Window2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(722, 272);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.currentSpeakerLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Window2";
            this.ShowInTaskbar = false;
            this.Text = "Окно 2";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Window2Load);
            this.Shown += new System.EventHandler(this.Window2_Shown);
            this.DoubleClick += new System.EventHandler(this.Window2_DoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label currentSpeakerLabel;
        private System.Windows.Forms.Label timerLabel;

    }
}