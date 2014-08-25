namespace timer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.speakersGrid = new System.Windows.Forms.DataGridView();
            this.numberOfSpeaker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameOfSpeaker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perfoemance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contorlsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSpeakerButton = new System.Windows.Forms.Button();
            this.deleteSpeakerButton = new System.Windows.Forms.Button();
            this.upSpeakerButton = new System.Windows.Forms.Button();
            this.downSpeakerButton = new System.Windows.Forms.Button();
            this.editSpeakerButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.mscTimeLabel = new System.Windows.Forms.Label();
            this.currentSpeakersPerfermanceLabel = new System.Windows.Forms.Label();
            this.currentSpeakersNameLabel = new System.Windows.Forms.Label();
            this.startTimersButton = new System.Windows.Forms.Button();
            this.stopTimerButton = new System.Windows.Forms.Button();
            this.addRaminingTimeButton = new System.Windows.Forms.Button();
            this.windows1StateButton = new System.Windows.Forms.Button();
            this.lowPanelStateButton = new System.Windows.Forms.Button();
            this.window2StateButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.updateCurrentTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.currentSpeakerInfoLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.remainingTimeInfoLabel = new System.Windows.Forms.Label();
            this.overTimeLabel = new System.Windows.Forms.Label();
            this.startButtonImageList = new System.Windows.Forms.ImageList(this.components);
            this.remainingTimeStatusLabel = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.window1Label = new System.Windows.Forms.Label();
            this.window2Label = new System.Windows.Forms.Label();
            this.window1CurrentTimeLabel = new System.Windows.Forms.Label();
            this.showHideButtonsImageList = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.waringTimeLabel = new System.Windows.Forms.Label();
            this.repeatSignalTimeLabel = new System.Windows.Forms.Label();
            this.premmisionToRepeatCheckBox = new System.Windows.Forms.CheckBox();
            this.premimisionToSoundCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.generalTimer = new System.Windows.Forms.Timer(this.components);
            this.waitingTimer = new System.Windows.Forms.Timer(this.components);
            this.repeatedTimer = new System.Windows.Forms.Timer(this.components);
            this.warningTimeSecondComboBox = new System.Windows.Forms.ComboBox();
            this.repeatTimeSecondComboBox = new System.Windows.Forms.ComboBox();
            this.warningTimeMinuteComboBox = new System.Windows.Forms.ComboBox();
            this.repeatTimeMinuteComboBox = new System.Windows.Forms.ComboBox();
            this.overtimeComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.speakersGrid)).BeginInit();
            this.contorlsMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // speakersGrid
            // 
            this.speakersGrid.AllowUserToAddRows = false;
            this.speakersGrid.AllowUserToDeleteRows = false;
            this.speakersGrid.AllowUserToResizeColumns = false;
            this.speakersGrid.AllowUserToResizeRows = false;
            this.speakersGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speakersGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.speakersGrid.CausesValidation = false;
            this.speakersGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.speakersGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.speakersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.speakersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numberOfSpeaker,
            this.nameOfSpeaker,
            this.perfoemance});
            this.speakersGrid.ContextMenuStrip = this.contorlsMenu;
            this.speakersGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.speakersGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.speakersGrid.Location = new System.Drawing.Point(471, 25);
            this.speakersGrid.MultiSelect = false;
            this.speakersGrid.Name = "speakersGrid";
            this.speakersGrid.ReadOnly = true;
            this.speakersGrid.RowHeadersVisible = false;
            this.speakersGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.speakersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.speakersGrid.Size = new System.Drawing.Size(444, 578);
            this.speakersGrid.TabIndex = 1;
            this.speakersGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SpeakersGridCellClick);
            this.speakersGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SpeakersGridCellDoubleClick);
            this.speakersGrid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.SpeakersGridCellMouseEnter);
            this.speakersGrid.SelectionChanged += new System.EventHandler(this.SpeakersGridSelectionChanged);
            this.speakersGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SpeakersGridKeyDown);
            // 
            // numberOfSpeaker
            // 
            this.numberOfSpeaker.HeaderText = "№";
            this.numberOfSpeaker.Name = "numberOfSpeaker";
            this.numberOfSpeaker.ReadOnly = true;
            this.numberOfSpeaker.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.numberOfSpeaker.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.numberOfSpeaker.Width = 35;
            // 
            // nameOfSpeaker
            // 
            this.nameOfSpeaker.HeaderText = "ФИО";
            this.nameOfSpeaker.MinimumWidth = 100;
            this.nameOfSpeaker.Name = "nameOfSpeaker";
            this.nameOfSpeaker.ReadOnly = true;
            this.nameOfSpeaker.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nameOfSpeaker.Width = 265;
            // 
            // perfoemance
            // 
            this.perfoemance.HeaderText = "Время выступления (мин)";
            this.perfoemance.MinimumWidth = 35;
            this.perfoemance.Name = "perfoemance";
            this.perfoemance.ReadOnly = true;
            this.perfoemance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.perfoemance.Width = 140;
            // 
            // contorlsMenu
            // 
            this.contorlsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contorlsMenu.Name = "contextMenuStrip1";
            this.contorlsMenu.Size = new System.Drawing.Size(129, 70);
            this.contorlsMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ContorlsMenuOpening);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addToolStripMenuItem.Image")));
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.addToolStripMenuItem.Text = "Добавить";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItemClick);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.editToolStripMenuItem.Text = "Изменить";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItemClick);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.deleteToolStripMenuItem.Text = "Удалить";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItemClick);
            // 
            // addSpeakerButton
            // 
            this.addSpeakerButton.Image = ((System.Drawing.Image)(resources.GetObject("addSpeakerButton.Image")));
            this.addSpeakerButton.Location = new System.Drawing.Point(499, 619);
            this.addSpeakerButton.Name = "addSpeakerButton";
            this.addSpeakerButton.Size = new System.Drawing.Size(40, 40);
            this.addSpeakerButton.TabIndex = 5;
            this.toolTip1.SetToolTip(this.addSpeakerButton, "Добавление нового участника в список");
            this.addSpeakerButton.UseVisualStyleBackColor = true;
            this.addSpeakerButton.Click += new System.EventHandler(this.AddSpeakerButtonClick);
            // 
            // deleteSpeakerButton
            // 
            this.deleteSpeakerButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteSpeakerButton.Image")));
            this.deleteSpeakerButton.Location = new System.Drawing.Point(610, 619);
            this.deleteSpeakerButton.Name = "deleteSpeakerButton";
            this.deleteSpeakerButton.Size = new System.Drawing.Size(40, 40);
            this.deleteSpeakerButton.TabIndex = 6;
            this.toolTip1.SetToolTip(this.deleteSpeakerButton, "Удалить участника из списка");
            this.deleteSpeakerButton.UseVisualStyleBackColor = true;
            this.deleteSpeakerButton.Click += new System.EventHandler(this.DeleteSpeakerButtonClick);
            // 
            // upSpeakerButton
            // 
            this.upSpeakerButton.Image = ((System.Drawing.Image)(resources.GetObject("upSpeakerButton.Image")));
            this.upSpeakerButton.Location = new System.Drawing.Point(665, 619);
            this.upSpeakerButton.Name = "upSpeakerButton";
            this.upSpeakerButton.Size = new System.Drawing.Size(40, 40);
            this.upSpeakerButton.TabIndex = 7;
            this.toolTip1.SetToolTip(this.upSpeakerButton, "Поднять участника в списке");
            this.upSpeakerButton.UseVisualStyleBackColor = true;
            this.upSpeakerButton.Click += new System.EventHandler(this.UpSpeakerButtonClick);
            // 
            // downSpeakerButton
            // 
            this.downSpeakerButton.Image = ((System.Drawing.Image)(resources.GetObject("downSpeakerButton.Image")));
            this.downSpeakerButton.Location = new System.Drawing.Point(722, 619);
            this.downSpeakerButton.Name = "downSpeakerButton";
            this.downSpeakerButton.Size = new System.Drawing.Size(40, 40);
            this.downSpeakerButton.TabIndex = 8;
            this.toolTip1.SetToolTip(this.downSpeakerButton, "Опустить участника в списке");
            this.downSpeakerButton.UseVisualStyleBackColor = true;
            this.downSpeakerButton.Click += new System.EventHandler(this.DownSpeakerButtonClick);
            // 
            // editSpeakerButton
            // 
            this.editSpeakerButton.Image = ((System.Drawing.Image)(resources.GetObject("editSpeakerButton.Image")));
            this.editSpeakerButton.Location = new System.Drawing.Point(555, 619);
            this.editSpeakerButton.Name = "editSpeakerButton";
            this.editSpeakerButton.Size = new System.Drawing.Size(40, 40);
            this.editSpeakerButton.TabIndex = 9;
            this.toolTip1.SetToolTip(this.editSpeakerButton, "Редактирование данных выбранного участника");
            this.editSpeakerButton.UseVisualStyleBackColor = true;
            this.editSpeakerButton.Click += new System.EventHandler(this.EditSpeakerButtonClick);
            // 
            // openButton
            // 
            this.openButton.Image = ((System.Drawing.Image)(resources.GetObject("openButton.Image")));
            this.openButton.Location = new System.Drawing.Point(784, 619);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(40, 40);
            this.openButton.TabIndex = 11;
            this.toolTip1.SetToolTip(this.openButton, "Загрузить список из файла");
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.OpenButtonClick);
            // 
            // saveButton
            // 
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.Location = new System.Drawing.Point(841, 619);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(40, 40);
            this.saveButton.TabIndex = 12;
            this.toolTip1.SetToolTip(this.saveButton, "Сохранить список в файл");
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // mscTimeLabel
            // 
            this.mscTimeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.mscTimeLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mscTimeLabel.Location = new System.Drawing.Point(67, 36);
            this.mscTimeLabel.Name = "mscTimeLabel";
            this.mscTimeLabel.Size = new System.Drawing.Size(306, 23);
            this.mscTimeLabel.TabIndex = 15;
            this.mscTimeLabel.Text = "Время МСК";
            this.mscTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.mscTimeLabel, "Время МСК");
            // 
            // currentSpeakersPerfermanceLabel
            // 
            this.currentSpeakersPerfermanceLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.currentSpeakersPerfermanceLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentSpeakersPerfermanceLabel.Location = new System.Drawing.Point(67, 125);
            this.currentSpeakersPerfermanceLabel.Name = "currentSpeakersPerfermanceLabel";
            this.currentSpeakersPerfermanceLabel.Size = new System.Drawing.Size(306, 19);
            this.currentSpeakersPerfermanceLabel.TabIndex = 16;
            this.currentSpeakersPerfermanceLabel.Text = "Время выступления";
            this.currentSpeakersPerfermanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.currentSpeakersPerfermanceLabel, "Время выступления текущего участника");
            // 
            // currentSpeakersNameLabel
            // 
            this.currentSpeakersNameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.currentSpeakersNameLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentSpeakersNameLabel.Location = new System.Drawing.Point(67, 96);
            this.currentSpeakersNameLabel.Name = "currentSpeakersNameLabel";
            this.currentSpeakersNameLabel.Size = new System.Drawing.Size(306, 19);
            this.currentSpeakersNameLabel.TabIndex = 17;
            this.currentSpeakersNameLabel.Text = "ФИО Текущего участника";
            this.currentSpeakersNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.currentSpeakersNameLabel, "ФИО Текущего участника");
            // 
            // startTimersButton
            // 
            this.startTimersButton.Image = ((System.Drawing.Image)(resources.GetObject("startTimersButton.Image")));
            this.startTimersButton.Location = new System.Drawing.Point(126, 243);
            this.startTimersButton.Name = "startTimersButton";
            this.startTimersButton.Size = new System.Drawing.Size(40, 40);
            this.startTimersButton.TabIndex = 23;
            this.toolTip1.SetToolTip(this.startTimersButton, "Запустить таймер");
            this.startTimersButton.UseVisualStyleBackColor = true;
            this.startTimersButton.Click += new System.EventHandler(this.StartTimersButtonClick);
            // 
            // stopTimerButton
            // 
            this.stopTimerButton.Image = ((System.Drawing.Image)(resources.GetObject("stopTimerButton.Image")));
            this.stopTimerButton.Location = new System.Drawing.Point(202, 243);
            this.stopTimerButton.Name = "stopTimerButton";
            this.stopTimerButton.Size = new System.Drawing.Size(40, 40);
            this.stopTimerButton.TabIndex = 24;
            this.toolTip1.SetToolTip(this.stopTimerButton, "Остановить таймер");
            this.stopTimerButton.UseVisualStyleBackColor = true;
            this.stopTimerButton.Click += new System.EventHandler(this.StopTimerButtonClick);
            // 
            // addRaminingTimeButton
            // 
            this.addRaminingTimeButton.Image = ((System.Drawing.Image)(resources.GetObject("addRaminingTimeButton.Image")));
            this.addRaminingTimeButton.Location = new System.Drawing.Point(278, 243);
            this.addRaminingTimeButton.Name = "addRaminingTimeButton";
            this.addRaminingTimeButton.Size = new System.Drawing.Size(40, 40);
            this.addRaminingTimeButton.TabIndex = 25;
            this.toolTip1.SetToolTip(this.addRaminingTimeButton, "Запустить дополнительное время");
            this.addRaminingTimeButton.UseVisualStyleBackColor = true;
            this.addRaminingTimeButton.Click += new System.EventHandler(this.AddRaminingTimeButtonClick);
            // 
            // windows1StateButton
            // 
            this.windows1StateButton.Image = ((System.Drawing.Image)(resources.GetObject("windows1StateButton.Image")));
            this.windows1StateButton.Location = new System.Drawing.Point(334, 318);
            this.windows1StateButton.Name = "windows1StateButton";
            this.windows1StateButton.Size = new System.Drawing.Size(40, 40);
            this.windows1StateButton.TabIndex = 32;
            this.toolTip1.SetToolTip(this.windows1StateButton, "Показать/скрыть Окно1");
            this.windows1StateButton.UseVisualStyleBackColor = true;
            this.windows1StateButton.Click += new System.EventHandler(this.Windos1StateButtonClick);
            // 
            // lowPanelStateButton
            // 
            this.lowPanelStateButton.Image = ((System.Drawing.Image)(resources.GetObject("lowPanelStateButton.Image")));
            this.lowPanelStateButton.Location = new System.Drawing.Point(334, 364);
            this.lowPanelStateButton.Name = "lowPanelStateButton";
            this.lowPanelStateButton.Size = new System.Drawing.Size(40, 40);
            this.lowPanelStateButton.TabIndex = 33;
            this.toolTip1.SetToolTip(this.lowPanelStateButton, "Показать/скрыть нижнюю панель окна 1");
            this.lowPanelStateButton.UseVisualStyleBackColor = true;
            this.lowPanelStateButton.Click += new System.EventHandler(this.LowPanelStateButtonClick);
            // 
            // window2StateButton
            // 
            this.window2StateButton.Image = ((System.Drawing.Image)(resources.GetObject("window2StateButton.Image")));
            this.window2StateButton.Location = new System.Drawing.Point(334, 410);
            this.window2StateButton.Name = "window2StateButton";
            this.window2StateButton.Size = new System.Drawing.Size(40, 40);
            this.window2StateButton.TabIndex = 34;
            this.toolTip1.SetToolTip(this.window2StateButton, "Показать/скрыть Окно 2");
            this.window2StateButton.UseVisualStyleBackColor = true;
            this.window2StateButton.Click += new System.EventHandler(this.Window2StateButtonClick);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Документ Word (*.doc)|*.doc";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Документ Word (*.doc, *.docx)|*.docx;*.doc";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(927, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.menuToolStripMenuItem.Text = "Меню";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.settingsToolStripMenuItem.Text = "Настройки";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItemClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(32, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(387, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // updateCurrentTimeTimer
            // 
            this.updateCurrentTimeTimer.Enabled = true;
            this.updateCurrentTimeTimer.Tick += new System.EventHandler(this.UpdateCurrentTimeTimerTick);
            // 
            // currentSpeakerInfoLabel
            // 
            this.currentSpeakerInfoLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.currentSpeakerInfoLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentSpeakerInfoLabel.Location = new System.Drawing.Point(67, 68);
            this.currentSpeakerInfoLabel.Name = "currentSpeakerInfoLabel";
            this.currentSpeakerInfoLabel.Size = new System.Drawing.Size(306, 19);
            this.currentSpeakerInfoLabel.TabIndex = 19;
            this.currentSpeakerInfoLabel.Text = "Информация о текущем участнике:";
            this.currentSpeakerInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(33, 163);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(387, 133);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // remainingTimeInfoLabel
            // 
            this.remainingTimeInfoLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.remainingTimeInfoLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.remainingTimeInfoLabel.Location = new System.Drawing.Point(67, 177);
            this.remainingTimeInfoLabel.Name = "remainingTimeInfoLabel";
            this.remainingTimeInfoLabel.Size = new System.Drawing.Size(156, 19);
            this.remainingTimeInfoLabel.TabIndex = 22;
            this.remainingTimeInfoLabel.Text = "Таймер:";
            this.remainingTimeInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // overTimeLabel
            // 
            this.overTimeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.overTimeLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.overTimeLabel.Location = new System.Drawing.Point(67, 210);
            this.overTimeLabel.Name = "overTimeLabel";
            this.overTimeLabel.Size = new System.Drawing.Size(219, 19);
            this.overTimeLabel.TabIndex = 21;
            this.overTimeLabel.Text = "Дополнительное время, мин:";
            this.overTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startButtonImageList
            // 
            this.startButtonImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("startButtonImageList.ImageStream")));
            this.startButtonImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.startButtonImageList.Images.SetKeyName(0, "startBig.png");
            this.startButtonImageList.Images.SetKeyName(1, "pause36.png");
            // 
            // remainingTimeStatusLabel
            // 
            this.remainingTimeStatusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.remainingTimeStatusLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.remainingTimeStatusLabel.Location = new System.Drawing.Point(319, 177);
            this.remainingTimeStatusLabel.Name = "remainingTimeStatusLabel";
            this.remainingTimeStatusLabel.Size = new System.Drawing.Size(70, 19);
            this.remainingTimeStatusLabel.TabIndex = 27;
            this.remainingTimeStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(33, 302);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(387, 160);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 28;
            this.pictureBox3.TabStop = false;
            // 
            // window1Label
            // 
            this.window1Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.window1Label.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.window1Label.Location = new System.Drawing.Point(67, 328);
            this.window1Label.Name = "window1Label";
            this.window1Label.Size = new System.Drawing.Size(160, 19);
            this.window1Label.TabIndex = 29;
            this.window1Label.Text = "Окно 1 свернуто";
            this.window1Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // window2Label
            // 
            this.window2Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.window2Label.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.window2Label.Location = new System.Drawing.Point(67, 420);
            this.window2Label.Name = "window2Label";
            this.window2Label.Size = new System.Drawing.Size(160, 19);
            this.window2Label.TabIndex = 30;
            this.window2Label.Text = "Окно 2 свернуто";
            this.window2Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // window1CurrentTimeLabel
            // 
            this.window1CurrentTimeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.window1CurrentTimeLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.window1CurrentTimeLabel.Location = new System.Drawing.Point(67, 374);
            this.window1CurrentTimeLabel.Name = "window1CurrentTimeLabel";
            this.window1CurrentTimeLabel.Size = new System.Drawing.Size(212, 19);
            this.window1CurrentTimeLabel.TabIndex = 31;
            this.window1CurrentTimeLabel.Text = "Нижняя панель свернута";
            this.window1CurrentTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // showHideButtonsImageList
            // 
            this.showHideButtonsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("showHideButtonsImageList.ImageStream")));
            this.showHideButtonsImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.showHideButtonsImageList.Images.SetKeyName(0, "hide36.png");
            this.showHideButtonsImageList.Images.SetKeyName(1, "show36.png");
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(33, 468);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(387, 193);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 35;
            this.pictureBox4.TabStop = false;
            // 
            // waringTimeLabel
            // 
            this.waringTimeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.waringTimeLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.waringTimeLabel.Location = new System.Drawing.Point(67, 484);
            this.waringTimeLabel.Name = "waringTimeLabel";
            this.waringTimeLabel.Size = new System.Drawing.Size(143, 38);
            this.waringTimeLabel.TabIndex = 36;
            this.waringTimeLabel.Text = "Время предупреждения:";
            this.waringTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // repeatSignalTimeLabel
            // 
            this.repeatSignalTimeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.repeatSignalTimeLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.repeatSignalTimeLabel.Location = new System.Drawing.Point(67, 528);
            this.repeatSignalTimeLabel.Name = "repeatSignalTimeLabel";
            this.repeatSignalTimeLabel.Size = new System.Drawing.Size(143, 45);
            this.repeatSignalTimeLabel.TabIndex = 38;
            this.repeatSignalTimeLabel.Text = "Время повторного\r\nсигнала:";
            this.repeatSignalTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // premmisionToRepeatCheckBox
            // 
            this.premmisionToRepeatCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.premmisionToRepeatCheckBox.Checked = true;
            this.premmisionToRepeatCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.premmisionToRepeatCheckBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.premmisionToRepeatCheckBox.Location = new System.Drawing.Point(67, 584);
            this.premmisionToRepeatCheckBox.Name = "premmisionToRepeatCheckBox";
            this.premmisionToRepeatCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.premmisionToRepeatCheckBox.Size = new System.Drawing.Size(294, 24);
            this.premmisionToRepeatCheckBox.TabIndex = 40;
            this.premmisionToRepeatCheckBox.Text = "Разрешить превышение регламента";
            this.premmisionToRepeatCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.premmisionToRepeatCheckBox.UseVisualStyleBackColor = false;
            // 
            // premimisionToSoundCheckBox
            // 
            this.premimisionToSoundCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.premimisionToSoundCheckBox.Checked = true;
            this.premimisionToSoundCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.premimisionToSoundCheckBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.premimisionToSoundCheckBox.Location = new System.Drawing.Point(67, 619);
            this.premimisionToSoundCheckBox.Name = "premimisionToSoundCheckBox";
            this.premimisionToSoundCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.premimisionToSoundCheckBox.Size = new System.Drawing.Size(294, 23);
            this.premimisionToSoundCheckBox.TabIndex = 41;
            this.premimisionToSoundCheckBox.Text = "Звуковой сигнал";
            this.premimisionToSoundCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.premimisionToSoundCheckBox.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(299, 484);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 38);
            this.label2.TabIndex = 44;
            this.label2.Text = ":";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(299, 531);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 38);
            this.label3.TabIndex = 45;
            this.label3.Text = ":";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // generalTimer
            // 
            this.generalTimer.Interval = 1000;
            this.generalTimer.Tick += new System.EventHandler(this.GeneralTimerTick);
            // 
            // waitingTimer
            // 
            this.waitingTimer.Interval = 1000;
            this.waitingTimer.Tick += new System.EventHandler(this.WaitingTimerTick);
            // 
            // repeatedTimer
            // 
            this.repeatedTimer.Interval = 1000;
            this.repeatedTimer.Tick += new System.EventHandler(this.RepeatedTimerTick);
            // 
            // warningTimeSecondComboBox
            // 
            this.warningTimeSecondComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.warningTimeSecondComboBox.DropDownHeight = 70;
            this.warningTimeSecondComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.warningTimeSecondComboBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.warningTimeSecondComboBox.FormatString = "  ";
            this.warningTimeSecondComboBox.FormattingEnabled = true;
            this.warningTimeSecondComboBox.IntegralHeight = false;
            this.warningTimeSecondComboBox.Items.AddRange(new object[] {
            "    00",
            "    01",
            "    02",
            "    03",
            "    04",
            "    05",
            "    06",
            "    07",
            "    08",
            "    09",
            "    10",
            "    11",
            "    12",
            "    13",
            "    14",
            "    15",
            "    16",
            "    17",
            "    18",
            "    19",
            "    20",
            "    21",
            "    22",
            "    23",
            "    24",
            "    25",
            "    26",
            "    27",
            "    28",
            "    29",
            "    30",
            "    31",
            "    32",
            "    33",
            "    34",
            "    35",
            "    36",
            "    37",
            "    38",
            "    39",
            "    40",
            "    41",
            "    42",
            "    43",
            "    44",
            "    45",
            "    46",
            "    47",
            "    48",
            "    49",
            "    50",
            "    51",
            "    52",
            "    53",
            "    54",
            "    55",
            "    56",
            "    57",
            "    58",
            "    59"});
            this.warningTimeSecondComboBox.Location = new System.Drawing.Point(319, 491);
            this.warningTimeSecondComboBox.MaxDropDownItems = 10;
            this.warningTimeSecondComboBox.Name = "warningTimeSecondComboBox";
            this.warningTimeSecondComboBox.Size = new System.Drawing.Size(70, 27);
            this.warningTimeSecondComboBox.TabIndex = 46;
            this.warningTimeSecondComboBox.Tag = "30";
            // 
            // repeatTimeSecondComboBox
            // 
            this.repeatTimeSecondComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.repeatTimeSecondComboBox.DropDownHeight = 70;
            this.repeatTimeSecondComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.repeatTimeSecondComboBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.repeatTimeSecondComboBox.FormattingEnabled = true;
            this.repeatTimeSecondComboBox.IntegralHeight = false;
            this.repeatTimeSecondComboBox.Items.AddRange(new object[] {
            "    00",
            "    01",
            "    02",
            "    03",
            "    04",
            "    05",
            "    06",
            "    07",
            "    08",
            "    09",
            "    10",
            "    11",
            "    12",
            "    13",
            "    14",
            "    15",
            "    16",
            "    17",
            "    18",
            "    19",
            "    20",
            "    21",
            "    22",
            "    23",
            "    24",
            "    25",
            "    26",
            "    27",
            "    28",
            "    29",
            "    30",
            "    31",
            "    32",
            "    33",
            "    34",
            "    35",
            "    36",
            "    37",
            "    38",
            "    39",
            "    40",
            "    41",
            "    42",
            "    43",
            "    44",
            "    45",
            "    46",
            "    47",
            "    48",
            "    49",
            "    50",
            "    51",
            "    52",
            "    53",
            "    54",
            "    55",
            "    56",
            "    57",
            "    58",
            "    59"});
            this.repeatTimeSecondComboBox.Location = new System.Drawing.Point(319, 538);
            this.repeatTimeSecondComboBox.MaxDropDownItems = 10;
            this.repeatTimeSecondComboBox.Name = "repeatTimeSecondComboBox";
            this.repeatTimeSecondComboBox.Size = new System.Drawing.Size(70, 27);
            this.repeatTimeSecondComboBox.TabIndex = 47;
            this.repeatTimeSecondComboBox.Tag = "30";
            this.repeatTimeSecondComboBox.SelectionChangeCommitted += new System.EventHandler(this.RepeatTimeComboBoxesSelectionChangeCommitted);
            // 
            // warningTimeMinuteComboBox
            // 
            this.warningTimeMinuteComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.warningTimeMinuteComboBox.DropDownHeight = 70;
            this.warningTimeMinuteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.warningTimeMinuteComboBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.warningTimeMinuteComboBox.FormattingEnabled = true;
            this.warningTimeMinuteComboBox.IntegralHeight = false;
            this.warningTimeMinuteComboBox.Items.AddRange(new object[] {
            "     0",
            "     1",
            "     2",
            "     3",
            "     4",
            "     5",
            "     6",
            "     7",
            "     8",
            "     9",
            "    10",
            "    11",
            "    12",
            "    13",
            "    14",
            "    15",
            "    16",
            "    17",
            "    18",
            "    19",
            "    20",
            "    21",
            "    22",
            "    23",
            "    24",
            "    25",
            "    26",
            "    27",
            "    28",
            "    29",
            "    30",
            "    31",
            "    32",
            "    33",
            "    34",
            "    35",
            "    36",
            "    37",
            "    38",
            "    39",
            "    40",
            "    41",
            "    42",
            "    43",
            "    44",
            "    45",
            "    46",
            "    47",
            "    48",
            "    49",
            "    50",
            "    51",
            "    52",
            "    53",
            "    54",
            "    55",
            "    56",
            "    57",
            "    58",
            "    59"});
            this.warningTimeMinuteComboBox.Location = new System.Drawing.Point(223, 491);
            this.warningTimeMinuteComboBox.MaxDropDownItems = 10;
            this.warningTimeMinuteComboBox.Name = "warningTimeMinuteComboBox";
            this.warningTimeMinuteComboBox.Size = new System.Drawing.Size(70, 27);
            this.warningTimeMinuteComboBox.TabIndex = 48;
            this.warningTimeMinuteComboBox.Tag = "30";
            // 
            // repeatTimeMinuteComboBox
            // 
            this.repeatTimeMinuteComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.repeatTimeMinuteComboBox.DropDownHeight = 70;
            this.repeatTimeMinuteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.repeatTimeMinuteComboBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.repeatTimeMinuteComboBox.FormattingEnabled = true;
            this.repeatTimeMinuteComboBox.IntegralHeight = false;
            this.repeatTimeMinuteComboBox.Items.AddRange(new object[] {
            "     0",
            "     1",
            "     2",
            "     3",
            "     4",
            "     5",
            "     6",
            "     7",
            "     8",
            "     9",
            "    10",
            "    11",
            "    12",
            "    13",
            "    14",
            "    15",
            "    16",
            "    17",
            "    18",
            "    19",
            "    20",
            "    21",
            "    22",
            "    23",
            "    24",
            "    25",
            "    26",
            "    27",
            "    28",
            "    29",
            "    30",
            "    31",
            "    32",
            "    33",
            "    34",
            "    35",
            "    36",
            "    37",
            "    38",
            "    39",
            "    40",
            "    41",
            "    42",
            "    43",
            "    44",
            "    45",
            "    46",
            "    47",
            "    48",
            "    49",
            "    50",
            "    51",
            "    52",
            "    53",
            "    54",
            "    55",
            "    56",
            "    57",
            "    58",
            "    59"});
            this.repeatTimeMinuteComboBox.Location = new System.Drawing.Point(223, 538);
            this.repeatTimeMinuteComboBox.MaxDropDownItems = 10;
            this.repeatTimeMinuteComboBox.Name = "repeatTimeMinuteComboBox";
            this.repeatTimeMinuteComboBox.Size = new System.Drawing.Size(70, 27);
            this.repeatTimeMinuteComboBox.TabIndex = 49;
            this.repeatTimeMinuteComboBox.Tag = "30";
            this.repeatTimeMinuteComboBox.SelectionChangeCommitted += new System.EventHandler(this.RepeatTimeComboBoxesSelectionChangeCommitted);
            // 
            // overtimeComboBox
            // 
            this.overtimeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.overtimeComboBox.DropDownHeight = 70;
            this.overtimeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.overtimeComboBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.overtimeComboBox.FormattingEnabled = true;
            this.overtimeComboBox.IntegralHeight = false;
            this.overtimeComboBox.Items.AddRange(new object[] {
            "     1",
            "     2",
            "     3",
            "     4",
            "     5",
            "     6",
            "     7",
            "     8",
            "     9",
            "    10",
            "    11",
            "    12",
            "    13",
            "    14",
            "    15",
            "    16",
            "    17",
            "    18",
            "    19",
            "    20",
            "    21",
            "    22",
            "    23",
            "    24",
            "    25",
            "    26",
            "    27",
            "    28",
            "    29",
            "    30",
            "    31",
            "    32",
            "    33",
            "    34",
            "    35",
            "    36",
            "    37",
            "    38",
            "    39",
            "    40",
            "    41",
            "    42",
            "    43",
            "    44",
            "    45",
            "    46",
            "    47",
            "    48",
            "    49",
            "    50",
            "    51",
            "    52",
            "    53",
            "    54",
            "    55",
            "    56",
            "    57",
            "    58",
            "    59"});
            this.overtimeComboBox.Location = new System.Drawing.Point(319, 207);
            this.overtimeComboBox.MaxDropDownItems = 10;
            this.overtimeComboBox.Name = "overtimeComboBox";
            this.overtimeComboBox.Size = new System.Drawing.Size(70, 27);
            this.overtimeComboBox.TabIndex = 50;
            this.overtimeComboBox.Tag = "30";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(927, 689);
            this.Controls.Add(this.overtimeComboBox);
            this.Controls.Add(this.repeatTimeMinuteComboBox);
            this.Controls.Add(this.warningTimeMinuteComboBox);
            this.Controls.Add(this.repeatTimeSecondComboBox);
            this.Controls.Add(this.warningTimeSecondComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.premimisionToSoundCheckBox);
            this.Controls.Add(this.premmisionToRepeatCheckBox);
            this.Controls.Add(this.repeatSignalTimeLabel);
            this.Controls.Add(this.waringTimeLabel);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.window2StateButton);
            this.Controls.Add(this.lowPanelStateButton);
            this.Controls.Add(this.windows1StateButton);
            this.Controls.Add(this.window1CurrentTimeLabel);
            this.Controls.Add(this.window2Label);
            this.Controls.Add(this.window1Label);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.remainingTimeStatusLabel);
            this.Controls.Add(this.addRaminingTimeButton);
            this.Controls.Add(this.stopTimerButton);
            this.Controls.Add(this.startTimersButton);
            this.Controls.Add(this.remainingTimeInfoLabel);
            this.Controls.Add(this.overTimeLabel);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.currentSpeakerInfoLabel);
            this.Controls.Add(this.currentSpeakersNameLabel);
            this.Controls.Add(this.currentSpeakersPerfermanceLabel);
            this.Controls.Add(this.mscTimeLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.editSpeakerButton);
            this.Controls.Add(this.downSpeakerButton);
            this.Controls.Add(this.upSpeakerButton);
            this.Controls.Add(this.deleteSpeakerButton);
            this.Controls.Add(this.addSpeakerButton);
            this.Controls.Add(this.speakersGrid);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "inTime";
            this.Load += new System.EventHandler(this.Form1Load);
            ((System.ComponentModel.ISupportInitialize)(this.speakersGrid)).EndInit();
            this.contorlsMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView speakersGrid;
        private System.Windows.Forms.Button addSpeakerButton;
        private System.Windows.Forms.Button deleteSpeakerButton;
        private System.Windows.Forms.Button upSpeakerButton;
        private System.Windows.Forms.Button downSpeakerButton;
        private System.Windows.Forms.Button editSpeakerButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ContextMenuStrip contorlsMenu;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label mscTimeLabel;
        private System.Windows.Forms.Label currentSpeakersPerfermanceLabel;
        private System.Windows.Forms.Label currentSpeakersNameLabel;
        private System.Windows.Forms.Timer updateCurrentTimeTimer;
        private System.Windows.Forms.Label currentSpeakerInfoLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label remainingTimeInfoLabel;
        private System.Windows.Forms.Label overTimeLabel;
        private System.Windows.Forms.Button startTimersButton;
        private System.Windows.Forms.ImageList startButtonImageList;
        private System.Windows.Forms.Button stopTimerButton;
        private System.Windows.Forms.Button addRaminingTimeButton;
        private System.Windows.Forms.Label remainingTimeStatusLabel;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label window1Label;
        private System.Windows.Forms.Label window2Label;
        private System.Windows.Forms.Label window1CurrentTimeLabel;
        private System.Windows.Forms.Button windows1StateButton;
        private System.Windows.Forms.Button lowPanelStateButton;
        private System.Windows.Forms.Button window2StateButton;
        private System.Windows.Forms.ImageList showHideButtonsImageList;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label waringTimeLabel;
        private System.Windows.Forms.Label repeatSignalTimeLabel;
        private System.Windows.Forms.CheckBox premmisionToRepeatCheckBox;
        private System.Windows.Forms.CheckBox premimisionToSoundCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfSpeaker;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameOfSpeaker;
        private System.Windows.Forms.DataGridViewTextBoxColumn perfoemance;
        private System.Windows.Forms.Timer generalTimer;
        private System.Windows.Forms.Timer waitingTimer;
        private System.Windows.Forms.Timer repeatedTimer;
        private System.Windows.Forms.ComboBox warningTimeSecondComboBox;
        private System.Windows.Forms.ComboBox repeatTimeSecondComboBox;
        private System.Windows.Forms.ComboBox warningTimeMinuteComboBox;
        private System.Windows.Forms.ComboBox repeatTimeMinuteComboBox;
        private System.Windows.Forms.ComboBox overtimeComboBox;
    }
}

