using QLSHOPQA.CONNECT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QLSHOPQA.GUI
{
    public partial class BIEUDO : Form
    {
        DataTable bd;
        connect cn = new connect();
        public BIEUDO()
        {
            InitializeComponent();
        }

        private void BIEUDO_Load(object sender, EventArgs e)
        {
            fillChart();
            napvaolistview();
            anh();
        }

        private void fillChart()
        {
            string sql;
            sql = "select MONTH(NGAYLAP),sum(Soluong) from HOADON,CTHD where HOADON.MaHD = CTHD.MaHD group by MONTH(NGAYLAP)";
            bd = cn.returnquery(sql);
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "tháng";
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Soluong";
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            for (int i = 0; i < bd.Rows.Count; i++)
            {
                chart1.Series["Số Lượng"].Points.AddXY(bd.Rows[i][0], bd.Rows[i][1]);
                chart1.Series[0].ChartType = SeriesChartType.Pie;
            }
        }
        private void napvaolistview()
        {
            listView1.Items.Clear();
            string sql;
            sql = "select MONTH(NGAYLAP),COUNT(HOADON.MaHD),COUNT(Mahang),sum(Soluong),SUM(Tongtien) from HOADON,CTHD where HOADON.MaHD = CTHD.MaHD group by MONTH(NGAYLAP)";
            DataTable nodecha = new DataTable();
            nodecha = cn.returnquery(sql);

            foreach (DataRow dwr in nodecha.Rows)
            {
                ListViewItem lvw = new ListViewItem();
                lvw.Text = dwr[0].ToString();
                lvw.SubItems.Add(dwr[1].ToString());
                lvw.SubItems.Add(dwr[2].ToString());
                lvw.SubItems.Add(dwr[3].ToString());
                lvw.SubItems.Add(dwr[4].ToString());
                listView1.Items.Add(lvw);
            }
            cn.GetFieldValues(sql);
        }
        private void anh()
        {
            string sql = "SELECT Anh,SUM(dh.Soluong) FROM (HANGHOA as nv INNER JOIN CTHD as dh ON nv.Mahang = dh.Mahang) INNER JOIN HOADON as ct ON ct.MaHD=dh.MaHD GROUP BY Anh having SUM(dh.Soluong) >= all (SELECT SUM(h.Soluong) FROM (HANGHOA as v INNER JOIN CTHD as h ON v.Mahang = h.Mahang) INNER JOIN HOADON as t ON t.MaHD=h.MaHD GROUP BY Anh)";
            txtAnh.Text = cn.GetFieldValues(sql);
            picAnh.Image = Image.FromFile( txtAnh.Text);
            string sql2 = "SELECT SUM(dh.Soluong) FROM (HANGHOA as nv INNER JOIN CTHD as dh ON nv.Mahang = dh.Mahang) INNER JOIN HOADON as ct ON ct.MaHD=dh.MaHD GROUP BY Anh having SUM(dh.Soluong) >= all (SELECT SUM(h.Soluong) FROM (HANGHOA as v INNER JOIN CTHD as h ON v.Mahang = h.Mahang) INNER JOIN HOADON as t ON t.MaHD=h.MaHD GROUP BY Anh)";
            label4.Text = cn.GetFieldValues(sql2);
        }
    }
}
