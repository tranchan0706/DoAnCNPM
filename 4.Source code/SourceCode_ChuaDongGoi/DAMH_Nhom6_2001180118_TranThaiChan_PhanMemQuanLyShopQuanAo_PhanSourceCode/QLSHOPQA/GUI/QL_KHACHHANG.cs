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
    public partial class QL_KHACHHANG : Form
    {
        public static string user;
        public static string manv;
        KHACHHANGBUS khachhangbus = new KHACHHANGBUS();
        connect cn = new connect();

        public QL_KHACHHANG()
        {
            InitializeComponent();
            button1.Text = user;
            textBox8.Text = manv;
        }

        private void QLKHACHHANG_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            textBox1.ReadOnly = true;
            textBox6.Text = "0";
            textBox8.ReadOnly = true;
            dataGridView1.DataSource = khachhangbus.getdata();
            if (button1.Text.Trim() == "QUẢN LÝ")
            {
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            else if (button1.Text.Trim() == "THỦ KHO")
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            else
            {
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        public bool KTra_Txt()
        {
            if (textBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return false;
            }
            if (textBox3.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập CMND", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return false;
            }
            if (textBox4.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Focus();
                return false;
            }
            if (textBox5.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập SĐT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox5.Focus();
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
                    KHACHHANG KH = new KHACHHANG();
                    KH.TENKH1 = textBox2.Text.ToString();
                    KH.CMND1 = textBox3.Text.ToString();
                    KH.DIACHI1 = textBox4.Text.ToString();
                    KH.SDT1 = textBox5.Text.ToString();
                    KH.DIEMTL1 = Convert.ToInt32(textBox6.Text.ToString());
                    KH.QL1 = textBox8.Text.ToString();
                    khachhangbus.InsertKHACHHANGTT(KH);
                    MessageBox.Show("Đã thêm xong!");
                    dataGridView1.DataSource = khachhangbus.getdata();
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
            textBox6.Text = "0";
            textBox7.Clear();
            dataGridView1.DataSource = khachhangbus.getdata();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (KTra_Txt() == true)
                {
                    KHACHHANG KH = new KHACHHANG();
                    KH.TENKH1 = textBox2.Text.ToString();
                    KH.CMND1 = textBox3.Text.ToString();
                    KH.DIACHI1 = textBox4.Text.ToString();
                    KH.SDT1 = textBox5.Text.ToString();
                    KH.DIEMTL1 = Convert.ToInt32(textBox6.Text.ToString());
                    KH.QL1 = textBox8.Text.ToString();

                    if (MessageBox.Show("Bạn có muốn sửa không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        khachhangbus.UpdateKHACHHANGTT(KH, textBox1.Text.ToString());
                        MessageBox.Show("Đã sữa xong!");
                        dataGridView1.DataSource = khachhangbus.getdata();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn 1 khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox4.Focus();
                    return;
                }
                KHACHHANG KH = new KHACHHANG();
                KH.MAKH1 = textBox1.Text.ToString();
                if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    khachhangbus.DeleteKHACHHANGTT(KH.MAKH1);
                    MessageBox.Show("Đã xóa xong!");
                    dataGridView1.DataSource = khachhangbus.getdata();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void searchTEN()
        {
            cn.ketnoiCN.Open();
            DataTable dt = new DataTable("KHACHHANGTT");
            SqlDataAdapter adt = new SqlDataAdapter("select * from KHACHHANGTT ", cn.ketnoiCN);

            adt.Fill(dt);
            DataView dtv = new DataView(dt);
            dataGridView1.DataSource = dtv;
            cn.ketnoiCN.Close();
            string ten = textBox7.Text.Trim();
            dtv.RowFilter = "TENKH like '%" + ten + "%'";
            dataGridView1.DataSource = dtv;
        }
        private void searchSDT()
        {
            cn.ketnoiCN.Open();
            DataTable dt = new DataTable("KHACHHANGTT");
            SqlDataAdapter adt = new SqlDataAdapter("select * from KHACHHANGTT ", cn.ketnoiCN);

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
            textBox2.Text = dataGridView1.Rows[d].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[d].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[d].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[d].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[d].Cells[5].Value.ToString();
            //textBox8.Text = dataGridView1.Rows[d].Cells[6].Value.ToString();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }
    }
}
