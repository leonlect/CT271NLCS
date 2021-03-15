using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace QuanLyKho
{
    public partial class frmKH : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dt;
        private SqlDataReader reader;
        private SqlCommand com;
        public frmKH()
        {
            InitializeComponent();
        }


        #region Load dữ liệu lên DataGridView khi form khách hàng bật lên
        void loadDataKH()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM KhachHang", clsDatabase.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            dgvKH.DataSource = dt;
        }
        #endregion

        #region RESETFIELD
        void resetField()
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtDiachi.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtMaKH.BackColor = System.Drawing.SystemColors.ControlLight;
        }
        #endregion

        #region Load DMKH khi form mở lên
        private void frmDMKH_Load(object sender, EventArgs e)
        {
            clsDatabase.OpenConnection();
            loadDataKH();
            dgvKH.ClearSelection();
            btnLuu.Enabled = false;
            clsDatabase.CloseConnection();
        }
        #endregion

        #region Method nhập sdt bằng kiểu số
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }



        #endregion

        #region Phuong thức tìm kiếm tên khách hàng
        void Search_TenKH()
        {
            try
            {
                clsDatabase.OpenConnection();
                com = new SqlCommand("sp_getTenKH", clsDatabase.con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter("@ten", txtTim.Text.Trim()));
                SqlDataReader reader = com.ExecuteReader();
                dt = new DataTable();
                dt.Load(reader);
                this.dgvKH.DataSource = dt;
            }
            catch (Exception) { }
        }
        #endregion

        #region Xử lý sự kiện nút Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            resetField();
            txtMaKH.BackColor = Color.White;
            txtMaKH.Enabled = true;
            txtMaKH.Focus();
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
        }

        #endregion

        #region Xử lý sự kiện nút Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text.Equals(""))
            {
                MessageBox.Show("Bạn chưa chọn dòng nào đê sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtTenKH.Text.Equals(""))
            {
                MessageBox.Show("Tên khách hàng không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKH.Focus();
                return;
            }
            else if (txtDiachi.Text.Equals(""))
            {
                MessageBox.Show("Địa chỉ khách hàng không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiachi.Focus();
                return;
            }
            else if (txtSDT.Text.Equals(""))
            {
                MessageBox.Show("Số điện thoại không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
                return;
            }
            else if (txtEmail.Text.Equals(""))
            {
                MessageBox.Show("Email liên hệ không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }
            else
            {
                try
                {
                    clsDatabase.OpenConnection();
                    com = new SqlCommand("sp_updateKH", clsDatabase.con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@makh", SqlDbType.NVarChar).Value = txtMaKH.Text;
                    com.Parameters.Add("@Ten", SqlDbType.NVarChar).Value = txtTenKH.Text;
                    com.Parameters.Add("@diaChi", SqlDbType.NVarChar).Value = txtDiachi.Text;
                    com.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = txtSDT.Text;
                    com.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtEmail.Text;
                    com.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thông tin khách hàng thành công !", "Thông báo", MessageBoxButtons.OK);
                    loadDataKH();
                    resetField();
                    com.Dispose();
                    clsDatabase.CloseConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        #endregion

        #region Xử lý sự kiện nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKH.Text.Equals(""))
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa khách hàng này không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    clsDatabase.OpenConnection();
                    string strDelete = "Delete From KhachHang Where Makh = '" + txtMaKH.Text + "' ";
                    SqlCommand com = new SqlCommand(strDelete, clsDatabase.con);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Xóa khách hàng này thành công !", "Thông báo", MessageBoxButtons.OK);
                    loadDataKH();
                    com.Dispose();
                    resetField();
                    clsDatabase.CloseConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ! Mã khách hàng này đang liên kết với phiếu xuất kho !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Xử lý sự kiện nút Hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            resetField();
            txtMaKH.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = false;
        }

        #endregion

        #region Xử lý sự kiện nút Lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text.Equals(""))
            {
                MessageBox.Show("Mã khách hàng không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
                return;
            }
            else if (txtTenKH.Text.Equals(""))
            {
                MessageBox.Show("Tên khách hàng không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKH.Focus();
                return;
            }
            else if (txtDiachi.Text.Equals(""))
            {
                MessageBox.Show("Địa chỉ khách hàng không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiachi.Focus();
                return;
            }
            else if (txtSDT.Text.Equals(""))
            {
                MessageBox.Show("Số điện thoại không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
                return;
            }
            else if (txtEmail.Text.Equals(""))
            {
                MessageBox.Show("Email liên hệ không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }
            else
            {
                try
                {
                    //Them procedure vao day
                    clsDatabase.OpenConnection();
                    com = new SqlCommand("sp_themKH", clsDatabase.con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@makh", SqlDbType.NVarChar).Value = txtMaKH.Text;
                    com.Parameters.Add("@Ten", SqlDbType.NVarChar).Value = txtTenKH.Text;
                    com.Parameters.Add("@diaChi", SqlDbType.NVarChar).Value = txtDiachi.Text;
                    com.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = txtSDT.Text;
                    com.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtEmail.Text;
                    com.ExecuteNonQuery();
                    MessageBox.Show("Thêm khách hàng mới thành công !", "Thông báo", MessageBoxButtons.OK);
                    loadDataKH();
                    resetField();
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnLuu.Enabled = false;
                    com.Dispose();
                    clsDatabase.CloseConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Mã khách hàng không được trùng !", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        #endregion

        #region Sự kiện khi click lên 1 dòng của DataGridView
        private void dgvKH_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
            }
            else if (dgvKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    int i = dgvKH.CurrentCell.RowIndex;
                    txtMaKH.Text = dgvKH.Rows[i].Cells[0].Value.ToString();
                    txtTenKH.Text = dgvKH.Rows[i].Cells[1].Value.ToString();
                    txtDiachi.Text = dgvKH.Rows[i].Cells[2].Value.ToString();
                    txtSDT.Text = dgvKH.Rows[i].Cells[3].Value.ToString();
                    txtEmail.Text = dgvKH.Rows[i].Cells[4].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion

        #region Sự kiện nút làm mới lại trang
        private void btnLammoi_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM KhachHang", clsDatabase.con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                dgvKH.DataSource = dt;
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region Sự kiện nhập lên textbox Tim để tìm tên khách hàng
        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            this.Search_TenKH();
        } 
        #endregion

    }
}