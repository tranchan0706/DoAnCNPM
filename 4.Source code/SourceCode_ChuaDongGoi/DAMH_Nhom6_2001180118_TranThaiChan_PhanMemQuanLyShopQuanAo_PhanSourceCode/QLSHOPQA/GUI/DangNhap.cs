using QLSHOPQA.CONNECT;
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
    public partial class DangNhap : Form
    {
        connect cn = new connect();
        public DangNhap()
        {
            InitializeComponent();
            textBox1.Focus();
        }

        public bool KTDN(string TK, string MK)
        {
            try
            {
                cn.ketnoiCN.Open();
                string CauLenh = "DECLARE	@return_value int EXEC	@return_value = [dbo].[sp_KiemTraDangNhap] "
                      + " @tk = N'" + TK + "',@mk = N'" + MK + "' SELECT	'Return Value' = @return_value";
                SqlCommand cmd = new SqlCommand(CauLenh, cn.ketnoiCN);
                object value = cmd.ExecuteScalar();
                cn.ketnoiCN.Close();
                int kq = int.Parse(value.ToString());
                if (kq == 1)
                {
                    return true;
                }
                else
                    return false;
            }
            catch { return false; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (KTDN(textBox1.Text, textBox2.Text) == true)
            {
                MessageBox.Show("Thành công");
                // Truyên biến chức vụ
                cn.ketnoiCN.Open();
                string str1 = "declare @chucvu nvarchar(10) exec sp_TimChucVu '" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "', @chucvu output";
                string chucvu = cn.GetFieldValues(str1);
                TrangChu.user = chucvu;
                QL_SANPHAM.user = chucvu;
                QL_KHACHHANG.user = chucvu;
                QL_HOADON.user = chucvu;
                QL_HOADONNHAP.user = chucvu;
                QL_NCC.user = chucvu;
                QL_NHANVIEN.user = chucvu;
                //Truyền mã nhân viên
                string str2 = "SELECT MANV FROM QLTAIKHOAN WHERE TENTK = '" + textBox1.Text.Trim() + "' AND MATKHAU='" + textBox2.Text.Trim() + "'";
                string manv = cn.GetFieldValues(str2);
                QL_HOADON.MaNhanVien = manv;
                QL_HOADONNHAP.MaNhanVien = manv;
                QL_KHACHHANG.manv = manv;
                DOI_PASSWORK.manv = manv;
                //Truyền Tên ĐN
                DOI_PASSWORK.TenDN = textBox1.Text;
                cn.ketnoiCN.Close();

                TrangChu f = new TrangChu();
                f.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại!");
                textBox1.Focus();
                textBox2.Text = "";
                textBox1.Text = "";
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Ban muon thoat chuong trinh?", "Canh Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
