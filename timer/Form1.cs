using System;
using System.ComponentModel;
using System.IO;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace timer
{
    public partial class Form1 : Form
    {
        int currentSpeakersId;
        ListOfSpeakers speakers;
        fullScrennWindow window1;
        Window2 window2;
        bool window1IsOpen;
        bool window1IsCreate;
        bool window2IsCreate;
        bool window2IsOpen;
        int remainingTimersTime;
        int remainingSpeakersTime;
        int repeatedTime;
        int warningTime;
        string currentSpeakersName;
        Settings settings;
        SoundPlayer sound;
        bool pause;
        bool timerIsWorked;
        byte currentWorkedTimer;
        bool premissionToConcatenateLists;
        int currentSpeakerGridsRowsIndex;
        bool isRepeatSignalPlayed;
        bool canChangeSelect;
        int cellBellowMouseIndex;
        Thread musicThread;
        int lastSecond;

        public Form1()
        {
            InitializeComponent();
            currentSpeakersId = 0;
            speakers = new ListOfSpeakers();
            saveFileDialog.FileOk += new CancelEventHandler(SaveSpeakersToFile);
            openFileDialog.FileOk += new CancelEventHandler(LoadSpeakersFromFile);
            window2IsCreate = false;
            window1IsCreate = false;
            window1IsOpen = false;
            window2IsOpen = false;
            timerIsWorked = false;
            premissionToConcatenateLists = false;
            pause = false;
            canChangeSelect = true;
            isRepeatSignalPlayed = false;
            remainingTimersTime = 0;
            currentWorkedTimer = 0;
            lastSecond = DateTime.Now.Second;
        }

        private void Form1Load(object sender, EventArgs e)
        {
            SetDefaultTimesToTimers();
            LoadSettings();
            if (settings.CanLoadLastOpenedList())
            {
                LoadLastOpenedList();
            }
        }

        private void SetDefaultTimesToTimers()
        {
            overtimeComboBox.SelectedItem = overtimeComboBox.Items[4];
            warningTimeMinuteComboBox.SelectedItem = warningTimeMinuteComboBox.Items[0];
            warningTimeSecondComboBox.SelectedItem = warningTimeSecondComboBox.Items[30];
            repeatTimeMinuteComboBox.SelectedItem = repeatTimeMinuteComboBox.Items[0];
            repeatTimeSecondComboBox.SelectedItem = repeatTimeSecondComboBox.Items[30];
            remainingTimeStatusLabel.Text = "0 : 00";
            if (window1IsCreate)
            {
                window1.UpdateTimerLabelText("0 : 00");
            }
            if (window2IsCreate)
            {
                window2.UpdateLabelsText("", "0 : 00");
            }
        }

        private void LoadSettings()
        {
            try
            {
                FileStream settingsStream = new FileStream("Settings.bin", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                settings = (Settings)bf.Deserialize(settingsStream);
                settingsStream.Close();
                try
                {
                    sound = new SoundPlayer(settings.SoundsLoaction);
                }
                catch { }
            }
            catch
            {
                MessageBox.Show("Файл Settings.bin не найден или поврежден. \r\nБудут восстановлены стандартные настройки", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                settings = new Settings();
                settings.SetDefaultSettings();
                SaveSettings();
                try
                {
                    sound = new SoundPlayer(settings.SoundsLoaction);
                }
                catch { }
            }
        }

        private  void SaveSettings()
        {
            try
            {
                FileStream settingsStream = new FileStream("Settings.bin", FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(settingsStream, settings);
                settingsStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLastOpenedList()
        {
            try
            {
                LoadSpeakersFromDocFile(settings.LastOpenedListLocation);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LoadSpeakersFromDocFile(object path)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object readOnly = false;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
            docs.ActiveWindow.Selection.WholeStory();
            docs.ActiveWindow.Selection.Copy();
            IDataObject data = Clipboard.GetDataObject();
            string[] textLines = data.GetData(DataFormats.Text).ToString().Split('\r');
            for (int i = 0; i < textLines.Length; ++i)
            {
                if (textLines[i] != "\n")
                {
                    GetSpeakerFromTextLine(textLines[i]);
                }
            }
            docs.Close(ref miss, ref miss, ref miss);
            word.Quit(ref miss, ref miss, ref miss);
            UpdateSpeakersGrid(currentSpeakersId - 1);
        }

        private void GetSpeakerFromTextLine(string readLine)
        {
            string pattern = @" \d+";
            Regex regular = new Regex(pattern);
            Match perfermance;
            try
            {
                readLine.Trim();
                if (readLine.Length != 0)
                {
                    perfermance = regular.Match(readLine);
                    ++currentSpeakersId;
                    if (perfermance.Success)
                    {
                        AddSpeaker(perfermance.Value, regular.Split(readLine));
                    }
                    else
                    {
                        string newPattern = @"\d+";
                        Regex newRegular = new Regex(newPattern);
                        perfermance = newRegular.Match(readLine);
                        if (perfermance.Success)
                        {
                            AddSpeaker(perfermance.Value, newRegular.Split(readLine));
                        }
                        else
                        {
                            speakers.AddSpeaker(new Speaker(currentSpeakersId, readLine.Trim(), ""));
                        }
                    }
                }
            }
            catch
            {
                --currentSpeakersId;
            }
        }

        private void AddSpeaker(string readLine, string[] speakersInfo)
        {
            if (speakersInfo[0] == readLine)
            {
                speakers.AddSpeaker(new Speaker(currentSpeakersId, "", readLine.Trim()));
            }
            else
            {
                speakers.AddSpeaker(new Speaker(currentSpeakersId, speakersInfo[0].Trim(), readLine.Trim()));
            }
        }
        
        private void AddSpeakerButtonClick(object sender, EventArgs e)
        {
            addForm addingForm = new addForm();
            addingForm.ShowDialog();
            if (addingForm.isAdded)
            {
                ++currentSpeakersId;
                addingForm.newSpeaker.Id = currentSpeakersId;
                speakers.AddSpeaker(addingForm.newSpeaker);
                UpdateSpeakersGrid(currentSpeakersId-1);
            }
        }

        private void UpdateSpeakersGrid(int selectedRow)
        {
            try
            {
                canChangeSelect = false;
                speakersGrid.Rows.Clear();
                canChangeSelect = true;
                for (int i = 0; i < speakers.Count(); ++i)
                {
                    speakersGrid.Rows.Add(speakers[i].Id, speakers[i].Name, speakers[i].PerfermanceStr);
                }
                if ((selectedRow >= 0) & (selectedRow < speakersGrid.RowCount))
                {
                    speakersGrid.CurrentCell = speakersGrid[1, selectedRow];
                    speakersGrid.Rows[selectedRow].Selected = true;
                    speakersGrid.Rows[selectedRow].Cells[1].Selected = true;
                    SpeakersGridSelectionChanged(this, null);
                }
                else
                {
                    if (selectedRow == 0) { NotSelectSpeaker(); }
                }
                if (timerIsWorked)
                {
                    SetSelectColorToCurrenSpeakerCells(System.Drawing.Color.LightGray);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SpeakersGridSelectionChanged(object sender, EventArgs e)
        {
            if ((canChangeSelect) && (speakersGrid.CurrentCell != null) && (speakersGrid.RowCount != 0) && (!timerIsWorked))
            {
                if (speakers.Count() == 0)
                {
                    NotSelectSpeaker();
                }
                else
                {
                    SelectSpeaker(speakersGrid.CurrentRow.Index);
                }
            }
        }

        private void NotSelectSpeaker()
        {
            currentSpeakersNameLabel.Text = "Участник не выбран";
            currentSpeakersPerfermanceLabel.Text = "";
            remainingSpeakersTime = 0;
        }

        private void SelectSpeaker(int currentRow)
        {
            currentSpeakersNameLabel.Text = "ФИО: " + speakers[currentRow].Name;
            if (speakers[currentRow].PerfermanceStr != "")
            {
                currentSpeakersPerfermanceLabel.Text = "Время выступления: " + speakers[currentRow].PerfermanceStr + " мин";
            }
            else
            {
                currentSpeakersPerfermanceLabel.Text = "Время выступления: " + "не указано";
            }
            remainingSpeakersTime = speakers[currentRow].PerfermanceNum;
        }

        private void SetSelectColorToCurrenSpeakerCells(System.Drawing.Color newColor)
        {
            if ((speakersGrid.CurrentCell != null) && (speakersGrid.RowCount != 0))
            {
                for (int i = 0; i < 3; ++i)
                {
                    speakersGrid.Rows[currentSpeakerGridsRowsIndex].Cells[i].Style.BackColor = newColor;
                }
            }
        }

        private void DeleteSpeakerButtonClick(object sender, EventArgs e)
        {
            if ((speakersGrid.CurrentCell !=null) && (speakersGrid.RowCount != 0) & (speakers.Count() != 0))
            {
                if ((timerIsWorked) & (speakersGrid.CurrentCell.Style.BackColor == System.Drawing.Color.LightGray))
                {
                    MessageBox.Show("Удаление активного участника запрещено.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int deletedSpeakersId = speakersGrid.CurrentRow.Index + 1;
                    if (deletedSpeakersId - 1 != speakers.Count())
                    {
                        if (deletedSpeakersId <= currentSpeakerGridsRowsIndex)
                        {
                            --currentSpeakerGridsRowsIndex;
                        }
                        speakers.DeleteSpeaker(deletedSpeakersId);
                        --currentSpeakersId;    
                        UpdateSpeakersGrid(deletedSpeakersId - 2);
                        if (speakers.Count() == 0)
                        {
                            NotSelectSpeaker();
                        }
                    }
                }
            }
        }

        private void UpSpeakerButtonClick(object sender, EventArgs e)
        {
            if ((speakersGrid.CurrentCell != null) && (speakersGrid.RowCount != 0) & (speakers.Count() != 0))
            {
                int swapedSpeakersId = speakersGrid.CurrentRow.Index;
                if ((swapedSpeakersId > 0) & (swapedSpeakersId < speakers.Count()))
                {
                    if ((swapedSpeakersId == currentSpeakerGridsRowsIndex) & (currentSpeakersName == speakers[swapedSpeakersId].Name))
                    {
                        --currentSpeakerGridsRowsIndex;
                    }
                    if (currentSpeakersName == speakers[swapedSpeakersId - 1].Name)
                    {
                        ++currentSpeakerGridsRowsIndex;
                    }
                    speakers.UpSpeaker(swapedSpeakersId);
                    UpdateSpeakersGrid(swapedSpeakersId - 1);
                }
            }
        }

        private void DownSpeakerButtonClick(object sender, EventArgs e)
        {
            if ((speakersGrid.CurrentCell != null) && (speakersGrid.RowCount != 0) & (speakers.Count() != 0))
            {
                int swapedSpeakersId = speakersGrid.CurrentRow.Index;
                if ((swapedSpeakersId >= 0) & (swapedSpeakersId < speakers.Count() - 1))
                {
                    if ((swapedSpeakersId == currentSpeakerGridsRowsIndex) & (currentSpeakersName == speakers[swapedSpeakersId].Name))
                    {
                        ++currentSpeakerGridsRowsIndex;
                    }
                    if (currentSpeakersName == speakers[swapedSpeakersId + 1].Name)
                    {
                        --currentSpeakerGridsRowsIndex;
                    }
                    speakers.DownSpeakers(swapedSpeakersId);
                    UpdateSpeakersGrid(swapedSpeakersId + 1);
                }
            }
        }

        private void EditSpeakerButtonClick(object sender, EventArgs e)
        {
            if ((speakersGrid.CurrentCell != null) && (speakersGrid.RowCount != 0)  && (speakersGrid.CurrentCell.Value != null))
            {
                if ((timerIsWorked) & (currentSpeakersName == speakers[speakersGrid.CurrentRow.Index].Name))
                {
                    MessageBox.Show("Редактирование данных активного участника запрещено.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int currentId = speakersGrid.CurrentRow.Index;
                    editForm edingForm = new editForm(speakers[currentId]);
                    edingForm.ShowDialog();
                    if (edingForm.isEdit)
                    {
                        speakers[currentId] = new Speaker(speakers[currentId].Id, edingForm.nameOfSpeakerTextBox.Text, edingForm.perfomanceTextBox.Text);
                        UpdateSpeakersGrid(currentId);
                    }
                }
            }
        }

        private void OpenButtonClick(object sender, EventArgs e)
        {
            if (currentSpeakersId == 0)
            {
                openFileDialog.ShowDialog();
            }
            else
            {
                premissionToConcatenateLists = false;
                System.Windows.Forms.DialogResult loadSolution = MessageBox.Show("При открытии файла текущий список будет утерян. \r\nОбъединить содержимое файла и текущего списка?", Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                switch (loadSolution)
                {
                    case System.Windows.Forms.DialogResult.No:
                        if (timerIsWorked)
                        {
                            MessageBox.Show("Открытие файла без слияния невозможно, \r\nпока участник текущего списка выступает.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            openFileDialog.ShowDialog();
                        }
                        break;
                    case System.Windows.Forms.DialogResult.Yes:
                        premissionToConcatenateLists = true;
                        openFileDialog.ShowDialog(); 
                        break;
                }
            }
        }
        
        private void LoadSpeakersFromFile(object sender, CancelEventArgs ar)
        {
            try
            {
                if (!premissionToConcatenateLists)
                {
                    speakers = new ListOfSpeakers();
                    currentSpeakersId = 0;
                }
                LoadSpeakersFromDocFile(openFileDialog.FileName);
                settings.LastOpenedListLocation = openFileDialog.FileName;
                SilentSavingSettings();
            }
            catch
            {
                MessageBox.Show("Не удалось открыть файл. Возможно, он поврежден.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SilentSavingSettings()
        {
            try
            {
                FileStream savingStream = new FileStream("Settings.bin", FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(savingStream, settings);
                savingStream.Close();
            }
            catch { }
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            if (currentSpeakersId != 0)
            {
                saveFileDialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("Невозможно сохранить пустой список", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveSpeakersToFile(object sender, CancelEventArgs ar)
        {
            SaveSpeakersToDocFile();
            saveFileDialog.FileName = "";
        }
        
        private void SaveSpeakersToDocFile()
        {
            try
            {
                object missing = System.Reflection.Missing.Value;
                Word.Application word;
                Word.Document doc;
                word = new Word.Application();
                doc = word.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                Word.Paragraph paragraph;
                object path = saveFileDialog.FileName;
                paragraph = doc.Content.Paragraphs.Add(ref missing);
                for (int i = 0; i < speakers.Count(); ++i)
                {
                    paragraph.Range.Text += speakers[i].Name + " " + speakers[i].PerfermanceStr;
                }
                paragraph.Range.InsertParagraphAfter();
                doc.SaveAs2(ref path, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing); 
                doc.Close();
                word.Quit(ref missing, ref missing, ref missing); 
            }
            catch 
            {
                MessageBox.Show("Не удалось сохранить список. Попробуйте еще раз.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
 
        }

        private void SpeakersGridCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((speakersGrid.CurrentCell != null) && (speakersGrid.CurrentCell.Value == null))
            {
                AddSpeakerButtonClick(this, null);
            }
        }

        private void SpeakersGridCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditSpeakerButtonClick(this, null);
        }

        private void SpeakersGridKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if ((timerIsWorked) & (speakersGrid.CurrentCell != null) && (speakersGrid.CurrentCell.Style.BackColor == System.Drawing.Color.LightGray))
                {
                    MessageBox.Show("Удаление активного участника запрещено.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Handled = true;
                }
                else
                {
                    DeleteSpeakerButtonClick(this, null);
                }
            }
        }

        private void SpeakersGridCellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            cellBellowMouseIndex = e.RowIndex;
        }
              
        private void ContorlsMenuOpening(object sender, CancelEventArgs e)
        {
            if ((speakersGrid.RowCount != 0) & (speakers.Count() != 0) & (cellBellowMouseIndex < speakersGrid.RowCount))
            {
                speakersGrid.Rows[cellBellowMouseIndex].Selected = true;
                speakersGrid.Rows[cellBellowMouseIndex].Cells[1].Selected = true;
                SpeakersGridSelectionChanged(this, null);
                if (speakersGrid.CurrentCell.Value == null)
                {
                    contorlsMenu.Items[1].Enabled = false;
                    contorlsMenu.Items[2].Enabled = false;
                }
                else
                {
                    contorlsMenu.Items[1].Enabled = true;
                    contorlsMenu.Items[2].Enabled = true;
                }
            }
            else
            {
                contorlsMenu.Items[1].Enabled = false;
                contorlsMenu.Items[2].Enabled = false;
            }
        }

        private void AddToolStripMenuItemClick(object sender, EventArgs e)
        {
            AddSpeakerButtonClick(this, null);
        }

        private void EditToolStripMenuItemClick(object sender, EventArgs e)
        {
            EditSpeakerButtonClick(this, null);
        }

        private void DeleteToolStripMenuItemClick(object sender, EventArgs e)
        {
            DeleteSpeakerButtonClick(this, null);
        }
        
        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }

        private void SettingsToolStripMenuItemClick(object sender, EventArgs e)
        {
            SettingsForm settingForm = new SettingsForm();
            settingForm.settingsIsChanged += new EventHandler(ChangeSettings);
            settingForm.ShowDialog();
        }

        private void ChangeSettings(object sender, EventArgs e)
        {
            SettingsForm temp = (SettingsForm)sender;
            settings = temp.settings;
            try
            {
                sound = new SoundPlayer(settings.SoundsLoaction);
            }
            catch { }
        }
        
        private void UpdateCurrentTimeTimerTick(object sender, EventArgs e)
        {
            mscTimeLabel.Text = GetCurrentTime();
            if (lastSecond - DateTime.Now.Second != 0)
            {
                lastSecond = DateTime.Now.Second;
                if (generalTimer.Enabled || repeatedTimer.Enabled)
                {
                    if (window1IsCreate)
                    {
                        window1.UpdateTimerLabelText(remainingTimeStatusLabel.Text);
                    }
                    if (window2IsCreate)
                    {
                        window2.UpdateLabelsText(currentSpeakersName, remainingTimeStatusLabel.Text);
                    }
                }
                if (waitingTimer.Enabled)
                {
                    if (window1IsCreate)
                    {
                        window1.UpdateTimerLabelText("ВРЕМЯ ИСТЕКЛО!");
                    }
                    if (window2IsCreate)
                    {
                        window2.UpdateLabelsText(currentSpeakersName, remainingTimeStatusLabel.Text);
                    }
                }
            }
            if (window1IsCreate)
            {
                window1.UpdateCurrentTimeLabelsText(mscTimeLabel.Text);
            }
            mscTimeLabel.Text = "Текущее время: " + mscTimeLabel.Text;
        }

        private string GetCurrentTime()
        {
            string returnedTime = "";
            if (System.DateTime.Now.Hour < 10)
            {
                returnedTime += "0";
            }
            returnedTime += Convert.ToString(System.DateTime.Now.Hour) + " : ";
            if (System.DateTime.Now.Minute < 10)
            {
                returnedTime += "0";
            }
            returnedTime += Convert.ToString(System.DateTime.Now.Minute) + " : ";
            if (System.DateTime.Now.Second < 10)
            {
                returnedTime += "0";
            }
            returnedTime += Convert.ToString(System.DateTime.Now.Second);
            return returnedTime;
        }

        private void Windos1StateButtonClick(object sender, EventArgs e)
        {
            if (!window1IsOpen)
            {
                if (!window1IsCreate)
                {
                    window1 = new fullScrennWindow();
                    window1.FormClosing += new FormClosingEventHandler(Window1FormClosing);
                    window1IsCreate = true;
                    window1CurrentTimeLabel.Text = "Нижняя панель развернута";
                    lowPanelStateButton.Image = showHideButtonsImageList.Images[1];
                    window1.FullScrennWindowDoubleClick(this, null);
                    Windos1StateButtonClick(this, null); 
                }
                Screen secondaryScreen = GetSecondaryScreen();
                window1.Left = secondaryScreen.WorkingArea.Left;
                window1.Top = secondaryScreen.WorkingArea.Top;
                window1.Location = secondaryScreen.WorkingArea.Location;
                window1.StartPosition = FormStartPosition.Manual;
                window1IsOpen = true;
                window1.Show();
                window1Label.Text = "Окно 1 развернуто";
                windows1StateButton.Image = showHideButtonsImageList.Images[1];
            }
            else
            {
                window1.Hide();
                window1IsOpen = false;
                window1Label.Text = "Окно 1 свернуто";
                windows1StateButton.Image = showHideButtonsImageList.Images[0];
            }
        }

        private void Window1FormClosing(object sender, FormClosingEventArgs e)
        {
            window1IsOpen = false;
            window1IsCreate = false;
            window1Label.Text = "Окно 1 свернуто";
            windows1StateButton.Image = showHideButtonsImageList.Images[0];
            window1CurrentTimeLabel.Text = "Нижняя панель свернута";
            lowPanelStateButton.Image = showHideButtonsImageList.Images[0];
        }
        private Screen GetSecondaryScreen()
        {
            Screen returnedScreen = Screen.AllScreens[0];
            if (Screen.AllScreens.Length > 1)
            {
                foreach (Screen x in Screen.AllScreens)
                {
                    if (x != Screen.PrimaryScreen)
                    {
                        returnedScreen =  x;
                        break;
                    }
                }
            }
            return returnedScreen;
        }
        private void LowPanelStateButtonClick(object sender, EventArgs e)
        {
            if (window1IsOpen)
            {
                if (!window1.CurrentTimeLabelVisible)
                {
                    window1.ShowCurrentTimeLabel();
                    window1CurrentTimeLabel.Text = "Нижняя панель развернута";
                    lowPanelStateButton.Image = showHideButtonsImageList.Images[1];
                }
                else
                {
                    window1.HideCurrentTimeLabel();
                    window1CurrentTimeLabel.Text = "Нижняя панель свернута";
                    lowPanelStateButton.Image = showHideButtonsImageList.Images[0];
                }
            }
        }

        private void Window2StateButtonClick(object sender, EventArgs e)
        {
            if (!window2IsOpen)
            {
                if (!window2IsCreate)
                {
                    window2 = new Window2();
                    window2.FormClosing += new FormClosingEventHandler(Window2FormClosing);
                    window2IsCreate = true;
                    Window2StateButtonClick(this, null);
                }
                Screen primaryScreen = GetPrimaryScreen();
                window2.Top = primaryScreen.Bounds.Height-window2.Height;
                window2.Left = primaryScreen.WorkingArea.Left;
                window2.Width = primaryScreen.Bounds.Width;
                window2.StartPosition = FormStartPosition.Manual;
                window2IsOpen = true;
                window2.Show();
                window2Label.Text = "Окно 2 развернуто";
                window2StateButton.Image = showHideButtonsImageList.Images[1];
            }
            else
            {
                window2IsOpen = false;
                window2.Hide();
                window2Label.Text = "Окно 2 свернуто";
                window2StateButton.Image = showHideButtonsImageList.Images[0];
            }
        }

        private void Window2FormClosing(object sender, FormClosingEventArgs e)
        {
            window2IsOpen = false;
            window2IsCreate = false;
            window2Label.Text = "Окно 2 свернуто";
            window2StateButton.Image = showHideButtonsImageList.Images[0];
        }

        private Screen GetPrimaryScreen()
        {
            Screen returnedScreen = Screen.AllScreens[0] ;
            foreach (Screen x in Screen.AllScreens)
            {
                if (x == Screen.PrimaryScreen)
                {
                    returnedScreen = x;
                    break;
                }
            }            
            return returnedScreen;
        }

        private void StartTimersButtonClick(object sender, EventArgs e)
        {
            if ((remainingSpeakersTime == 0) || (speakers.Count() == 0))
            {
                if (currentSpeakersPerfermanceLabel.Text == "Время выступления: не указано")
                {
                    MessageBox.Show("Задайте время выступления.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Сначала выберите участника.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (!timerIsWorked)
                {
                    currentSpeakersName = speakers[speakersGrid.CurrentRow.Index].Name;
                    currentSpeakerGridsRowsIndex = speakersGrid.CurrentRow.Index;
                    SetSelectColorToCurrenSpeakerCells(System.Drawing.Color.LightGray);
                    timerIsWorked = true;
                    pause = false;
                    currentWorkedTimer = 1;
                    remainingTimersTime = remainingSpeakersTime;
                    generalTimer.Start();
                    startTimersButton.Image = startButtonImageList.Images[1];
                    toolTip1.SetToolTip(startTimersButton, "Приостановить таймер");
                }
                else
                {
                    if (!pause)
                    {
                        pause = true;
                        startTimersButton.Image = startButtonImageList.Images[0];
                        switch (currentWorkedTimer)
                        {
                            case 1: generalTimer.Stop(); break;
                            case 2: repeatedTimer.Stop(); break;
                        }
                        toolTip1.SetToolTip(startTimersButton, "Запустить таймер");
                    }
                    else
                    {
                        pause = false;
                        startTimersButton.Image = startButtonImageList.Images[1]; 
                        switch (currentWorkedTimer)
                        {
                            case 1: generalTimer.Start(); break;
                            case 2: repeatedTimer.Start(); break;
                        }
                        toolTip1.SetToolTip(startTimersButton, "Приостановить таймер");
                    }
                }
            }
        }

        private void GeneralTimerTick(object sender, EventArgs e)
        {
            if (remainingTimersTime == 0)
            {
                if (window1IsCreate)
                {
                    window1.StopWarningTimer();
                    window1.SetWarningTextToLabel();
                }
                currentWorkedTimer = 0;
                repeatedTime = 0;
                waitingTimer.Start();
                generalTimer.Stop();
                musicThread = new Thread(PlaySoundOnce);
                musicThread.Start();
            }
            else
            {
                --remainingTimersTime;
                remainingTimeStatusLabel.Text = ConvertTimeToString(remainingTimersTime);
                if (window1IsCreate)
                {
                    if (IsWarningTime())
                    {
                        window1.StartWarningTimer();
                    }
                    else
                    {
                        window1.StopWarningTimer();
                        window1.SetDefaultColorToLabels();
                    }
                }
            }
        }

        private void PlaySoundOnce()
        {
            if (premimisionToSoundCheckBox.Checked)
            {
                try
                {
                    sound.Play();
                }
                catch 
                {
                    MessageBox.Show("Не удалось открыть звуковой файл.\r\nВыберите новый звук в настройках.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string ConvertTimeToString(int time)
        {
            string returnedTime = Convert.ToString(time / 60) + " : "; 
            if (time % 60 < 10)
            {
                returnedTime += "0";
            }
            returnedTime += Convert.ToString(time % 60);
            return returnedTime;
        }

        private bool IsWarningTime()
        {
            warningTime = Convert.ToInt32(warningTimeMinuteComboBox.Text) * 60 + Convert.ToInt32(warningTimeSecondComboBox.Text);
            if ((warningTime == 0) || (remainingTimersTime > warningTime))
            {
                return false;
            }
            else
            { 
                return true; 
            }
        }

        private void WaitingTimerTick(object sender, EventArgs e)
        {
            if (repeatedTime < 6)
            {
                ++repeatedTime;
            }
            else
            {
                if (window1IsCreate)
                {
                    window1.SetUsualTextToLabels();
                }
                if (premmisionToRepeatCheckBox.Checked)
                {
                    remainingTimersTime = Convert.ToInt32(repeatTimeMinuteComboBox.Text) * 60 + Convert.ToInt32(repeatTimeSecondComboBox.Text);
                    repeatedTime = 0;
                    currentWorkedTimer = 2;
                    repeatedTimer.Start();
                }
                else
                {
                    if (window1IsCreate)
                    {
                        window1.SetWarningTextToLabel();
                        window1.StartWarningTimer();
                    }
                    //StopTimerButtonClick(this, null);
                }
                waitingTimer.Stop();
                
            }
        }

        private void RepeatedTimerTick(object sender, EventArgs e)
        {
            ++repeatedTime;
            remainingTimeStatusLabel.Text = ConvertTimeToString(repeatedTime);
            if (window1IsCreate)
            {
                window1.StartRepeatTimer();
            }
            if ( (!isRepeatSignalPlayed) &&(remainingTimersTime == repeatedTime) & (premimisionToSoundCheckBox.Checked))
            {
                isRepeatSignalPlayed = true;
                musicThread = new Thread(PlaySoundTwice);
                musicThread.Start();  
            }
        }

        private void PlaySoundTwice()
        {
            try
            {
                sound.PlaySync();
                sound.PlaySync();
            }
            catch
            {
                MessageBox.Show("Не удалось открыть звуковой файл.\r\nВыберите новый звук в настройках.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StopTimerButtonClick(object sender, EventArgs e)
        {
            currentWorkedTimer = 0;
            timerIsWorked = false;
            pause = false;
            isRepeatSignalPlayed = false;
            startTimersButton.Image = startButtonImageList.Images[0];
            if (generalTimer.Enabled)
            {
                generalTimer.Stop();
            }
            if (waitingTimer.Enabled)
            {
                waitingTimer.Stop();
            }
            if (repeatedTimer.Enabled)
            {
                repeatedTimer.Stop();
            }
            sound.Stop();
            if (window1IsCreate)
            {
                window1.StopRepeatTimer();
                window1.StopWarningTimer();
                window1.SetDefaultColorToLabels();
            }
            if (window2IsCreate)
            {
                window2.TimerLabelTextChanged(this, null);
            }
            SetDefaultTimesToTimers();
            SetSelectColorToCurrenSpeakerCells(System.Drawing.Color.White);
            SpeakersGridSelectionChanged(this, null);
        }

        private void AddRaminingTimeButtonClick(object sender, EventArgs e)
        {
            if ((remainingSpeakersTime == 0) || (speakers.Count() == 0))
            {
                if (currentSpeakersPerfermanceLabel.Text == "Время выступления: не указано")
                {
                    MessageBox.Show("Задайте время выступления.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Сначала выберите участника.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if  (timerIsWorked)
                {
                    if (repeatedTimer.Enabled)
                    {
                        remainingTimersTime = Convert.ToInt32(overtimeComboBox.Text) * 60;
                        repeatedTimer.Stop();
                        if (window1IsCreate)
                        {
                            window1.StopRepeatTimer();
                            window1.StopWarningTimer();
                            window1.SetDefaultColorToLabels();
                        }
                        generalTimer.Start();
                    }
                    else
                    {
                        remainingTimersTime += Convert.ToInt32(overtimeComboBox.Text) * 60; 
                    }
                }
                else
                {
                    waitingTimer.Stop();
                    if (window1IsCreate)
                    {
                        window1.StopRepeatTimer();
                        window1.StopWarningTimer();
                        window1.SetUsualTextToLabels();
                        window1.SetDefaultColorToLabels();
                    }
                    remainingTimersTime = Convert.ToInt32(overtimeComboBox.Text) * 60;
                    currentSpeakersName = speakers[speakersGrid.CurrentRow.Index].Name;
                    currentSpeakerGridsRowsIndex = speakersGrid.CurrentRow.Index;
                    SetSelectColorToCurrenSpeakerCells(System.Drawing.Color.LightGray);
                    pause = false;
                    timerIsWorked = true;
                    currentWorkedTimer = 3;
                    generalTimer.Start();
                    startTimersButton.Image = startButtonImageList.Images[1];
                    toolTip1.SetToolTip(startTimersButton, "Приостановить таймер");
                }
            }
        }

        private void RepeatTimeComboBoxesSelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((repeatTimeMinuteComboBox.SelectedItem == repeatTimeMinuteComboBox.Items[0]) & (repeatTimeSecondComboBox.SelectedItem == repeatTimeSecondComboBox.Items[0]))
            {
                premmisionToRepeatCheckBox.Checked = false;
            }
            if (repeatedTimer.Enabled)
            {
                remainingTimersTime = Convert.ToInt32(repeatTimeMinuteComboBox.Text) * 60 + Convert.ToInt32(repeatTimeSecondComboBox.Text);
            }
        }

    }
}
