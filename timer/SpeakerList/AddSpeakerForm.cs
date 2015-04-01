using System;
using System.Windows.Forms;
using Timer.Models;

namespace Timer.SpeakerList
{
    /// <summary>
    /// Форма для добавления нового спикера в список
    /// </summary>
    public partial class AddSpeakerForm : Form
    {
        /// <summary>
        /// Флаг добавления спикера
        /// </summary>
        public bool IsAdded { get; set; }

        /// <summary>
        /// Спикер, которое добавили
        /// </summary>
        public Speaker Speaker { get; set; }

        /// <summary>
        /// Форма для добавления нового спикера в список
        /// </summary>
        public AddSpeakerForm()
        {
            InitializeComponent();
            IsAdded = false;
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
                Speaker = new Speaker(0, nameOfSpeakerTextBox.Text, perfomanceTextBox.Text);
                IsAdded = true;
                Close();
            }
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Обработчик нажатия клавиш в TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
