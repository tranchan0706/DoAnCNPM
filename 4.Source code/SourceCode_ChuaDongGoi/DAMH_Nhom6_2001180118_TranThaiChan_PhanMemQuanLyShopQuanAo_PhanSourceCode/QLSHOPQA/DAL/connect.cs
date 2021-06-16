using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSHOPQA.CONNECT
{
    class connect
    {
        public connect() { }
        public SqlConnection conn;
        //public SqlCommand cmd;

        string strketnoi1 = "Data Source=.;Initial Catalog=QL_SHOPQA;Integrated Security=True";
        public SqlConnection ketnoiCN = new SqlConnection("Data Source=.;Initial Catalog=QL_SHOPQA;Integrated Security=True");

        public void Openconnect()
        {

            string ketnoi1 = strketnoi1;

            conn = new SqlConnection(strketnoi1);
            conn.Open();
        }
        public void Closeconnect()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
        public void query1(string query)
        {
            Openconnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            Closeconnect();
        }

        public DataTable returnquery(string query)
        {
            Openconnect();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable tb = new DataTable();
            da.Fill(tb);
            Closeconnect();
            return tb;
        }
        public DataTable taobang(string sql)
        {
            Openconnect();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
            Closeconnect();
            return dt;
        }

        // ========================Function============================
        public DataTable GetDataToTable(string sql)
        {

            SqlDataAdapter MyData = new SqlDataAdapter(sql, conn);
            DataTable table = new DataTable();
            MyData.Fill(table);
            return table;
        }
        public void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            Openconnect();
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma; //Trường giá trị
            cbo.DisplayMember = ten; //Trường hiển thị
            Closeconnect();
        }
        public string GetFieldValues(string sql)
        {
            Openconnect();
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            return ma;

        }
        public bool CheckKey(string sql)
        {
            SqlDataAdapter MyData = new SqlDataAdapter(sql, conn);
            DataTable table = new DataTable();
            MyData.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public String Cat_link_anh(string link)
        {
            //int vt = link.IndexOf("Image");
            //string cat = link.Substring(vt);
            //return cat;
            string[] arChar = { "\\" };
            string[] arrListStr = link.Split(arChar, StringSplitOptions.None);
            return arrListStr.Last();
        }
    }
}
