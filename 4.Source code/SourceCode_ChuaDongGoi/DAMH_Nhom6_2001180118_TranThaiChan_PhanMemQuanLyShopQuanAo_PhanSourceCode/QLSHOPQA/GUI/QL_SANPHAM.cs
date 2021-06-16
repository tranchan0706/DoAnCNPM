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
    public partial class QL_SANPHAM : Form
    {
        public static string user;
        SANPHAMBUS sanphambus = new SANPHAMBUS();
        connect cn = new connect();

        public QL_SANPHAM()
        {
            InitializeComponent();
            button1.Text = user;
        }

        private void QLSANPHAM_Load(object sender, EventArgs e)
        {
            textBox8.ReadOnly = true;
            textBox1.ReadOnly = true;
            comboBox1.SelectedIndex = 0;
            dataGridView1.DataSource = sanphambus.getdata();
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
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        public bool KTra_Txt()
        {
            if (textBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return false;
            }
            if (textBox3.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Size", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return false;
            }
            if (textBox4.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập nhà sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Focus();
                return false;
            }
            if (textBox5.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox5.Focus();
                return false;
            }
            if (textBox6.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox6.Focus();
                return false;
            }
            if (textBox8.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox8.Focus();
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
                    SANPHAM SP = new SANPHAM();
                    SP.MAHANG1 = textBox1.Text.ToString();
                    SP.TENHANG1 = textBox2.Text.ToString();
                    SP.SIZE1 = textBox3.Text.ToString();
                    SP.NHASX1 = textBox4.Text.ToString();
                    SP.GIABAN1 = Convert.ToInt32(textBox5.Text.ToString());
                    SP.SLTON1 = Convert.ToInt32(textBox6.Text.ToString());
                    SP.ANH1 = textBox8.Text.ToString();
                    //SP.ANH1 = cn.Cat_link_anh(textBox8.Text.ToString());
                    sanphambus.InsertSANPHAM(SP);
                    MessageBox.Show("Đã thêm xong!");
                    dataGridView1.DataSource = sanphambus.getdata();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public bool KT_ANH(string link)
        {
            try
            {
                cn.ketnoiCN.Open();
                string CauLenh = "DECLARE	@return_value int EXEC	@return_value = [dbo].[sp_KiemTraAnh] "
                + " @link = N'" + link + "' SELECT	'Return Value' = @return_value";
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int d = e.RowIndex;
                textBox1.Text = dataGridView1.Rows[d].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[d].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[d].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[d].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.Rows[d].Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.Rows[d].Cells[5].Value.ToString();
                textBox8.Text = dataGridView1.Rows[d].Cells[6].Value.ToString();
                picAnh.Image = Image.FromFile(textBox8.Text);
                //picAnh.Image = Image.FromFile(".\\..\\..\\Image\\" + dataGridView1.Rows[d].Cells[6].Value.ToString().Trim());
            }
            catch (Exception ex)
            { MessageBox.Show("không có dữ liệu!"); MessageBox.Show(ex.Message); }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            picAnh.Image = null;
            dataGridView1.DataSource = sanphambus.getdata();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (KTra_Txt() == true)
                {
                    SANPHAM SP = new SANPHAM();
                    SP.TENHANG1 = textBox2.Text.ToString();
                    SP.SIZE1 = textBox3.Text.ToString();
                    SP.NHASX1 = textBox4.Text.ToString();
                    SP.GIABAN1 = Convert.ToInt32(textBox5.Text.ToString());
                    SP.SLTON1 = Convert.ToInt32(textBox6.Text.ToString());
                    SP.ANH1 = textBox8.Text.ToString();
                    //SP.ANH1 = cn.Cat_link_anh(textBox8.Text.ToString());
                    if (MessageBox.Show("Bạn có muốn sửa không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        sanphambus.UpdateSANPHAM(SP, textBox1.Text.ToString());
                        MessageBox.Show("Đã sữa xong!");
                        dataGridView1.DataSource = sanphambus.getdata();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public bool ktra_KN()
        {
            string str1 = "select MAHANG from HANGHOA where MAHANG in (select MAHANG from CTHD where MAHANG='" + textBox1.Text.Trim() + "')";
            string MA = cn.GetFieldValues(str1);
            if (MA == "")
                return false;
            return true;
        }
        public bool ktra_KN1()
        {
            string str1 = "select MAHANG from HANGHOA where MAHANG in (select MAHANG from CTNHAPHANG where MAHANG='" + textBox1.Text.Trim() + "')";
            string MA = cn.GetFieldValues(str1);
            if (MA == "")
                return false;
            return true;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn 1 sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (ktra_KN() == true)
            {
                MessageBox.Show("sản phẩm nằm trong hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (ktra_KN1() == true)
            {
                MessageBox.Show("sản phẩm nằm trong phiếu nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            try
            {
                SANPHAM SP = new SANPHAM();
                SP.MAHANG1 = textBox1.Text.ToString();
                if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sanphambus.DeleteSANPHAM(SP.MAHANG1);
                    MessageBox.Show("Đã xóa xong!");
                    dataGridView1.DataSource = sanphambus.getdata();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void QLSANPHAM_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void searchTEN()
        {
            cn.ketnoiCN.Open();
            DataTable dt = new DataTable("HangHoa");
            SqlDataAdapter adt = new SqlDataAdapter("select * from HangHoa ", cn.ketnoiCN);

            adt.Fill(dt);
            DataView dtv = new DataView(dt);
            dataGridView1.DataSource = dtv;
            cn.ketnoiCN.Close();
            string ten = textBox7.Text.Trim();
            dtv.RowFilter = "TenHang like '%" + ten + "%'";
            dataGridView1.DataSource = dtv;
        }
        private void searchGIA()
        {
            cn.ketnoiCN.Open();
            DataTable dt = new DataTable("HangHoa");
            SqlDataAdapter adt = new SqlDataAdapter("select * from HangHoa ", cn.ketnoiCN);

            adt.Fill(dt);
            DataView dtv = new DataView(dt);
            dataGridView1.DataSource = dtv;
            cn.ketnoiCN.Close();
            string gia = textBox7.Text.Trim();
            dtv.RowFilter = "giaban <= " + gia + "";
            dataGridView1.DataSource = dtv;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            { searchTEN(); }
            else
            { searchGIA(); }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                textBox8.Text = dlgOpen.FileName;
            }
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
