using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using Timer.InformationWindows;
using Timer.Models;
using Timer.Settings;
using Timer.SpeakerList;

namespace Timer
{
    public partial class MainForm : Form
    {
        int _currentSpeakersId;
        Speakers _speakers;
        FullScreenWindow _fullScreenWindow;
        BottomWindow _bottomWindow;
        bool _window1IsOpen;
        bool _window1IsCreate;
        bool _window2IsCreate;
        bool _window2IsOpen;
        int _remainingTimersTime;
        int _remainingSpeakersTime;
        int _repeatedTime;
        int _warningTime;
        string _currentSpeakersName;
        Settings.Settings _settings;
        SoundPlayer _sound;
        bool _pause;
        bool _timerIsWorked;
        byte _currentWorkedTimer;
        bool _premissionToConcatenateLists;
        int _currentSpeakerGridsRowsIndex;
        bool _isRepeatSignalPlayed;
        bool _canChangeSelect;
        int _cellBellowMouseIndex;
        Thread _soundThread;
        int _lastSecond;

        public MainForm()
        {
            InitializeComponent();
            _currentSpeakersId = 0;
            _speakers = new Speakers();
            saveFileDialog.FileOk += SaveSpeakersToFile;
            openFileDialog.FileOk += LoadSpeakersFromFile;
            _window2IsCreate = false;
            _window1IsCreate = false;
            _window1IsOpen = false;
            _window2IsOpen = false;
            _timerIsWorked = false;
            _premissionToConcatenateLists = false;
            _pause = false;
            _canChangeSelect = true;
            _isRepeatSignalPlayed = false;
            _remainingTimersTime = 0;
            _currentWorkedTimer = 0;
            _lastSecond = DateTime.Now.Second;
        }

        private void Form1Load(object sender, EventArgs e)
        {
            InitializeTimers();
            LoadSettings();
            if (_settings.CanLoadLastOpenedList())
            {
                LoadLastOpenedList();
            }
        }

        private void InitializeTimers()
        {
            overtimeComboBox.SelectedItem = overtimeComboBox.Items[4];
            warningTimeMinuteComboBox.SelectedItem = warningTimeMinuteComboBox.Items[0];
            warningTimeSecondComboBox.SelectedItem = warningTimeSecondComboBox.Items[30];
            repeatTimeMinuteComboBox.SelectedItem = repeatTimeMinuteComboBox.Items[0];
            repeatTimeSecondComboBox.SelectedItem = repeatTimeSecondComboBox.Items[30];
            remainingTimeStatusLabel.Text = "0 : 00";
            if (_window1IsCreate)
            {
                _fullScreenWindow.UpdateTimerLabelText("0 : 00");
            }
            if (_window2IsCreate)
            {
                _bottomWindow.UpdateLabelsText("", "0 : 00");
            }
        }

        private void LoadSettings()
        {
            try
            {
                _settings = SettingsManager.LoadSettings();
            }
            catch
            {
                MessageBox.Show("Файл Settings.bin не найден или поврежден. \r\nБудут восстановлены стандартные настройки", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _settings = SettingsManager.GetDefaultSettings();
                SaveSettings();
            }
            finally
            {
                try
                {
                    _sound = new SoundPlayer(_settings.SoundPath);
                }
                catch { }
            }
        }

        private  void SaveSettings()
        {
            try
            {
                SettingsManager.SaveSettings(_settings);
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
                LoadSpeakersFromDocFile(_settings.LastOpenedListPath);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LoadSpeakersFromDocFile(object path)
        {
            _speakers = SpeakersManager.LoadSpeakers(path);
            UpdateSpeakersGrid(_currentSpeakersId - 1);
        }

        
        private void AddSpeakerButtonClick(object sender, EventArgs e)
        {
            var addingForm = new AddSpeakerForm();
            addingForm.ShowDialog();
            if (addingForm.IsAdded)
            {
                ++_currentSpeakersId;
                addingForm.Speaker.Id = _currentSpeakersId;
                _speakers.AddSpeaker(addingForm.Speaker);
                UpdateSpeakersGrid(_currentSpeakersId-1);
            }
        }

        private void UpdateSpeakersGrid(int selectedRow)
        {
            try
            {
                _canChangeSelect = false;
                speakersGrid.Rows.Clear();
                _canChangeSelect = true;
                for (var i = 0; i < _speakers.Count(); ++i)
                {
                    speakersGrid.Rows.Add(_speakers[i].Id, _speakers[i].Name, _speakers[i].PerfermanceStr);
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
                if (_timerIsWorked)
                {
                    SetSelectColorToCurrenSpeakerCells(Color.LightGray);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SpeakersGridSelectionChanged(object sender, EventArgs e)
        {
            if ((_canChangeSelect) && (speakersGrid.CurrentCell != null) && (speakersGrid.RowCount != 0) && (!_timerIsWorked))
            {
                if (_speakers.Count() == 0)
                {
                    NotSelectSpeaker();
                }
                else
                {
                    if (speakersGrid.CurrentRow != null) SelectSpeaker(speakersGrid.CurrentRow.Index);
                }
            }
        }

        private void NotSelectSpeaker()
        {
            currentSpeakersNameLabel.Text = "Участник не выбран";
            currentSpeakersPerfermanceLabel.Text = "";
            _remainingSpeakersTime = 0;
        }

        private void SelectSpeaker(int currentRow)
        {
            currentSpeakersNameLabel.Text = "ФИО: " + _speakers[currentRow].Name;
            if (_speakers[currentRow].PerfermanceStr != "")
            {
                currentSpeakersPerfermanceLabel.Text = "Время выступления: " + _speakers[currentRow].PerfermanceStr + " мин";
            }
            else
            {
                currentSpeakersPerfermanceLabel.Text = "Время выступления: " + "не указано";
            }
            _remainingSpeakersTime = _speakers[currentRow].PerformanceDuration;
        }

        private void SetSelectColorToCurrenSpeakerCells(Color newColor)
        {
            if ((speakersGrid.CurrentCell != null) && (speakersGrid.RowCount != 0))
            {
                for (var i = 0; i < 3; ++i)
                {
                    speakersGrid.Rows[_currentSpeakerGridsRowsIndex].Cells[i].Style.BackColor = newColor;
                }
            }
        }

        private void DeleteSpeakerButtonClick(object sender, EventArgs e)
        {
            if ((speakersGrid.CurrentCell !=null) && (speakersGrid.RowCount != 0) & (_speakers.Count() != 0))
            {
                if ((_timerIsWorked) & (speakersGrid.CurrentCell.Style.BackColor == Color.LightGray))
                {
                    MessageBox.Show("Удаление активного участника запрещено.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (speakersGrid.CurrentRow != null)
                    {
                        var deletedSpeakersId = speakersGrid.CurrentRow.Index + 1;
                        if (deletedSpeakersId - 1 != _speakers.Count())
                        {
                            if (deletedSpeakersId <= _currentSpeakerGridsRowsIndex)
                            {
                                --_currentSpeakerGridsRowsIndex;
                            }
                            _speakers.DeleteSpeaker(deletedSpeakersId);
                            --_currentSpeakersId;    
                            UpdateSpeakersGrid(deletedSpeakersId - 2);
                            if (_speakers.Count() == 0)
                            {
                                NotSelectSpeaker();
                            }
                        }
                    }
                }
            }
        }

        private void UpSpeakerButtonClick(object sender, EventArgs e)
        {
            if ((speakersGrid.CurrentCell != null) && (speakersGrid.RowCount != 0) & (_speakers.Count() != 0))
            {
                if (speakersGrid.CurrentRow != null)
                {
                    var swapedSpeakersId = speakersGrid.CurrentRow.Index;
                    if ((swapedSpeakersId > 0) & (swapedSpeakersId < _speakers.Count()))
                    {
                        if ((swapedSpeakersId == _currentSpeakerGridsRowsIndex) & (_currentSpeakersName == _speakers[swapedSpeakersId].Name))
                        {
                            --_currentSpeakerGridsRowsIndex;
                        }
                        if (_currentSpeakersName == _speakers[swapedSpeakersId - 1].Name)
                        {
                            ++_currentSpeakerGridsRowsIndex;
                        }
                        _speakers.UpSpeaker(swapedSpeakersId);
                        UpdateSpeakersGrid(swapedSpeakersId - 1);
                    }
                }
            }
        }

        private void DownSpeakerButtonClick(object sender, EventArgs e)
        {
            if ((speakersGrid.CurrentCell != null) && (speakersGrid.RowCount != 0) & (_speakers.Count() != 0))
            {
                if (speakersGrid.CurrentRow != null)
                {
                    var swapedSpeakersId = speakersGrid.CurrentRow.Index;
                    if ((swapedSpeakersId >= 0) & (swapedSpeakersId < _speakers.Count() - 1))
                    {
                        if ((swapedSpeakersId == _currentSpeakerGridsRowsIndex) & (_currentSpeakersName == _speakers[swapedSpeakersId].Name))
                        {
                            ++_currentSpeakerGridsRowsIndex;
                        }
                        if (_currentSpeakersName == _speakers[swapedSpeakersId + 1].Name)
                        {
                            --_currentSpeakerGridsRowsIndex;
                        }
                        _speakers.DownSpeakers(swapedSpeakersId);
                        UpdateSpeakersGrid(swapedSpeakersId + 1);
                    }
                }
            }
        }

        private void EditSpeakerButtonClick(object sender, EventArgs e)
        {
            if ((speakersGrid.CurrentCell != null) && (speakersGrid.RowCount != 0)  && (speakersGrid.CurrentCell.Value != null))
            {
                if (speakersGrid.CurrentRow != null && (_timerIsWorked) & (_currentSpeakersName == _speakers[speakersGrid.CurrentRow.Index].Name))
                {
                    MessageBox.Show("Редактирование данных активного участника запрещено.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (speakersGrid.CurrentRow != null)
                    {
                        var currentId = speakersGrid.CurrentRow.Index;
                        var edingForm = new EditForm(_speakers[currentId]);
                        edingForm.ShowDialog();
                        if (edingForm.IsEdit)
                        {
                            _speakers[currentId] = new Speaker(_speakers[currentId].Id, edingForm.nameOfSpeakerTextBox.Text, edingForm.perfomanceTextBox.Text);
                            UpdateSpeakersGrid(currentId);
                        }
                    }
                }
            }
        }

        private void OpenButtonClick(object sender, EventArgs e)
        {
            if (_currentSpeakersId == 0)
            {
                openFileDialog.ShowDialog();
            }
            else
            {
                _premissionToConcatenateLists = false;
                var loadSolution = MessageBox.Show("При открытии файла текущий список будет утерян. \r\nОбъединить содержимое файла и текущего списка?", Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                switch (loadSolution)
                {
                    case DialogResult.No:
                        if (_timerIsWorked)
                        {
                            MessageBox.Show("Открытие файла без слияния невозможно, \r\nпока участник текущего списка выступает.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            openFileDialog.ShowDialog();
                        }
                        break;
                    case DialogResult.Yes:
                        _premissionToConcatenateLists = true;
                        openFileDialog.ShowDialog(); 
                        break;
                }
            }
        }
        
        private void LoadSpeakersFromFile(object sender, CancelEventArgs ar)
        {
            try
            {
                if (!_premissionToConcatenateLists)
                {
                    _speakers = new Speakers();
                    _currentSpeakersId = 0;
                }
                LoadSpeakersFromDocFile(openFileDialog.FileName);
                _settings.LastOpenedListPath = openFileDialog.FileName;
                SaveSettingsSilent();
            }
            catch
            {
                MessageBox.Show("Не удалось открыть файл. Возможно, он поврежден.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveSettingsSilent()
        {
            try
            {
                var savingStream = new FileStream("Settings.bin", FileMode.Create);
                var bf = new BinaryFormatter();
                bf.Serialize(savingStream, _settings);
                savingStream.Close();
            }
            catch { }
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            if (_currentSpeakersId != 0)
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
                SpeakersManager.SaveSpeakers(saveFileDialog.FileName, _speakers);
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
                if ((_timerIsWorked) & (speakersGrid.CurrentCell != null) && (speakersGrid.CurrentCell.Style.BackColor == Color.LightGray))
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
            _cellBellowMouseIndex = e.RowIndex;
        }
              
        private void ContorlsMenuOpening(object sender, CancelEventArgs e)
        {
            if ((speakersGrid.RowCount != 0) & (_speakers.Count() != 0) & (_cellBellowMouseIndex < speakersGrid.RowCount))
            {
                speakersGrid.Rows[_cellBellowMouseIndex].Selected = true;
                speakersGrid.Rows[_cellBellowMouseIndex].Cells[1].Selected = true;
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
            var settingForm = new SettingsForm();
            settingForm.SettingsChanged += ChangeSettings;
            settingForm.ShowDialog();
        }

        private void ChangeSettings(object sender, EventArgs e)
        {
            var temp = (SettingsForm)sender;
            _settings = temp.Settings;
            try
            {
                _sound = new SoundPlayer(_settings.SoundPath);
            }
            catch { }
        }
        
        private void UpdateCurrentTimeTimerTick(object sender, EventArgs e)
        {
            mscTimeLabel.Text = GetCurrentTime();
            if (_lastSecond - DateTime.Now.Second != 0)
            {
                _lastSecond = DateTime.Now.Second;
                if (generalTimer.Enabled || repeatedTimer.Enabled)
                {
                    if (_window1IsCreate)
                    {
                        _fullScreenWindow.UpdateTimerLabelText(remainingTimeStatusLabel.Text);
                    }
                    if (_window2IsCreate)
                    {
                        _bottomWindow.UpdateLabelsText(_currentSpeakersName, remainingTimeStatusLabel.Text);
                    }
                }
                if (waitingTimer.Enabled)
                {
                    if (_window1IsCreate)
                    {
                        _fullScreenWindow.UpdateTimerLabelText("ВРЕМЯ ИСТЕКЛО!");
                    }
                    if (_window2IsCreate)
                    {
                        _bottomWindow.UpdateLabelsText(_currentSpeakersName, remainingTimeStatusLabel.Text);
                    }
                }
            }
            if (_window1IsCreate)
            {
                _fullScreenWindow.UpdateCurrentTimeLabelsText(mscTimeLabel.Text);
            }
            mscTimeLabel.Text = "Текущее время: " + mscTimeLabel.Text;
        }

        private string GetCurrentTime()
        {
            var returnedTime = "";
            if (DateTime.Now.Hour < 10)
            {
                returnedTime += "0";
            }
            returnedTime += Convert.ToString(DateTime.Now.Hour) + " : ";
            if (DateTime.Now.Minute < 10)
            {
                returnedTime += "0";
            }
            returnedTime += Convert.ToString(DateTime.Now.Minute) + " : ";
            if (DateTime.Now.Second < 10)
            {
                returnedTime += "0";
            }
            returnedTime += Convert.ToString(DateTime.Now.Second);
            return returnedTime;
        }

        private void Windos1StateButtonClick(object sender, EventArgs e)
        {
            if (!_window1IsOpen)
            {
                if (!_window1IsCreate)
                {
                    _fullScreenWindow = new FullScreenWindow();
                    _fullScreenWindow.FormClosing += Window1FormClosing;
                    _window1IsCreate = true;
                    window1CurrentTimeLabel.Text = "Нижняя панель развернута";
                    lowPanelStateButton.Image = showHideButtonsImageList.Images[1];
                    _fullScreenWindow.FullScrennWindowDoubleClick(this, null);
                    Windos1StateButtonClick(this, null); 
                }
                var secondaryScreen = MonitorHelper.GetSecondaryScreen();
                _fullScreenWindow.Left = secondaryScreen.WorkingArea.Left;
                _fullScreenWindow.Top = secondaryScreen.WorkingArea.Top;
                _fullScreenWindow.Location = secondaryScreen.WorkingArea.Location;
                _fullScreenWindow.StartPosition = FormStartPosition.Manual;
                _window1IsOpen = true;
                _fullScreenWindow.Show();
                window1Label.Text = "Окно 1 развернуто";
                windows1StateButton.Image = showHideButtonsImageList.Images[1];
            }
            else
            {
                _fullScreenWindow.Hide();
                _window1IsOpen = false;
                window1Label.Text = "Окно 1 свернуто";
                windows1StateButton.Image = showHideButtonsImageList.Images[0];
            }
        }

        private void Window1FormClosing(object sender, FormClosingEventArgs e)
        {
            _window1IsOpen = false;
            _window1IsCreate = false;
            window1Label.Text = "Окно 1 свернуто";
            windows1StateButton.Image = showHideButtonsImageList.Images[0];
            window1CurrentTimeLabel.Text = "Нижняя панель свернута";
            lowPanelStateButton.Image = showHideButtonsImageList.Images[0];
        }

        

        private void LowPanelStateButtonClick(object sender, EventArgs e)
        {
            if (_window1IsOpen)
            {
                if (!_fullScreenWindow.CurrentTimeLabelVisible)
                {
                    _fullScreenWindow.ShowCurrentTimeLabel();
                    window1CurrentTimeLabel.Text = "Нижняя панель развернута";
                    lowPanelStateButton.Image = showHideButtonsImageList.Images[1];
                }
                else
                {
                    _fullScreenWindow.HideCurrentTimeLabel();
                    window1CurrentTimeLabel.Text = "Нижняя панель свернута";
                    lowPanelStateButton.Image = showHideButtonsImageList.Images[0];
                }
            }
        }

        private void Window2StateButtonClick(object sender, EventArgs e)
        {
            if (!_window2IsOpen)
            {
                if (!_window2IsCreate)
                {
                    _bottomWindow = new BottomWindow();
                    _bottomWindow.FormClosing += Window2FormClosing;
                    _window2IsCreate = true;
                    Window2StateButtonClick(this, null);
                }
                var primaryScreen = MonitorHelper.GetPrimaryScreen();
                _bottomWindow.Top = primaryScreen.Bounds.Height-_bottomWindow.Height;
                _bottomWindow.Left = primaryScreen.WorkingArea.Left;
                _bottomWindow.Width = primaryScreen.Bounds.Width;
                _bottomWindow.StartPosition = FormStartPosition.Manual;
                _window2IsOpen = true;
                _bottomWindow.Show();
                window2Label.Text = "Окно 2 развернуто";
                window2StateButton.Image = showHideButtonsImageList.Images[1];
            }
            else
            {
                _window2IsOpen = false;
                _bottomWindow.Hide();
                window2Label.Text = "Окно 2 свернуто";
                window2StateButton.Image = showHideButtonsImageList.Images[0];
            }
        }

        private void Window2FormClosing(object sender, FormClosingEventArgs e)
        {
            _window2IsOpen = false;
            _window2IsCreate = false;
            window2Label.Text = "Окно 2 свернуто";
            window2StateButton.Image = showHideButtonsImageList.Images[0];
        }

        private void StartTimersButtonClick(object sender, EventArgs e)
        {
            if ((_remainingSpeakersTime == 0) || (_speakers.Count() == 0))
            {
                MessageBox.Show(
                    currentSpeakersPerfermanceLabel.Text == "Время выступления: не указано"
                        ? "Задайте время выступления."
                        : "Сначала выберите участника.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!_timerIsWorked)
                {
                    if (speakersGrid.CurrentRow != null)
                    {
                        _currentSpeakersName = _speakers[speakersGrid.CurrentRow.Index].Name;
                        _currentSpeakerGridsRowsIndex = speakersGrid.CurrentRow.Index;
                    }
                    SetSelectColorToCurrenSpeakerCells(Color.LightGray);
                    _timerIsWorked = true;
                    _pause = false;
                    _currentWorkedTimer = 1;
                    _remainingTimersTime = _remainingSpeakersTime;
                    generalTimer.Start();
                    startTimersButton.Image = startButtonImageList.Images[1];
                    toolTip1.SetToolTip(startTimersButton, "Приостановить таймер");
                }
                else
                {
                    if (!_pause)
                    {
                        _pause = true;
                        startTimersButton.Image = startButtonImageList.Images[0];
                        switch (_currentWorkedTimer)
                        {
                            case 1: generalTimer.Stop(); break;
                            case 2: repeatedTimer.Stop(); break;
                        }
                        toolTip1.SetToolTip(startTimersButton, "Запустить таймер");
                    }
                    else
                    {
                        _pause = false;
                        startTimersButton.Image = startButtonImageList.Images[1]; 
                        switch (_currentWorkedTimer)
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
            if (_remainingTimersTime == 0)
            {
                if (_window1IsCreate)
                {
                    _fullScreenWindow.StopWarningTimer();
                    _fullScreenWindow.SetWarningTextToLabel();
                }
                _currentWorkedTimer = 0;
                _repeatedTime = 0;
                waitingTimer.Start();
                generalTimer.Stop();
                _soundThread = new Thread(PlaySoundOnce);
                _soundThread.Start();
            }
            else
            {
                --_remainingTimersTime;
                remainingTimeStatusLabel.Text = ConvertTimeToString(_remainingTimersTime);
                if (_window1IsCreate)
                {
                    if (IsWarningTime())
                    {
                        _fullScreenWindow.StartWarningTimer();
                    }
                    else
                    {
                        _fullScreenWindow.StopWarningTimer();
                        _fullScreenWindow.SetDefaultColorToLabels();
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
                    _sound.Play();
                }
                catch 
                {
                    MessageBox.Show("Не удалось открыть звуковой файл.\r\nВыберите новый звук в настройках.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string ConvertTimeToString(int time)
        {
            var returnedTime = Convert.ToString(time / 60) + " : "; 
            if (time % 60 < 10)
            {
                returnedTime += "0";
            }
            returnedTime += Convert.ToString(time % 60);
            return returnedTime;
        }

        private bool IsWarningTime()
        {
            _warningTime = Convert.ToInt32(warningTimeMinuteComboBox.Text) * 60 + Convert.ToInt32(warningTimeSecondComboBox.Text);
            if ((_warningTime == 0) || (_remainingTimersTime > _warningTime))
            {
                return false;
            }
            return true;
        }

        private void WaitingTimerTick(object sender, EventArgs e)
        {
            if (_repeatedTime < 6)
            {
                ++_repeatedTime;
            }
            else
            {
                if (_window1IsCreate)
                {
                    _fullScreenWindow.SetUsualTextToLabels();
                }
                if (premmisionToRepeatCheckBox.Checked)
                {
                    _remainingTimersTime = Convert.ToInt32(repeatTimeMinuteComboBox.Text) * 60 + Convert.ToInt32(repeatTimeSecondComboBox.Text);
                    _repeatedTime = 0;
                    _currentWorkedTimer = 2;
                    repeatedTimer.Start();
                }
                else
                {
                    if (_window1IsCreate)
                    {
                        _fullScreenWindow.SetWarningTextToLabel();
                        _fullScreenWindow.StartWarningTimer();
                    }
                    //StopTimerButtonClick(this, null);
                }
                waitingTimer.Stop();
                
            }
        }

        private void RepeatedTimerTick(object sender, EventArgs e)
        {
            ++_repeatedTime;
            remainingTimeStatusLabel.Text = ConvertTimeToString(_repeatedTime);
            if (_window1IsCreate)
            {
                _fullScreenWindow.StartRepeatTimer();
            }
            if ( (!_isRepeatSignalPlayed) &&(_remainingTimersTime == _repeatedTime) & (premimisionToSoundCheckBox.Checked))
            {
                _isRepeatSignalPlayed = true;
                _soundThread = new Thread(PlaySoundTwice);
                _soundThread.Start();  
            }
        }

        private void PlaySoundTwice()
        {
            try
            {
                _sound.PlaySync();
                _sound.PlaySync();
            }
            catch
            {
                MessageBox.Show("Не удалось открыть звуковой файл.\r\nВыберите новый звук в настройках.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StopTimerButtonClick(object sender, EventArgs e)
        {
            _currentWorkedTimer = 0;
            _timerIsWorked = false;
            _pause = false;
            _isRepeatSignalPlayed = false;
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
            _sound.Stop();
            if (_window1IsCreate)
            {
                _fullScreenWindow.StopRepeatTimer();
                _fullScreenWindow.StopWarningTimer();
                _fullScreenWindow.SetDefaultColorToLabels();
            }
            if (_window2IsCreate)
            {
                _bottomWindow.FixLabelPosition(this, null);
            }
            InitializeTimers();
            SetSelectColorToCurrenSpeakerCells(Color.White);
            SpeakersGridSelectionChanged(this, null);
        }

        private void AddRaminingTimeButtonClick(object sender, EventArgs e)
        {
            if ((_remainingSpeakersTime == 0) || (_speakers.Count() == 0))
            {
                MessageBox.Show(
                    currentSpeakersPerfermanceLabel.Text == "Время выступления: не указано"
                        ? "Задайте время выступления."
                        : "Сначала выберите участника.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if  (_timerIsWorked)
                {
                    if (repeatedTimer.Enabled)
                    {
                        _remainingTimersTime = Convert.ToInt32(overtimeComboBox.Text) * 60;
                        repeatedTimer.Stop();
                        if (_window1IsCreate)
                        {
                            _fullScreenWindow.StopRepeatTimer();
                            _fullScreenWindow.StopWarningTimer();
                            _fullScreenWindow.SetDefaultColorToLabels();
                        }
                        generalTimer.Start();
                    }
                    else
                    {
                        _remainingTimersTime += Convert.ToInt32(overtimeComboBox.Text) * 60; 
                    }
                }
                else
                {
                    waitingTimer.Stop();
                    if (_window1IsCreate)
                    {
                        _fullScreenWindow.StopRepeatTimer();
                        _fullScreenWindow.StopWarningTimer();
                        _fullScreenWindow.SetUsualTextToLabels();
                        _fullScreenWindow.SetDefaultColorToLabels();
                    }
                    _remainingTimersTime = Convert.ToInt32(overtimeComboBox.Text) * 60;
                    if (speakersGrid.CurrentRow != null)
                    {
                        _currentSpeakersName = _speakers[speakersGrid.CurrentRow.Index].Name;
                        _currentSpeakerGridsRowsIndex = speakersGrid.CurrentRow.Index;
                    }
                    SetSelectColorToCurrenSpeakerCells(Color.LightGray);
                    _pause = false;
                    _timerIsWorked = true;
                    _currentWorkedTimer = 3;
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
                _remainingTimersTime = Convert.ToInt32(repeatTimeMinuteComboBox.Text) * 60 + Convert.ToInt32(repeatTimeSecondComboBox.Text);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
