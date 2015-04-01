using System;
using System.Windows.Forms;
using Timer.Models;

namespace Timer.SpeakerList
{
    /// <summary>
    /// Форма для редактирования данных спикера
    /// </summary>
    public partial class EditForm : Form
    {
        /// <summary>
        /// Признак редактирования
        /// </summary>
        public bool IsEdit { get; set; }

        /// <summary>
        /// Форма для редактирования данных спикера
        /// </summary>
        public EditForm(Speaker editedSpeaker)
        {
            InitializeComponent();
            IsEdit = false;
            nameOfSpeakerTextBox.Text = editedSpeaker.Name;
            perfomanceTextBox.Text = editedSpeaker.PerfermanceStr;
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            int minutes;
            if (!int.TryParse(perfomanceTextBox.Text, out minutes))
            {
                MessageBox.Show("Неверный формат времени.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                perfomanceTextBox.Focus();
            }
            else
            {
                IsEdit = true;
                Close();
            }
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void TextBoxKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OkButtonClick(this, null);
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
