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
    public partial class QL_HOADONNHAP : Form
    {
        PHIEUNHAPBUS phieunhapbus = new PHIEUNHAPBUS();
        CTNHAPHANGBUS ctnhaphangbus = new CTNHAPHANGBUS();
        NCCBUS nccbus = new NCCBUS();
        connect cn = new connect();
        public static string MaNhanVien;
        public static string user;

        public QL_HOADONNHAP()
        {
            InitializeComponent();
        }

        private void QL_HOADONNHAP_Load(object sender, EventArgs e)
        {
            label1.Text = user;
            textBox1.Text = MaNhanVien;
            textBox1.ReadOnly = true;
            txtMaNhanVien.ReadOnly = true;
            txtSoluong.Focus();
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            txtNgaynhap.ReadOnly = true;
            btnInhoadon.Enabled = false;
            txtMaHDBan.ReadOnly = true;
            txtTennhanvien.ReadOnly = true;
            txtTenncc.ReadOnly = true;
            txtTenhang.ReadOnly = true;
            txtDongiaban.ReadOnly = true;
            txtThanhtien.ReadOnly = true;
            txtTongtien.ReadOnly = true;
            txtTongtien.Text = "0";

            //load combobox
            cn.FillCombo("SELECT MANCC, TENCC FROM NHACUNGCAP", cboMancc, "MANCC", "MANCC");
            cboMancc.SelectedIndex = -1;
            cn.FillCombo("SELECT MAHANG, TENHANG FROM HANGHOA", cboMahang, "MAHANG", "MAHANG");
            cboMahang.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUI.QL_NCC frm = new QL_NCC();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void cboMancc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMancc.Text == "")
                txtTenncc.Text = "";
            // Khi chọn Mã nhà cung cấp thì tên NCC tự động hiện ra
            str = "Select TENCC from NHACUNGCAP where MANCC =N'" + cboMancc.SelectedValue + "'";
            txtTenncc.Text = cn.GetFieldValues(str);
        }

        private void ResetValues()
        {
            txtMaHDBan.Text = "";
            cboMancc.Text = "";
            txtTongtien.Text = "0";
            cboMahang.Text = "";
            txtSoluong.Text = "";
            txtThanhtien.Text = "0";
            cboMancc.Text = "";
            txtTenncc.Text = "";
        }
        private void ResetValuesHang()
        {
            cboMahang.Text = "";
            txtSoluong.Text = "";
            txtThanhtien.Text = "0";
            if (cboMahang.Text == "")
            {
                txtTenhang.Text = "";
                txtDongiaban.Text = "";
                txtTon.Text = "";
            }
        }

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnInhoadon.Enabled = false;
            btnThemmoi.Enabled = false;
            ResetValues();
            ResetValuesHang();
            DataGridView.DataSource = null;
            // tạo số phiêu tự động    
            cn.ketnoiCN.Open();
            string CauLenh = "declare @sophieu char(5) exec @sophieu= DBO.AUTO_IDPN select @sophieu";
            SqlCommand cmd = new SqlCommand(CauLenh, cn.ketnoiCN);
            object value = cmd.ExecuteScalar();
            txtMaHDBan.Text = value.ToString();
            cn.ketnoiCN.Close();
        }

        private bool ktratxt()
        {
            // kiểm tra nhập thông tin hàng hóa
            if (cboMahang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMahang.Focus();
                return false;
            }
            if ((txtSoluong.Text.Trim().Length == 0) || (txtSoluong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return false;
            }
            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            int tong, Tongmoi;
            sql = "SELECT SOPHIEU FROM PHIEUNHAPHANG WHERE SOPHIEU= '" + txtMaHDBan.Text + "'";
            //Số phiếu chưa có, tiến hành lập phiếu mới
            if (cn.CheckKey(sql) == false)
            {
                if (ktratxt() == false) { return; }
                else
                {
                    // lập Phiếu
                    // kiểm tra nhập thông tin nhà cung cấp
                    if (cboMancc.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cboMancc.Focus();
                        return;
                    }
                    // Số phiếu được sinh tự động do đó không có trường hợp trùng khóa
                    PHIEUNHAP PN = new PHIEUNHAP();
                    PN.TONGTIEN1 = Convert.ToInt32(txtThanhtien.Text.ToString());
                    PN.MANV1 = textBox1.Text.ToString();
                    PN.MANCC1 = cboMancc.Text.ToString();
                    phieunhapbus.InsertPHIEUNHAP(PN);
                    
                    //Thêm hàng hóa bán vào HD
                    CTNHAPHANG CT = new CTNHAPHANG();
                    CT.SOPHIEU1 = txtMaHDBan.Text.ToString();
                    CT.MAHANG1 = cboMahang.SelectedValue.ToString();
                    CT.SOLUONGNHAP1 = Convert.ToInt32(txtSoluong.Text.ToString());
                    CT.DONGIA1 = Convert.ToInt32(txtDongiaban.Text.ToString());
                    CT.THANHTIEN1 = Convert.ToInt32(txtThanhtien.Text.ToString());
                    ctnhaphangbus.InsertCTNHAPHANG(CT);

                    ResetValues();
                    ResetValuesHang();
                    DataGridView.DataSource = ctnhaphangbus.loaddataPN(txtMaHDBan.Text);
                    btnThemmoi.Enabled = true;
                    MessageBox.Show("Đã lập Phiếu nhập!");
                }
            }

            // Số phiếu đã có 
            else
            {
                // Lưu thông tin của các mặt hàng
                if (ktratxt() == false) { return; }
                else
                {
                    sql = "SELECT MAHANG FROM CTNHAPHANG WHERE MAHANG=N'" + cboMahang.SelectedValue + "' AND SOPHIEU = N'" + txtMaHDBan.Text.Trim() + "'";
                    if (cn.CheckKey(sql))
                    {
                        MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetValuesHang();
                        cboMahang.Focus();
                        return;
                    }
                    //Thêm hàng hóa bán vào HD
                    CTNHAPHANG CT = new CTNHAPHANG();
                    CT.SOPHIEU1 = txtMaHDBan.Text.ToString();
                    CT.MAHANG1 = cboMahang.SelectedValue.ToString();
                    CT.SOLUONGNHAP1 = Convert.ToInt32(txtSoluong.Text.ToString());
                    CT.DONGIA1 = Convert.ToInt32(txtDongiaban.Text.ToString());
                    CT.THANHTIEN1 = Convert.ToInt32(txtThanhtien.Text.ToString());
                    ctnhaphangbus.InsertCTNHAPHANG(CT);
                    MessageBox.Show("Đã thêm Phiếu nhập!");
                    DataGridView.DataSource = ctnhaphangbus.loaddataPN(txtMaHDBan.Text);
                    // Cập nhật lại tổng tiền cho phiêu nhập
                    tong = Convert.ToInt32(cn.GetFieldValues("SELECT TONGTIEN FROM PHIEUNHAPHANG WHERE SOPHIEU = '" + txtMaHDBan.Text + "'"));
                    Tongmoi = tong + Convert.ToInt32(txtThanhtien.Text);
                    sql = "UPDATE PHIEUNHAPHANG SET Tongtien =" + Tongmoi + " WHERE SOPHIEU = '" + txtMaHDBan.Text + "'";
                    cn.query1(sql);
                    txtTongtien.Text = Tongmoi.ToString();

                    ResetValuesHang();
                    btnXoa.Enabled = true;
                    btnThemmoi.Enabled = true;
                    btnInhoadon.Enabled = true;
                }
            }
        }

        private void cboMaHDBan_DropDown(object sender, EventArgs e)
        {
            cn.FillCombo("SELECT SOPHIEU FROM PHIEUNHAPHANG", cboMaHDBan, "SOPHIEU", "SOPHIEU");
            cboMaHDBan.SelectedIndex = -1;
        }

        private void LoadInfoHoadon()
        {
            string str;
            str = "SELECT NGAYNHAP FROM PHIEUNHAPHANG WHERE SOPHIEU = N'" + txtMaHDBan.Text + "'";
            txtNgaynhap.Text = cn.GetFieldValues(str);
            str = "SELECT MANV FROM PHIEUNHAPHANG WHERE SOPHIEU = N'" + txtMaHDBan.Text + "'";
            txtMaNhanVien.Text = cn.GetFieldValues(str);
            str = "Select TENNV from QLTAIKHOAN where MANV= N'" + txtMaNhanVien.Text + "'";
            txtTennhanvien.Text = cn.GetFieldValues(str);
            str = "SELECT TONGTIEN FROM PHIEUNHAPHANG WHERE SOPHIEU = N'" + txtMaHDBan.Text + "'";
            txtTongtien.Text = cn.GetFieldValues(str);
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            cboMancc.Enabled = false;
            if (cboMaHDBan.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một số phiếu để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHDBan.Focus();
                return;
            }
            txtMaHDBan.Text = cboMaHDBan.Text;
            LoadInfoHoadon();
            DataGridView.DataSource = ctnhaphangbus.loaddataPN(txtMaHDBan.Text);
            //KHÁCH HÀNG TT
            string str = "SELECT MANCC FROM PHIEUNHAPHANG WHERE SOPHIEU = '" + cboMaHDBan.Text + "'";
            cboMancc.Text = cn.GetFieldValues(str);
            
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
            btnInhoadon.Enabled = true;
            cboMaHDBan.SelectedIndex = -1;
            cboMahang.SelectedIndex = -1;
            }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void cboMahang_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMahang.Text == "")
            {
                txtTenhang.Text = "";
                txtDongiaban.Text = "";
                txtTon.Text = "";
            }
            // Khi chọn mã hàng thì các thông tin về hàng hiện ra
            str = "SELECT TENHANG FROM HANGHOA WHERE Mahang =N'" + cboMahang.SelectedValue + "'";
            txtTenhang.Text = cn.GetFieldValues(str);
            str = "SELECT GIABAN FROM HANGHOA WHERE Mahang =N'" + cboMahang.SelectedValue + "'";
            txtDongiaban.Text = cn.GetFieldValues(str);
            str = "SELECT SLTON FROM HANGHOA WHERE Mahang =N'" + cboMahang.SelectedValue + "'";
            txtTon.Text = cn.GetFieldValues(str);
        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            double tt, sl, dg;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToInt32(txtSoluong.Text);
            if (txtDongiaban.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDongiaban.Text);
            tt = sl * dg;
            txtThanhtien.Text = tt.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Xóa chi tiết hóa đơn
                ctnhaphangbus.DeleteCTNHAPHANG(txtMaHDBan.Text);
                //Xóa hóa đơn
                phieunhapbus.DeletePHIEUNHAP(txtMaHDBan.Text);

                txtNgaynhap.Text = "";
                btnLuu.Enabled = false;
                ResetValues();
                ResetValuesHang();
                DataGridView.DataSource = ctnhaphangbus.loaddataPN(txtMaHDBan.Text);
                btnXoa.Enabled = false;
                btnInhoadon.Enabled = false;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            cboMancc.Enabled = true;
            btnThemmoi.Enabled = true;
            btnLuu.Enabled = false;
            btnInhoadon.Enabled = false;
            btnXoa.Enabled = false;
            ResetValues();
            ResetValuesHang();
            txtNgaynhap.Text = "";
            DataGridView.DataSource = null;
            cboMancc.SelectedIndex = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GUI.QL_SANPHAM frm = new QL_SANPHAM();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnInhoadon_Click(object sender, EventArgs e)
        {
            GUI.INHOADON frm = new INHOADON(txtMaHDBan.Text);
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }


    }
}
