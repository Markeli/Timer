namespace timer
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.openSoundButton = new System.Windows.Forms.Button();
            this.signalNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.loadLastOpenedListOnStartCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelButton.ForeColor = System.Drawing.Color.Black;
            this.cancelButton.Location = new System.Drawing.Point(240, 156);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 18;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.СancelButtonClick);
            // 
            // okButton
            // 
            this.okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.okButton.ForeColor = System.Drawing.Color.Black;
            this.okButton.Location = new System.Drawing.Point(90, 156);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 17;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // openSoundButton
            // 
            this.openSoundButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.openSoundButton.ForeColor = System.Drawing.Color.Black;
            this.openSoundButton.Location = new System.Drawing.Point(311, 53);
            this.openSoundButton.Name = "openSoundButton";
            this.openSoundButton.Size = new System.Drawing.Size(70, 23);
            this.openSoundButton.TabIndex = 19;
            this.openSoundButton.Text = "Изменить";
            this.openSoundButton.UseVisualStyleBackColor = true;
            this.openSoundButton.Click += new System.EventHandler(this.OpenSoundButtonClick);
            // 
            // signalNameLabel
            // 
            this.signalNameLabel.BackColor = System.Drawing.Color.White;
            this.signalNameLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.signalNameLabel.Location = new System.Drawing.Point(19, 55);
            this.signalNameLabel.Name = "signalNameLabel";
            this.signalNameLabel.Size = new System.Drawing.Size(274, 19);
            this.signalNameLabel.TabIndex = 23;
            this.signalNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 19);
            this.label1.TabIndex = 24;
            this.label1.Text = "Сигнал:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "wav файл|*.wav";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1FileOk);
            // 
            // loadLastOpenedListOnStartCheckBox
            // 
            this.loadLastOpenedListOnStartCheckBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.loadLastOpenedListOnStartCheckBox.Checked = true;
            this.loadLastOpenedListOnStartCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.loadLastOpenedListOnStartCheckBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadLastOpenedListOnStartCheckBox.Location = new System.Drawing.Point(16, 101);
            this.loadLastOpenedListOnStartCheckBox.Name = "loadLastOpenedListOnStartCheckBox";
            this.loadLastOpenedListOnStartCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.loadLastOpenedListOnStartCheckBox.Size = new System.Drawing.Size(339, 49);
            this.loadLastOpenedListOnStartCheckBox.TabIndex = 42;
            this.loadLastOpenedListOnStartCheckBox.Text = "Загружать последний открытый список при старте программы";
            this.loadLastOpenedListOnStartCheckBox.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.loadLastOpenedListOnStartCheckBox.UseVisualStyleBackColor = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(404, 197);
            this.Controls.Add(this.loadLastOpenedListOnStartCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.signalNameLabel);
            this.Controls.Add(this.openSoundButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.SettingsFormLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        public System.Windows.Forms.Button okButton;
        public System.Windows.Forms.Button openSoundButton;
        private System.Windows.Forms.Label signalNameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox loadLastOpenedListOnStartCheckBox;
    }
}