using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;
using System.Text;

namespace MedicoMart
{
    class Medico_Conts
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataAdapter da;
        public static DataSet ds;

        public Medico_Conts()
        {
            try
            {
                con = new OleDbConnection();
                con.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Lenovo\\OneDrive\\Documents\\Visual Studio 2010\\Projects\\MedicoMart\\MedicoMart\\bin\Debug\\MedicoMart.mdb";
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),"error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public int InsertRecord(string Query)
        {
            int LastInsertedId = 0;
            try
            {
                cmd = new OleDbCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = Query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT @@IDENTITY";
                LastInsertedId = Convert.ToInt32(cmd.ExecuteScalar());
                MessageBox.Show("Record save", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return LastInsertedId;
        }

        public void UpdateRecord(string Query)
        {
            try
            {
                cmd = new OleDbCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = Query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Update", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteRecord(string Query)
        {
            try
            {
                cmd = new OleDbCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = Query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Delete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SelectRecord(string Query, DataGridView gw)
        {
            try
            {
                da = new OleDbDataAdapter(Query, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gw.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SelectCombo(string Query, ComboBox gv, string FieldName)
        {
            try
            {
                da = new OleDbDataAdapter(Query, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gv.DataSource = ds.Tables[0];
                gv.ValueMember = FieldName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataSet FetchRecord(string Query)
        {
            DataSet ds =new DataSet();
            da = new OleDbDataAdapter(Query, con);
            da.Fill(ds);
            return ds;
        }


        public DataSet isValid(string Query)
        {
            DataSet ds = new DataSet();
            try
            {
                da = new OleDbDataAdapter(Query, con);
                da.Fill(ds);
                Medico_Conts.ds = ds;       
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            return ds;
        }
    }
}
