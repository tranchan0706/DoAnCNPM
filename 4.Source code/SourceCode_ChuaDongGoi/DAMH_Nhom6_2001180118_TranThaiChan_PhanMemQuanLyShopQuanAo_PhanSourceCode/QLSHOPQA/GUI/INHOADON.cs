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
    public partial class INHOADON : Form
    {
        connect conn = new connect();

        public INHOADON()
        {
            InitializeComponent();
        }
        public INHOADON(string mahd)
        {
            InitializeComponent();
            label1.Text = mahd;
        }
        private void THONGKE_BAOCAO_Load(object sender, EventArgs e)
        {
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
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = laybang("select H.mahd,NV.TENNV,HH.MAHANG,HH.TENHANG,h.makh,c.soluong,c.thanhtien " +
                "   from HOADON h join CTHD c on h.MAHD=c.MAHD "+
                "	JOIN HANGHOA HH ON HH.MAHANG = C.MAHANG JOIN QLTAIKHOAN NV ON HD.MANV=NV.MANV" +
                "	where c.MAHD=");
            ThongKeHD rp = new ThongKeHD();
            rp.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rp;
        }
    }
}
