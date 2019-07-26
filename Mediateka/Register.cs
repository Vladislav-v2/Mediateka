using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mediateka
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 frmLogin = new Form1();
            frmLogin.Show();
            this.Hide();
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();
            string name = textBox1.Text.Trim(),
                   pass = textBox2.Text.Trim();
            if (textBox2.Text.Length < 5)
            {
                MessageBox.Show("Слабий пароль", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (name != "" && name != "admin" && pass != "")
            {
                sqlParam.Add(new SqlParameter("Username", name));
                sqlParam.Add(new SqlParameter("Password", pass));           
                DAL.ExecSP("CreateUser", sqlParam);
                MessageBox.Show("Користувач створений", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else MessageBox.Show("Невірні дані", null, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
