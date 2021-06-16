using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSHOPQA.GUI
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
            button1.Text = user;
        }
        public static string user;

        private void sAToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            if (button1.Text == "THỦ KHO")
            {
                hóaĐơnBánToolStripMenuItem.Enabled = false;
                kHÁCHHÀNGToolStripMenuItem1.Enabled = false;
                tHỐNGKÊToolStripMenuItem.Enabled = false;
                nHÂNVIÊNToolStripMenuItem1.Enabled = false;
                tHỐNGKÊToolStripMenuItem.Enabled = false;
            }
            else if (button1.Text == "NHÂN VIÊN")
            {
                hóaĐơnNhậpToolStripMenuItem.Enabled = false;    
                tHỐNGKÊToolStripMenuItem.Enabled = false;
                nHÂNVIÊNToolStripMenuItem1.Enabled = false;
                nHÀCUNGCẤPToolStripMenuItem.Enabled = false;
                tHỐNGKÊToolStripMenuItem.Enabled = false;
            }
        }

        private void TrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Ban muon thoat chuong trinh?", "Canh Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.QL_SANPHAM frm = new QL_SANPHAM();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void kHÁCHHÀNGToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GUI.QL_KHACHHANG frm = new QL_KHACHHANG();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                DangNhap f = new DangNhap();
                f.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString();
        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.QL_HOADON frm = new QL_HOADON();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void tHỐNGKÊToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.THONGKE_DOANHTHU frm = new THONGKE_DOANHTHU();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void nHÀCUNGCẤPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.QL_NCC frm = new QL_NCC();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void nHÂNVIÊNToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GUI.QL_NHANVIEN frm = new QL_NHANVIEN();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void tÌMKIẾMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.DOI_PASSWORK frm = new DOI_PASSWORK();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void bIỂUĐỒToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void hóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.QL_HOADONNHAP frm = new QL_HOADONNHAP();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void thốngKêTheoThángToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.BIEUDO frm = new GUI.BIEUDO();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void thốngKêTheoDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.XtraForm frm = new GUI.XtraForm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

    }
}
