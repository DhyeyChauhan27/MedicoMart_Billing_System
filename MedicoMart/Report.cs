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
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Frhome back = new Frhome();
            back.Show();
        }

        private void Searchbtn_Click(object sender, EventArgs e)
        {
            string query;
            DateTime from = EndateTimePicker1.Value;
            DateTime to = ExdateTimePicker2.Value;

            query = "SELECT * FROM BillMaster WHERE Bill Date BETWEEN #" + from.ToString() + "# AND #" + to.ToString() + "#";
            Medico_Conts mc = new Medico_Conts();
            mc.SelectRecord(query, dataGridView1);
        }

        private void ExdateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
