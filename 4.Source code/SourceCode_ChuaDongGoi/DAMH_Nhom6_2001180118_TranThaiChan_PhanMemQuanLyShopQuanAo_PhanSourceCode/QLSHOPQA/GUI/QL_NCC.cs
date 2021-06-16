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
    public partial class QL_NCC : Form
    {
        public static string user;
        public static string manv;
        NCCBUS nccbus = new NCCBUS();
        connect cn = new connect();

        public QL_NCC()
        {
            InitializeComponent();
            button1.Text = user;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            dataGridView1.DataSource = nccbus.getdata();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[d].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[d].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[d].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[d].Cells[3].Value.ToString();
        }

        private void QL_NCC_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            textBox1.ReadOnly = true;
            dataGridView1.DataSource = nccbus.getdata();
            if (button1.Text.Trim() == "QUẢN LÝ")
            {
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            else if (button1.Text.Trim() == "THỦ KHO")
            {
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            else
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        private void searchTEN()
        {
            cn.ketnoiCN.Open();
            DataTable dt = new DataTable("NHACUNGCAP");
            SqlDataAdapter adt = new SqlDataAdapter("select * from NHACUNGCAP ", cn.ketnoiCN);

            adt.Fill(dt);
            DataView dtv = new DataView(dt);
            dataGridView1.DataSource = dtv;
            cn.ketnoiCN.Close();
            string ten = textBox7.Text.Trim();
            dtv.RowFilter = "TENCC like '%" + ten + "%'";
            dataGridView1.DataSource = dtv;
        }

        private void searchSDT()
        {
            cn.ketnoiCN.Open();
            DataTable dt = new DataTable("QLTAIKHOAN");
            SqlDataAdapter adt = new SqlDataAdapter("select * from NHACUNGCAP ", cn.ketnoiCN);

            adt.Fill(dt);
            DataView dtv = new DataView(dt);
            dataGridView1.DataSource = dtv;
            cn.ketnoiCN.Close();
            string SDT = textBox7.Text.Trim();
            dtv.RowFilter = "DIENTHOAI like '%" + SDT + "%'";
            dataGridView1.DataSource = dtv;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            { searchTEN(); }
            else
            { searchSDT(); }
        }

        public bool KTra_Txt()
        {
            if (textBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return false;
            }
            if (textBox3.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return false;
            }
            if (textBox4.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập sđt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (KTra_Txt() == true)
                {
                    NCC ncc = new NCC();
                    ncc.TenNCC = textBox2.Text.ToString();
                    ncc.DiaChi = textBox3.Text.ToString();
                    ncc.SoDT = textBox4.Text.ToString();

                    nccbus.themNhaCungCap(ncc);
                    MessageBox.Show("Đã thêm xong!");
                    dataGridView1.DataSource = nccbus.getdata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (KTra_Txt() == true)
                {
                    NCC ncc = new NCC();
                    ncc.TenNCC = textBox2.Text.ToString();
                    ncc.DiaChi = textBox3.Text.ToString();
                    ncc.SoDT = textBox4.Text.ToString();

                    if (MessageBox.Show("Bạn có muốn sửa không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        nccbus.suaNhaCungCap(ncc, textBox1.Text.ToString());
                        MessageBox.Show("Đã sữa xong!");
                        dataGridView1.DataSource = nccbus.getdata();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool ktra_KN()
        {
            string str1 = "select MANCC from NHACUNGCAP where MANCC in (select MANCC from PHIEUNHAPHANG where MANCC='" + textBox1.Text.Trim() + "')";
            string MA = cn.GetFieldValues(str1);
            if (MA == "")
                return false;
            return true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (ktra_KN() == true)
            {
                MessageBox.Show("Nhà cung cấp nằm trong phiếu nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            try
            {
                if (textBox1.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn 1 nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox4.Focus();
                    return;
                }
                NCC ncc = new NCC();
                ncc.MaNCC = textBox1.Text.ToString();
                if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    nccbus.xoaNhaCungCap(ncc.MaNCC);
                    MessageBox.Show("Đã xóa xong!");
                    dataGridView1.DataSource = nccbus.getdata();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }
    }
}
