using QLSHOPQA.CONNECT;
using QLSHOPQA.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSHOPQA.GUI
{
    public partial class THONGKE_DOANHTHU : Form
    {
        connect conn = new connect();
        public THONGKE_DOANHTHU()
        {
            InitializeComponent();
        }
        public DataTable laybang(string connstr)
        {
            DataTable bang = new DataTable();
            try
            {
                conn.ketnoiCN.Open();
                SqlDataAdapter da = new SqlDataAdapter(connstr, conn.ketnoiCN);
                DataSet ds = new DataSet();
                da.Fill(bang);
            }
            catch { bang = null; }
            finally { conn.ketnoiCN.Close(); }
            return bang;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = laybang("select MAHANG, TENHANG,'SL BAN'=(select sum(CTHD.SOLUONG) from CTHD where MAHANG=HH.MAHANG), "
                + "'TONG TIEN'=(select sum(CTHD.THANHTIEN) from CTHD where MAHANG=HH.MAHANG) "
                + "from HANGHOA HH"
                + " WHERE MAHANG IN (SELECT MAHANG FROM CTHD C JOIN HOADON H ON C.MAHD=H.MAHD WHERE MONTH(ngaylap)= and YEAR(ngaylap)=)");
            DoanhThu_Thang rp = new DoanhThu_Thang();
            rp.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = laybang("select MAHANG, TENHANG,'SL BAN'=(select sum(CTHD.SOLUONG) from CTHD where MAHANG=HH.MAHANG), "
                + "'TONG TIEN'=(select sum(CTHD.THANHTIEN) from CTHD where MAHANG=HH.MAHANG)"
                + "from HANGHOA HH"
                + "WHERE (MAHANG IN (SELECT MAHANG FROM CTHD C JOIN HOADON H ON C.MAHD=H.MAHD WHERE (MONTH(ngaylap) between 1 and 3)and YEAR(ngaylap)=2021) AND QUY = 1)"
                + "or (MAHANG IN (SELECT MAHANG FROM CTHD C JOIN HOADON H ON C.MAHD=H.MAHD WHERE (MONTH(ngaylap) between 4 and 6)and YEAR(ngaylap)=2021) AND QUY = 2)"
                + "or (MAHANG IN (SELECT MAHANG FROM CTHD C JOIN HOADON H ON C.MAHD=H.MAHD WHERE (MONTH(ngaylap) between 7 and 9)and YEAR(ngaylap)=2021) AND QUY = 3)"
                + "or (MAHANG IN (SELECT MAHANG FROM CTHD C JOIN HOADON H ON C.MAHD=H.MAHD WHERE (MONTH(ngaylap) between 10 and 12) AND QUY = 4)");
            DoanhThu_Quy rp = new DoanhThu_Quy();
            rp.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = laybang("SELECT HD.MANV,'TENNV'=(SELECT TENNV FROM QLTAIKHOAN WHERE MANV=HD.MANV),HD.NGAYLAP,HD.TONGTIEN"
                + "FROM HOADON HD");
            DoanhThu_NV rp = new DoanhThu_NV();
            rp.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rp;
        }
    }
}
