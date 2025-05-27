using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedicoMart
{
    public partial class Frmlogin : Form
    {
        public Frmlogin()
        {
            InitializeComponent();
        }

        private void Frmlogin_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Admin WHERE [Name]='" + textBox1.Text + "'and[PassWord]='" + textBox2.Text + "'";
            Medico_Conts con = new Medico_Conts();
            DataSet ds = con.isValid(query);

            if (textBox1.Text == "")
            {
                MessageBox.Show("enter Username", "information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (textBox2.Text == "")
            {
                MessageBox.Show("enter Password", "information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {

                if (ds.Tables[0].Rows.Count == 1 )
                {
                    MessageBox.Show("valid User", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    Frhome fh = new Frhome();
                    fh.Show();
                }

                else
                {
                    MessageBox.Show("invalid User", "information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }           
    }        
}