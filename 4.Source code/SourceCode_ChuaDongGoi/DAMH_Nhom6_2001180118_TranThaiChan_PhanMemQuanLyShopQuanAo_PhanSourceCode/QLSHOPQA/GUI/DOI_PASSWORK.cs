using QLSHOPQA.BUS;
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
    public partial class DOI_PASSWORK : Form
    {
        public static string TenDN;
        public static string manv;
        NHANVIENBUS nvbus = new NHANVIENBUS();
        connect cn = new connect();

        public DOI_PASSWORK()
        {
            InitializeComponent();
            textBox1.Text = TenDN;
            textBox1.ReadOnly = true;
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
            if (KTDN(textBox1.Text, textBox2.Text) == false)
            {
                MessageBox.Show("Mật khẩu sai, vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Text = "";
                textBox2.Focus();
                return;
            }
            if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("Mật khẩu không trùng khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Text = "";
                textBox4.Focus();
                return;
            }

            NHANVIEN nv = new NHANVIEN();
            nv.MatKhau = textBox4.Text.ToString();
            if (MessageBox.Show("Bạn có muốn đổi mật khẩu không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                nvbus.UpdateMATKHAU(nv, manv);
                MessageBox.Show("Thành công!");
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }
    }
}
