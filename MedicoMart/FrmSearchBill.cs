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
    public partial class FrmSearchBill : Form
    {
        public FrmSearchBill()
        {
            InitializeComponent();
        }

        DataSet ds_BillMaster, ds_BillDetailsMaster;

        private void Searchbtn_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM BillMaster Where ID=" + textBox1.Text;
            Medico_Conts mc = new Medico_Conts();
            DataSet ds = mc.FetchRecord(query);

            textBox2.Text =ds.Tables[0].Rows[0][1].ToString();
            textBox3.Text = ds.Tables[0].Rows[0][2].ToString();
            EntdateTimePicker1.Text = ds.Tables[0].Rows[0][5].ToString();
            textBox4.Text=ds.Tables[0].Rows[0][4].ToString();

            mc.SelectRecord("select * from BillDetailsMaster Where Billid= '"+ textBox1.Text+"'", SBdataGridView1);

            ds_BillDetailsMaster = mc.FetchRecord("Select [Medicine Name],[Price],[Qty],[Total Price] from BillDetailsMaster where Billid='"+textBox1.Text+"'");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Define page boundaries
            RectangleF printArea = e.PageSettings.PrintableArea;


            //Header information with enhanced styling 
            e.Graphics.DrawString("MedicoMart", new Font("Arial", 24, FontStyle.Bold), Brushes.DarkBlue, new RectangleF(320, printArea.Top, printArea.Width, 50));
            e.Graphics.DrawString("M.G. Road, Centare Point Market, Opp. Axis Bank, Porbandar", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new RectangleF(200, 80, printArea.Width, 30));


            // Decorative separator
            e.Graphics.DrawLine(Pens.Black, new PointF(printArea.Left, 110), new PointF(printArea.Right, 110));

            e.Graphics.DrawString("Name: " + textBox2.Text.Trim(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new PointF(40, 120));
            e.Graphics.DrawString("Date: " + EntdateTimePicker1.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new PointF(printArea.Right -360, 120));

            int x = (int)printArea.Left;
            int y = 160; // start y-coordinate below the header
            int inc = 30;


            // Draw the header for the items table with enhanced styling
            e.Graphics.FillRectangle(Brushes.LightSteelBlue, new RectangleF(x, y, (int)printArea.Width, inc));
            e.Graphics.DrawString("Medicine Name", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new RectangleF(x, y, 200, inc), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("Price", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new RectangleF(x + 300, y, 120, inc), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("Qty", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new RectangleF(x + 500, y, 100, inc), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("Total price", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new RectangleF(x + 650, y, 150, inc), new StringFormat() { Alignment = StringAlignment.Center });

            y += inc;
            e.Graphics.DrawLine(Pens.MidnightBlue, new PointF(printArea.Left, y), new PointF(printArea.Right, y));


            // Iterate through the dataset's rows and print each item's details
            foreach (DataRow row in ds_BillDetailsMaster.Tables[0].Rows)
            {
                y += inc;
                e.Graphics.DrawString(row["Medicine Name"].ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new RectangleF(x, y, 200, inc), new StringFormat() { Alignment = StringAlignment.Center });
                e.Graphics.DrawString(row["Price"].ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new RectangleF(x + 300, y, 100, inc), new StringFormat() { Alignment = StringAlignment.Center });
                e.Graphics.DrawString(row["Qty"].ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new RectangleF(x + 500, y, 100, inc), new StringFormat() { Alignment = StringAlignment.Center });
                e.Graphics.DrawString(row["Total price"].ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new RectangleF(x + 650, y, 150, inc), new StringFormat() { Alignment = StringAlignment.Center });
            

                y += inc;
                e.Graphics.DrawLine(Pens.MidnightBlue, new PointF(printArea.Left, y), new PointF(printArea.Right, y));
            }

            // Footer with enhanced styling
            y += inc;
            e.Graphics.DrawString(" Total Bill Amount : " + textBox4.Text, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new PointF(x + 520, y));
            e.Graphics.DrawString("For, MediCoMart Print:", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new PointF(printArea.Left, y + 30)); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            EntdateTimePicker1.Text = "";
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Frhome back = new Frhome();
            back.Show();
        }

    /*    private void button3_Click(object sender, EventArgs e)
        {
            string query = "update BillMaster set [Customar Name]='" + textBox2.Text + "',[Customar Number]='" + textBox3.Text + "',[Total Price]='"+textBox4.Text+"',[Bill Date]='" + EntdateTimePicker1.Text + "', where Bill No =" + textBox1.Text;
            Medico_Conts mc = new Medico_Conts();
            mc.UpdateRecord(query);
            mc.SelectRecord("select * from BillMaster",SBdataGridView1 );
        }*/
    }
}
