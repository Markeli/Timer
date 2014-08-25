using System;
using System.Windows.Forms;

namespace timer
{
    public partial class editForm : Form
    {
        public bool isEdit;

        public editForm(Speaker editedSpeaker)
        {
            InitializeComponent();
            isEdit = false;
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
                isEdit = true;
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
