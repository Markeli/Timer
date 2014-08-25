using System;
using System.Windows.Forms;

namespace timer
{
    public partial class addForm : Form
    {
        public bool isAdded;
        public Speaker newSpeaker;

        public addForm()
        {
            InitializeComponent();
            isAdded = false;
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
                newSpeaker = new Speaker(0, nameOfSpeakerTextBox.Text, perfomanceTextBox.Text);
                isAdded = true;
                Close();
            }
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }
        
        private void NameOfSpeakerTextBoxKeyDown(object sender, KeyEventArgs e)
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

        private void PerfomanceTextBoxKeyDown(object sender, KeyEventArgs e)
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
