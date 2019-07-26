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
    public partial class NewArtistForm : Form
    {
        public NewArtistForm()
        {
            InitializeComponent();
        }

        private void addArtist_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "") 
            addArtist.DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Ввеідть ім'я виконавця", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
