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
    public partial class AddNewGenre : Form
    {
        public AddNewGenre()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
               MessageBox.Show("Введіть ім'я автора", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else AddBtn.DialogResult = DialogResult.OK;
        }
    }
}
