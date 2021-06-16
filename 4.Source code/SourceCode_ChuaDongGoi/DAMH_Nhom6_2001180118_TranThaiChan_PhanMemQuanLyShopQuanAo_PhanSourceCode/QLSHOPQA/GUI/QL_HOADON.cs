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
    public partial class QL_HOADON : Form
    {
        HOADONBUS hoadonbus = new HOADONBUS();
        CTHDBUS cthdbus = new CTHDBUS();
        KHACHHANGBUS khachhangbus = new KHACHHANGBUS();
        connect cn = new connect();
        public static string MaNhanVien;
        public static string user;

        public QL_HOADON()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUI.QL_KHACHHANG frm = new QL_KHACHHANG();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void QLHOADON_Load(object sender, EventArgs e)
        {
            label16.Text = user;
            textBox1.Text = MaNhanVien;
            textBox1.ReadOnly = true;
            txtMaNhanVien.ReadOnly = true;
            txtSoluong.Focus();
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            txtNgayban.ReadOnly = true;
            btnInhoadon.Enabled = false;
            txtMaHDBan.ReadOnly = true;
            txtTennhanvien.ReadOnly = true;
            txtTenkhach.ReadOnly = true;
            txtDienthoai.ReadOnly = true;
            txtTenhang.ReadOnly = true;
            txtDongiaban.ReadOnly = true;
            txtThanhtien.ReadOnly = true;
            txtTongtien.ReadOnly = true;
            txtGiamgia.Text = "0";
            txtGiamgia.ReadOnly = true;
            txtTongtien.Text = "0";

            //load combobox
            cn.FillCombo("SELECT MAKH, TENKH FROM KHACHHANGTT", cboMakhach, "makh", "makh");
            cboMakhach.SelectedIndex = -1;
            cn.FillCombo("SELECT MAHANG, TENHANG FROM HANGHOA", cboMahang, "Mahang", "Mahang");
            cboMahang.SelectedIndex = -1;
        }

        private void cboMakhach_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMakhach.Text == "")
            {
                txtTenkhach.Text = "";
                txtDienthoai.Text = "";
                txtDiemTichLuy.Text = "";
            }

            //Khi chọn Mã khách hàng thì các thông tin của khách hàng sẽ hiện ra
            str = "Select TENKH from KHACHHANGTT where Makh = N'" + cboMakhach.SelectedValue + "'";
            txtTenkhach.Text = cn.GetFieldValues(str);
            str = "Select SDT from KHACHHANGTT where Makh= N'" + cboMakhach.SelectedValue + "'";
            txtDienthoai.Text = cn.GetFieldValues(str);
            str = "Select DIEMTL from KHACHHANGTT where Makh= N'" + cboMakhach.SelectedValue + "'";
            txtDiemTichLuy.Text = cn.GetFieldValues(str);
            txtGiamgia.Text = txtDiemTichLuy.Text;
        }

        private void ResetValues()
        {
            txtMaHDBan.Text = "";
            cboMakhach.Text = "";
            txtTongtien.Text = "0";
            cboMahang.Text = "";
            txtSoluong.Text = "";
            txtGiamgia.Text = "0";
            txtThanhtien.Text = "0";
            cboMakhach.Text = "";
            txtTenkhach.Text = "";
            txtDienthoai.Text = "";
            txtDiemTichLuy.Text = "";

        }
        private void ResetValuesHang()
        {
            cboMahang.Text = "";
            txtSoluong.Text = "";
            txtGiamgia.Text = "0";
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
            // tạo mã hd tự động    
            cn.ketnoiCN.Open();
            string CauLenh = "declare @mahd char(5) exec @mahd= DBO.AUTO_IDHD select @mahd";
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
            if (txtGiamgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiamgia.Focus();
                return false;
            }
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            int SLton = Convert.ToInt32(cn.GetFieldValues("SELECT SLTON FROM HANGHOA WHERE MAHANG = N'" + cboMahang.SelectedValue + "'"));
            if (Convert.ToInt32(txtSoluong.Text) > SLton)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + SLton, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            sql = "SELECT MAHD FROM HOADON WHERE MAHD= '" + txtMaHDBan.Text + "'";
            //Mã hóa đơn chưa có, tiến hành lập HD mới
            if (cn.CheckKey(sql) == false)
            {
                if (ktratxt() == false) { return; }
                else
                {
                    // lập HĐ
                    //kiểm tra cập nhật đơn giá bán
                    string str = "Select GIABAN from HANGHOA where MAHANG = N'" + cboMahang.SelectedValue + "'";
                    int gb = Convert.ToInt32(cn.GetFieldValues(str).ToString());
                    if (gb == Convert.ToInt32(txtDongiaban.Text))
                    {
                        MessageBox.Show("Bạn chưa cập nhật đơn giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSoluong.Text = "";
                        return;
                    }
                    // Mã HD được sinh tự động do đó không có trường hợp trùng khóa
                    HOADON HD = new HOADON();
                    HD.TONGTIEN1 = Convert.ToInt32(txtThanhtien.Text.ToString());
                    HD.MANV1 = textBox1.Text.ToString();
                    HD.MAKH1 = cboMakhach.Text.ToString();
                    hoadonbus.InsertHOADON(HD);

                    //Thêm hàng hóa bán vào HD
                    CTHD CT = new CTHD();
                    CT.MAHD1 = txtMaHDBan.Text.ToString();
                    CT.MAHANG1 = cboMahang.SelectedValue.ToString();
                    CT.SOLUONG1 = Convert.ToInt32(txtSoluong.Text.ToString());
                    CT.DONGIA1 = Convert.ToInt32(txtDongiaban.Text.ToString());
                    CT.GIAMGIA1 = Convert.ToInt32(txtGiamgia.Text.ToString());
                    CT.THANHTIEN1 = Convert.ToInt32(txtThanhtien.Text.ToString());
                    cthdbus.InsertCTHD(CT);

                    ResetValues();
                    ResetValuesHang();
                    DataGridView.DataSource = cthdbus.loaddataHD(txtMaHDBan.Text);
                    btnThemmoi.Enabled = true;
                    MessageBox.Show("Đã lập Hóa Đơn!");
                }
            }

            // Mã HĐ đã có 
            else
            {
                // Lưu thông tin của các mặt hàng
                if (ktratxt() == false) { return; }
                else
                {
                    sql = "SELECT MAHANG FROM CTHD WHERE MAHANG=N'" + cboMahang.SelectedValue + "' AND MAHD = N'" + txtMaHDBan.Text.Trim() + "'";
                    if (cn.CheckKey(sql))
                    {
                        MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetValuesHang();
                        cboMahang.Focus();
                        return;
                    }
                    //kiểm tra cập nhật đơn giá bán
                    string str = "Select GIABAN from HANGHOA where MAHANG = N'" + cboMahang.SelectedValue + "'";
                    int gb = Convert.ToInt32(cn.GetFieldValues(str).ToString());
                    if (gb == Convert.ToInt32(txtDongiaban.Text))
                    {
                        MessageBox.Show("Bạn chưa cập nhật đơn giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSoluong.Text = "";
                        return;
                    }
                    //Thêm hàng hóa bán vào HD
                    CTHD CT = new CTHD();
                    CT.MAHD1 = txtMaHDBan.Text.ToString();
                    CT.MAHANG1 = cboMahang.SelectedValue.ToString();
                    CT.SOLUONG1 = Convert.ToInt32(txtSoluong.Text.ToString());
                    CT.DONGIA1 = Convert.ToInt32(txtDongiaban.Text.ToString());
                    CT.GIAMGIA1 = Convert.ToInt32(txtGiamgia.Text.ToString());
                    CT.THANHTIEN1 = Convert.ToInt32(txtThanhtien.Text.ToString());
                    cthdbus.InsertCTHD(CT);
                    MessageBox.Show("Đã thêm Hóa Đơn!");
                    DataGridView.DataSource = cthdbus.loaddataHD(txtMaHDBan.Text);
                    // Cập nhật lại tổng tiền cho hóa đơn bán
                    tong = Convert.ToInt32(cn.GetFieldValues("SELECT TONGTIEN FROM HOADON WHERE MaHD = '" + txtMaHDBan.Text + "'"));
                    Tongmoi = tong + Convert.ToInt32(txtThanhtien.Text);
                    sql = "UPDATE HOADON SET Tongtien =" + Tongmoi + " WHERE MaHD = '" + txtMaHDBan.Text + "'";
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
            cn.FillCombo("SELECT MAHD FROM HOADON", cboMaHDBan, "MaHD", "MaHD");
            cboMaHDBan.SelectedIndex = -1;
        }

        private void LoadInfoHoadon()
        {
            string str;
            str = "SELECT NGAYLAP FROM HOADON WHERE MaHD = N'" + txtMaHDBan.Text + "'";
            txtNgayban.Text = cn.GetFieldValues(str);
            str = "SELECT MANV FROM HOADON WHERE MaHD = N'" + txtMaHDBan.Text + "'";
            txtMaNhanVien.Text = cn.GetFieldValues(str);
            str = "Select TENNV from QLTAIKHOAN where MANV= N'" + txtMaNhanVien.Text + "'";
            txtTennhanvien.Text = cn.GetFieldValues(str);
            str = "SELECT TONGTIEN FROM HOADON WHERE MaHD = N'" + txtMaHDBan.Text + "'";
            txtTongtien.Text = cn.GetFieldValues(str);
        }

        public bool KT_MAKH(string MAHD)
        {
            try
            {
                cn.ketnoiCN.Open();
                string CauLenh = "DECLARE	@return_value int EXEC	@return_value = [dbo].[sp_KiemTraMAKH] "
                      + " @mahd = N'" + MAHD + "' SELECT	'Return Value' = @return_value";
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

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            cboMakhach.Enabled = false;
            if (cboMaHDBan.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHDBan.Focus();
                return;
            }
            txtMaHDBan.Text = cboMaHDBan.Text;
            LoadInfoHoadon();
            DataGridView.DataSource = cthdbus.loaddataHD(txtMaHDBan.Text);

            if (KT_MAKH(cboMaHDBan.Text) == false)
            {
                //KHÁCH VÃNG LAI
                btnXoa.Enabled = true;
                btnLuu.Enabled = true;
                btnInhoadon.Enabled = true;
                cboMaHDBan.SelectedIndex = -1;
                cboMakhach.SelectedIndex = -1;
                cboMahang.SelectedIndex = -1;
                txtGiamgia.Text = "0";
            }
            else
            {
                //KHÁCH HÀNG TT
                string str = "SELECT MAKH FROM HOADON WHERE MAHD = '" + cboMaHDBan.Text + "'";
                cboMakhach.Text = cn.GetFieldValues(str);

                btnXoa.Enabled = true;
                btnLuu.Enabled = true;
                btnInhoadon.Enabled = true;
                cboMaHDBan.SelectedIndex = -1;
                cboMahang.SelectedIndex = -1;
            }
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void txtGiamgia_KeyPress(object sender, KeyPressEventArgs e)
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
            double tt, sl, dg, gg;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToInt32(txtSoluong.Text);
            if (txtGiamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToInt32(txtGiamgia.Text);
            if (txtDongiaban.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDongiaban.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhtien.Text = tt.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Xóa chi tiết hóa đơn
                cthdbus.DeleteCTHD(txtMaHDBan.Text);
                //Xóa hóa đơn
                hoadonbus.DeleteHOADON(txtMaHDBan.Text);

                txtNgayban.Text = "";
                btnLuu.Enabled = false;
                ResetValues();
                ResetValuesHang();
                DataGridView.DataSource = cthdbus.loaddataHD(txtMaHDBan.Text);
                btnXoa.Enabled = false;
                btnInhoadon.Enabled = false;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnThemmoi.Enabled = true;
            btnLuu.Enabled = false;
            btnInhoadon.Enabled = false;
            btnXoa.Enabled = false;
            ResetValues();
            ResetValuesHang();
            txtNgayban.Text = "";
            DataGridView.DataSource = null;
            cboMakhach.SelectedIndex = -1;
            cboMakhach.Enabled = true; ;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GUI.QL_SANPHAM frm = new QL_SANPHAM();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void txtGiamgia_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi giảm giá thì tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtGiamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamgia.Text);
            if (txtDongiaban.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDongiaban.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhtien.Text = tt.ToString();
        }

        public void KT_DIEMTL(string MAKH)
        {
            try
            {
                cn.ketnoiCN.Open();
                string CauLenh = "EXEC sp_KiemTraDIEMTL '" + MAKH + "'";
                SqlCommand cmd = new SqlCommand(CauLenh, cn.ketnoiCN);
                object value = cmd.ExecuteScalar();
                cn.ketnoiCN.Close();
            }
            catch (Exception EX)
            { MessageBox.Show(EX.Message); }
        }

        private void btnInhoadon_Click(object sender, EventArgs e)
        {
            // Nếu là KHTT thì cộng điểm TL
            if (cboMakhach.SelectedIndex > -1)
            {
                KHACHHANG KH = new KHACHHANG();
                // Cách quy Điểm TL: 100000VNĐ = 1đ 
                KH.DIEMTL1 = Convert.ToInt32(txtDiemTichLuy.Text.ToString()) + (Convert.ToInt32(txtTongtien.Text.ToString()) / 100000);
                khachhangbus.UpdateDIEMTL(KH, cboMakhach.Text.ToString());
                KT_DIEMTL(cboMakhach.Text);
                MessageBox.Show("Đã cộng Điểm TL cho khách!");
            }
            GUI.INHOADON frm = new INHOADON(txtMaHDBan.Text);
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = "Select GIABAN from HANGHOA where MAHANG = N'" + cboMahang.SelectedValue + "'";
            double gn, gb;
            gn = Convert.ToDouble(cn.GetFieldValues(str).ToString());
            gb = gn + (gn / 10);
            txtDongiaban.Text = gb.ToString();
        }

    }
}
