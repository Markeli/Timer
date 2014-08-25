using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace timer
{
    public partial class SettingsForm : Form
    {
        public EventHandler settingsIsChanged;
        public Settings settings;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsFormLoad(object sender, EventArgs e)
        {
            LoadSettings();
        }

        public void LoadSettings()
        {
            settings = new Settings();
            try
            {
                FileStream savingStream = new FileStream("Settings.bin", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                settings = (Settings)bf.Deserialize(savingStream);
                savingStream.Close();
                string[] temp = settings.SoundsLoaction.Split('\\');
                signalNameLabel.Text = temp[temp.Length - 1];
                loadLastOpenedListOnStartCheckBox.Checked = settings.LoadRecentlyOpenedFileOnStart;
            }
            catch
            {
                MessageBox.Show("Файл Settings.bin не найден или поврежден. \r\nБудут восстановлены стандартные настройки", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                settings.SetDefaultSettings();
                string[] temp = settings.SoundsLoaction.Split('\\');
                signalNameLabel.Text = temp[temp.Length - 1];
                loadLastOpenedListOnStartCheckBox.Checked = settings.LoadRecentlyOpenedFileOnStart;
                SaveSettings();
            }
        }

        public void SaveSettings()
        {
            try
            {
                FileStream savingStream = new FileStream("Settings.bin", FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(savingStream, settings);
                savingStream.Close();
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

        private void okButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName != "")
            {
                settings.SoundsLoaction = openFileDialog1.FileName;
            }
            settings.LoadRecentlyOpenedFileOnStart = loadLastOpenedListOnStartCheckBox.Checked;
            SaveSettings();
            settingsIsChanged(this, null);
            Close();
        }

        private void OpenSoundButtonClick(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void OpenFileDialog1FileOk(object sender, CancelEventArgs e)
        {
            string[] temp = openFileDialog1.FileName.Split('\\');
            signalNameLabel.Text = temp[temp.Length-1];

        }
    }
}
