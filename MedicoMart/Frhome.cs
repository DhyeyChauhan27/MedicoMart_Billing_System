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
    public partial class Frhome : Form
    {
        public Frhome()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Stock s = new Stock();
            s.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Billing b = new Billing();
            b.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report r = new Report();
            r.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSearchBill sb = new FrmSearchBill();
            sb.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frmlogin fl = new Frmlogin();
            fl.Show();
        }

      
    }
}
