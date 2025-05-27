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
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            Updatebtn.Enabled = false;
            Deletebtn.Enabled = false;
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            string query = "Insert into [stockinfo] ([Medicine Name],[Company Name],[Qty],[Price],[Dealer Name],[Dealer No],[Endate],[Exdate]) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + EndateTimePicker1.Text + "','" + ExdateTimePicker2.Text + "')";
            Medico_Conts  mc=new Medico_Conts();
            mc.InsertRecord(query);
            mc.SelectRecord("select * from [stockinfo]",stockdataGridView1);

          
        }

        private void Selectbtn_Click(object sender, EventArgs e)
        {
            Medico_Conts mc = new Medico_Conts();
            mc.SelectRecord("select * from [stockinfo]", stockdataGridView1);
        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            string query = "update [stockinfo] set [Medicine Name]='" + textBox1.Text + "',[Company Name]='" + textBox2.Text + "',[Qty]='" + textBox3.Text + "',[Price]='" + textBox4.Text + "',[Dealer Name]='" + textBox5.Text + "',[Dealer No]='" + textBox6.Text + "',[Endate]='" + EndateTimePicker1.Text + "',[Exdate]='" + ExdateTimePicker2.Text + "' where id =" + ID.Text;
            Medico_Conts mc = new Medico_Conts();
            mc.UpdateRecord(query);
            mc.SelectRecord("select * from [stockinfo]", stockdataGridView1);

              Addbtn.Enabled = false;
              Deletebtn.Enabled = false;
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {

            string query = "delete from [stockinfo] where id =" + ID.Text;
            Medico_Conts mc = new Medico_Conts();
            mc.DeleteRecord(query);
            mc.SelectRecord("select * from [stockinfo]", stockdataGridView1);
        }
        
        private void Searchbtn_Click(object sender, EventArgs e)
        {
            Medico_Conts mc = new Medico_Conts();
            mc.SelectRecord("select * from [stockinfo]", stockdataGridView1);
        }

     
        private void stockdataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID.Text = stockdataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = stockdataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = stockdataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = stockdataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = stockdataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox5.Text = stockdataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox6.Text = stockdataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            EndateTimePicker1.Text = stockdataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            ExdateTimePicker2.Text = stockdataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

            Addbtn.Enabled = false;
            Updatebtn.Enabled = true;
            Deletebtn.Enabled = true;
        }

        private void textBox7_KeyUp(object sender, KeyEventArgs e)
        {
            string query = "select * from [stockinfo] where [Medicine Name] like '%" + textBox7.Text + "%' or [Company Name] like '%" + textBox7.Text + "%' or [Qty] like '%" + textBox7.Text + "%' or [Price] like '%" + textBox7.Text + "%' or [Dealer Name] like '%" + textBox7.Text + "%' or [Dealer No] like '%" + textBox7.Text + "%' or [Endate] like '%" + textBox7.Text + "%' or [Exdate] like '%" + textBox7.Text + "%'";

            Medico_Conts mc = new Medico_Conts();
            mc.SelectRecord(query, stockdataGridView1);
        }


        private void Resetbtn_Click(object sender, EventArgs e)
        {
            Addbtn.Enabled = true;
            Updatebtn.Enabled = false;
            Selectbtn.Enabled = true;
            Deletebtn.Enabled = false;
        }


        private void Clearbtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            EndateTimePicker1.Text = "";
            ExdateTimePicker2.Text = "";
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Frhome back = new Frhome();
            back.Show();
        }
    }
}
