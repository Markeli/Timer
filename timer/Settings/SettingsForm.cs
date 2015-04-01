using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Timer.Settings
{
    /// <summary>
    /// Форма для управления настройками
    /// </summary>
    public partial class SettingsForm : Form
    {
        public EventHandler SettingsChanged;
        public Settings Settings;

        /// <summary>
        /// Форма для управления настройками
        /// </summary>
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsFormLoad(object sender, EventArgs e)
        {
            LoadSettings();
        }

        /// <summary>
        /// Загружает настройки
        /// </summary>
        public void LoadSettings()
        {
           Settings settings;
            try
            {
                settings = SettingsManager.LoadSettings();
                SignalNameL.Text = Path.GetFileName(settings.SoundPath);
                LoadLastOpenedListOnStartChB.Checked = settings.LoadRecentlyOpenedFileOnStart;
            }
            catch
            {
                MessageBox.Show("Файл Settings.bin не найден или поврежден. \r\nБудут восстановлены стандартные настройки", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                settings = SettingsManager.GetDefaultSettings();
                SignalNameL.Text = Path.GetFileName(settings.SoundPath);
                LoadLastOpenedListOnStartChB.Checked = settings.LoadRecentlyOpenedFileOnStart;
                SaveSettings();
            }
        }

        /// <summary>
        /// Сохраняет настройки
        /// </summary>
        public void SaveSettings()
        {
            try
            {
                SettingsManager.SaveSettings(Settings);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void СancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName != "")
            {
                Settings.SoundPath = openFileDialog1.FileName;
            }
            Settings.LoadRecentlyOpenedFileOnStart = LoadLastOpenedListOnStartChB.Checked;
            SaveSettings();
            SettingsChanged(this, null);
            Close();
        }

        private void OpenSoundButtonClick(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void OpenFileDialog1FileOk(object sender, CancelEventArgs e)
        {
            SignalNameL.Text = Path.GetFileName(openFileDialog1.FileName);
        }
    }
}
