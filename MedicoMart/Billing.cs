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
    public partial class Billing : Form
    {
        public Billing()
        {
            InitializeComponent();

            billingdataGridView2.Columns.Add("Medicine Name", "Medicine Name"); 
            billingdataGridView2.Columns.Add("Price", "Price"); 
            billingdataGridView2.Columns.Add("Qty", "Qty"); 
            billingdataGridView2.Columns.Add("Total Price", "Total Price");
            billingdataGridView2.Columns.Add("Bill Date", "Bill Date");
        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
          
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            EntdateTimePicker1.Text = "";
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Frhome back = new Frhome();
            back.Show();
        }

        private void textBox8_KeyUp(object sender, KeyEventArgs e)
        {
            string query = "select [Medicine Name],[Price] from [stockinfo] where [Medicine Name] like '%" + textBox8.Text + "%'  or [Price] like '%" + textBox8.Text + "%'";

            Medico_Conts mc = new Medico_Conts();
            mc.SelectRecord(query, stockdataGridView1);
        }

        private void Billing_Load(object sender, EventArgs e)
        {
            Medico_Conts mc = new Medico_Conts();
            mc.SelectRecord("select [Medicine Name],[Price] from [stockinfo]", stockdataGridView1);
        }

        private void stockdataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = stockdataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox6.Text = stockdataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            DataGridViewRow newRow = null;
            foreach (DataGridViewRow row in stockdataGridView1.SelectedRows)
            {
                newRow = (DataGridViewRow)row.Clone();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    newRow.Cells[cell.ColumnIndex].Value = cell.Value;
                }
                billingdataGridView2.Rows.Add(newRow);
            }
            newRow.Cells[2].Value=textBox5.Text;
            newRow.Cells[3].Value= int.Parse(textBox5.Text)*int.Parse(textBox6.Text);
            newRow.Cells[4].Value = EntdateTimePicker1.Text;

            
            double total = 0;

            foreach (DataGridViewRow row in billingdataGridView2.Rows)
            {
                total += int.Parse(row.Cells[3].Value.ToString());
            }
            textBox7.Text = total.ToString();
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO BillMaster ([Customar Name],[Customar Number],[Medicine Name],[Total Price],[Bill Date]) VALUES ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox7.Text + "','" + EntdateTimePicker1.Text + "')";

            Medico_Conts mc = new Medico_Conts();
            int BillNumber = mc.InsertRecord(query);
            MessageBox.Show("Your Bill Number :" + BillNumber);

            foreach (DataGridViewRow row in billingdataGridView2.Rows)
            {
                DataGridViewRow newRow = (DataGridViewRow)row.Clone();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    newRow.Cells[cell.ColumnIndex].Value = cell.Value;
                }

                string query1 = "INSERT INTO [BillDetailsMaster] ([Billid],[Medicine Name],[price],[Qty],[Total Price],[Bill Date]) VALUES ('" + BillNumber + "','" + newRow.Cells[0].Value + "','" + newRow.Cells[1].Value + "','" + newRow.Cells[2].Value + "','" + newRow.Cells[3].Value + "','"+ newRow.Cells[4].Value +"')";
                MessageBox.Show("Your Bill Number Details :" + BillNumber);

                mc.InsertRecord(query1);
            }
        }

        private void textBox9_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                float discount = ((float.Parse(textBox7.Text) * float.Parse(textBox9.Text)) / 100);
                float BillAmount = float.Parse(textBox7.Text) - discount;
                textBox1.Text = BillAmount.ToString();
            }
            catch
            {
                textBox1.Text = textBox7.Text;
            }
        }
    }
}