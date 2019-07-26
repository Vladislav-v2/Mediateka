using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mediateka
{
    public partial class AddSound : Form
    {
        public AddSound()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool b = true;

            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Нема назви композиції", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                b = false;
                return;
            }
            if (txtLeng.Text.Trim() == ":")
            {
                MessageBox.Show("Тривалість невірна", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                b = false;
                return;
            }
            if (txtSize.Text.Trim() == "")
            {
                MessageBox.Show("Обсяг файлу невірний", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                b = false;
                return;
            }
            TimeSpan t = new TimeSpan();
            try
            {
                t = TimeSpan.Parse(txtLeng.Text);
            }
            catch(System.FormatException)
            {
                MessageBox.Show("Невірна тривалісь копмозиції", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                b = false;
                return;
            }
            catch(System.OverflowException)
            {
                MessageBox.Show("Невірна тривалісь копмозиції", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                b = false;
                return;
            }
            if (b) button1.DialogResult = DialogResult.OK;

        }
    }
}
