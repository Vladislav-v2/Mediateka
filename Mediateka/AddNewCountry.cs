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
    public partial class AddNewCountry : Form
    {
        public AddNewCountry()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim()=="")
                MessageBox.Show("Введіть назву країни", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else button1.DialogResult = DialogResult.OK;
        }
    }
}
