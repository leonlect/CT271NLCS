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
    public partial class frmNCC : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dt;
        private SqlDataAdapter da;
        private SqlCommand com;
        public frmNCC()
        {
            InitializeComponent();
        }

        #region Load dữ liệu lên DataGridView
        void loadDataGridView()
        {
            string sql = "SELECT * FROM NhaCungCap";
            dt = clsDatabase.GetDataToTable(sql);
            dgvNCC.DataSource = dt;
        }
        #endregion

        #region Load nhà cung cấp khi mở form lên
        private void frmNCC_Load(object sender, EventArgs e)
        {
            clsDatabase.OpenConnection();
            loadDataGridView();
            dgvNCC.ClearSelection();
            btnLuu.Enabled = false;
            clsDatabase.CloseConnection();
        }
        #endregion

        #region ResetField
        void resetField()
        {
            txtMa.Clear();
            txtTen.Clear();
            txtDiachi.Clear();
            txtSdt.Clear();
            txtEmail.Clear();
            txtMa.BackColor = System.Drawing.SystemColors.ControlLight;
        }
        #endregion
      
        #region Method chỉ nhập kiểu số của mã nhà cung cấp
        private void txtMa_KeyPress(object sender, KeyPressEventArgs e)
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

        #region Method tìm kiếm nhà cung cấp theo tên
        void Search_tenNCC()
        {
            try
            {
                clsDatabase.OpenConnection();
                com = new SqlCommand("sp_getTenNCC", clsDatabase.con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter("@tenncc", txtTim.Text.Trim()));
                SqlDataReader reader = com.ExecuteReader();
                dt = new DataTable();
                dt.Load(reader);
                this.dgvNCC.DataSource = dt;
            }
            catch (Exception) { }
        } 
        #endregion

        #region Sự kiện nút làm mới lại trang
        private void btnLammoi_Click(object sender, EventArgs e)
        {
            try
            {
                resetField();
                txtTim.Clear();
                loadDataGridView();
            }
            catch (Exception)
            {
            }
        } 
        #endregion

        #region Xử lý sự kiện nút Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            resetField();
            txtMa.BackColor = Color.White;
            txtMa.Enabled = true;
            txtMa.Focus();
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
            if (dgvNCC.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMa.Text.Trim().Equals(""))
            {
                MessageBox.Show("Bạn chưa chọn dòng nào đê sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMa.Focus();
                return;
            }
            if (txtTen.Text.Trim().Equals(""))
            {
                MessageBox.Show("Tên nhà cung cấp không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTen.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Equals(""))
            {
                MessageBox.Show("Địa chỉ không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiachi.Focus();
                return;
            }
            if (txtSdt.Text.Trim().Equals(""))
            {
                MessageBox.Show("Số điện thoại không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSdt.Focus();
                return;
            }
            if (txtEmail.Text.Trim().Equals(""))
            {
                MessageBox.Show("Email không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }
            try
            {
                clsDatabase.OpenConnection();
                com = new SqlCommand("sp_updateNCC", clsDatabase.con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@macc", SqlDbType.Int).Value = txtMa.Text.Trim();
                com.Parameters.Add("@tenncc", SqlDbType.NVarChar).Value = txtTen.Text.Trim();
                com.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = txtDiachi.Text.Trim();
                com.Parameters.Add("@sdtncc", SqlDbType.NVarChar).Value = txtSdt.Text.Trim();
                com.Parameters.Add("@email", SqlDbType.NVarChar).Value = txtEmail.Text.Trim();
                com.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thông tin nhà cung cấp thành công !", "Thông báo", MessageBoxButtons.OK);
                loadDataGridView();
                resetField();
                com.Dispose();
                clsDatabase.CloseConnection();
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region Xử lý sự kiện nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (dgvNCC.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMa.Text.Equals(""))
            {
                MessageBox.Show("Bạn chưa chọn dòng nào đê xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa nhà cung cấp này không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    clsDatabase.OpenConnection();
                    string strDelete = "Delete From NhaCungCap Where Mancc = '" + txtMa.Text + "' ";
                    SqlCommand com = new SqlCommand(strDelete, clsDatabase.con);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Xóa nhà cung cấp này thành công !", "Thông báo", MessageBoxButtons.OK);
                    loadDataGridView();
                    com.Dispose();
                    resetField();
                    clsDatabase.CloseConnection();
                }
                catch (Exception)
                {
                    MessageBox.Show("Mã nhà cung cấp này đang liên kết với hàng hóa !", "Thông báo", MessageBoxButtons.OK);
                }

            }
        }
        #endregion

        #region Xử lý sự kiện nút Hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            resetField();
            txtMa.Enabled = false;
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
            string sql;
            if (txtMa.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mã nhà cung cấp không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMa.Focus();
                return;
            }
            if (txtTen.Text.Trim().Equals(""))
            {
                MessageBox.Show("Tên nhà cung cấp không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTen.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Equals(""))
            {
                MessageBox.Show("Địa chỉ không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiachi.Focus();
                return;
            }
            if (txtSdt.Text.Trim().Equals(""))
            {
                MessageBox.Show("Số điện thoại không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSdt.Focus();
                return;
            }
            if (txtEmail.Text.Trim().Equals(""))
            {
                MessageBox.Show("Email không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }
            sql = "SELECT Mancc FROM NhaCungCap WHERE Mancc = N'" + txtMa.Text.Trim() + "'";
            if (clsDatabase.checkKey(sql))
            {
                MessageBox.Show("Mã nhà cung cấp này đã tồn tại, bạn phải chọn mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMa.Focus();
                return;
            }
            clsDatabase.OpenConnection();
            com = new SqlCommand("sp_themNCC", clsDatabase.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@macc", SqlDbType.Int).Value = txtMa.Text.Trim();
            com.Parameters.Add("@tenncc", SqlDbType.NVarChar).Value = txtTen.Text.Trim();
            com.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = txtDiachi.Text.Trim();
            com.Parameters.Add("@sdtncc", SqlDbType.NVarChar).Value = txtSdt.Text.Trim();
            com.Parameters.Add("@email", SqlDbType.NVarChar).Value = txtEmail.Text.Trim();
            com.ExecuteNonQuery();
            MessageBox.Show("Thêm nhà cung cấp mới thành công !", "Thông báo", MessageBoxButtons.OK);
            loadDataGridView();
            resetField();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            com.Dispose();
            clsDatabase.CloseConnection();
        }

        #endregion

        #region Sự kiện khi click lên 1 dòng của DataGridView
        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMa.Focus();
            }
            else if (dgvNCC.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    int i = dgvNCC.CurrentCell.RowIndex;
                    txtMa.Text = dgvNCC.Rows[i].Cells[0].Value.ToString();
                    txtTen.Text = dgvNCC.Rows[i].Cells[1].Value.ToString();
                    txtDiachi.Text = dgvNCC.Rows[i].Cells[2].Value.ToString();
                    txtSdt.Text = dgvNCC.Rows[i].Cells[3].Value.ToString();
                    txtEmail.Text = dgvNCC.Rows[i].Cells[4].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        #endregion    }

        #region Sự kiện nhập lên textbox Tim để tìm mặt hàng theo mã hàng
        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            this.Search_tenNCC();
        }
        #endregion
    }
}