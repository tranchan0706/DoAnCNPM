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
    public partial class QL_NHANVIEN : Form
    {
        public static string user;
        public static string manv;
        NHANVIENBUS nvbus = new NHANVIENBUS();
        connect cn = new connect();

        public QL_NHANVIEN()
        {
            InitializeComponent();
            button1.Text = user;
        }

        private void QLNHANVIEN_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            textBox1.ReadOnly = true;
            dataGridView1.DataSource = nvbus.getdata();
        }

        private void searchTEN()
        {
            cn.ketnoiCN.Open();
            DataTable dt = new DataTable("QLTAIKHOAN");
            SqlDataAdapter adt = new SqlDataAdapter("select * from QLTAIKHOAN ", cn.ketnoiCN);

            adt.Fill(dt);
            DataView dtv = new DataView(dt);
            dataGridView1.DataSource = dtv;
            cn.ketnoiCN.Close();
            string ten = textBox7.Text.Trim();
            dtv.RowFilter = "TENNV like '%" + ten + "%'";
            dataGridView1.DataSource = dtv;
        }
        private void searchSDT()
        {
            cn.ketnoiCN.Open();
            DataTable dt = new DataTable("QLTAIKHOAN");
            SqlDataAdapter adt = new SqlDataAdapter("select * from QLTAIKHOAN ", cn.ketnoiCN);

            adt.Fill(dt);
            DataView dtv = new DataView(dt);
            dataGridView1.DataSource = dtv;
            cn.ketnoiCN.Close();
            string SDT = textBox7.Text.Trim();
            dtv.RowFilter = "SDT like '%" + SDT + "%'";
            dataGridView1.DataSource = dtv;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            { searchTEN(); }
            else
            { searchSDT(); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[d].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[d].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[d].Cells[6].Value.ToString();
            textBox4.Text = dataGridView1.Rows[d].Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.Rows[d].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.Rows[d].Cells[4].Value.ToString();
            textBox8.Text = dataGridView1.Rows[d].Cells[5].Value.ToString();
            textBox9.Text = dataGridView1.Rows[d].Cells[7].Value.ToString();
            textBox10.Text = dataGridView1.Rows[d].Cells[8].Value.ToString();
            textBox11.Text = dataGridView1.Rows[d].Cells[9].Value.ToString();
        }

        public bool KTra_Txt()
        {
            if (textBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return false;
            }
            if (textBox3.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Sđt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return false;
            }
            if (textBox4.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Tên tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Focus();
                return false;
            }
            if (textBox5.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox5.Focus();
                return false;
            }
            if (textBox8.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox8.Focus();
                return false;
            }
            if (textBox10.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập lương", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox10.Focus();
                return false;
            }
            if (textBox11.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập phụ cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox11.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (textBox9.Text.Length == 0)
            {
                MessageBox.Show("chọn chức vụ");
                return;
            }
            try
            {
                if (KTra_Txt() == true)
                {
                    NHANVIEN nv = new NHANVIEN();
                    nv.TenNV = textBox2.Text.ToString();
                    nv.SoDT = textBox3.Text.ToString();
                    nv.TenTK = textBox4.Text.ToString();
                    nv.MatKhau = textBox5.Text.ToString();
                    nv.NgaySinh = textBox6.Text.ToString();
                    nv.DiaChi = textBox8.Text.ToString();
                    nv.ChucVu = textBox9.Text.ToString();
                    nv.Luong = Convert.ToInt32(textBox10.Text.ToString());
                    nv.PhuCap = Convert.ToInt32(textBox11.Text.ToString());

                    nvbus.InsertNHANVIEN(nv);
                    MessageBox.Show("Đã thêm xong!");
                    dataGridView1.DataSource = nvbus.getdata();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (KTra_Txt() == true)
                {
                    NHANVIEN nv = new NHANVIEN();
                    nv.TenNV = textBox2.Text.ToString();
                    nv.SoDT = textBox3.Text.ToString();
                    nv.TenTK = textBox4.Text.ToString();
                    nv.MatKhau = textBox5.Text.ToString();
                    nv.NgaySinh = textBox6.Text.ToString();
                    nv.DiaChi = textBox8.Text.ToString();
                    nv.ChucVu = textBox9.Text.ToString();
                    nv.Luong = Convert.ToInt32(textBox10.Text.ToString());
                    nv.PhuCap = Convert.ToInt32(textBox11.Text.ToString());

                    if (MessageBox.Show("Bạn có muốn sửa không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        nvbus.UpdateNHANVIEN(nv, textBox1.Text.ToString());
                        MessageBox.Show("Đã sữa xong!");
                        dataGridView1.DataSource = nvbus.getdata();
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public bool ktra_KN1()
        {
            string str1 = "select MANV from QLTAIKHOAN where MANV in (select MANV from HOADON where MANV='" + textBox1.Text.Trim() + "')";
            string MA = cn.GetFieldValues(str1);
            if (MA == "")
                return false;
            return true;
        }
        public bool ktra_KN2()
        {
            string str2 = "select MANV from QLTAIKHOAN where MANV in (select MANV from KHACHHANGTT where QL=MANV) AND MANV='" + textBox1.Text.Trim() + "'";
            string MA2 = cn.GetFieldValues(str2);
            if (MA2 == "")
                return false;
            return true;
        }
        public bool ktra_KN3()
        {
            string str2 = "select MANV from QLTAIKHOAN where MANV in (select MANV from PHIEUNHAPHANG where MANV='" + textBox1.Text.Trim() + "')";
            string MA2 = cn.GetFieldValues(str2);
            if (MA2 == "")
                return false;
            return true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn 1 nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (ktra_KN1() == true)
            {
                MessageBox.Show("Nhân viên đang nằm trong hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (ktra_KN2() == true)
            {
                MessageBox.Show("Nhân viên đang quản lý Khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (ktra_KN3() == true)
            {
                MessageBox.Show("Nhân viên đang nằm trong phiếu nhập hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            try
            {
                NHANVIEN nv = new NHANVIEN();
                nv.MaNV = textBox1.Text.ToString();
                if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    nvbus.DeleteNHANVIEN(nv.MaNV);
                    MessageBox.Show("Đã xóa xong!");
                    dataGridView1.DataSource = nvbus.getdata();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            //textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.SelectedIndex = -1;
            textBox10.Clear();
            textBox11.Clear();
            dataGridView1.DataSource = nvbus.getdata();
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }
    }
}
