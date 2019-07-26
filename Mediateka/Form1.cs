using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Mediateka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = textBox2.Text = "admin";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<SqlParameter> validLogin = new List<SqlParameter>();
            validLogin.Add(new SqlParameter("@login", textBox1.Text.Trim()));
            validLogin.Add(new SqlParameter("@pasword", textBox2.Text.Trim()));
            DataTable dtLoginResult = DAL.ExecSP("ValidLogin", validLogin);

            if (dtLoginResult.Rows.Count == 1)
            {
                string role = dtLoginResult.Rows[0]["id"].ToString();


                 FormAdmin frm = new FormAdmin();              
                 frm.login.Text = "Привіт, "+textBox1.Text;
                 frm.Show();
                 this.Hide();                
            }
            else
            {
                MessageBox.Show("Невірно введений пароль або логін!!", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register frmReg = new Register();
            frmReg.Show();
            this.Hide(); 
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
