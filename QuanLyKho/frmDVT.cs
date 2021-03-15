using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyKho
{
    public partial class frmDVT : DevExpress.XtraEditors.XtraForm
    {
        int id1;
        public frmDVT()
        {
            InitializeComponent();
        }

        private DataTable dt;
        private SqlDataReader reader;
        private SqlCommand com;

        #region Load dữ liệu lên DataGridView khi form DM Đơn vị tính bật lên
        void loadDataDVT()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DVT", clsDatabase.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            dgvDVT.DataSource = dt;
        }
        #endregion

        #region RESETFIELD
        void resetField()
        {
            txtTen.Clear();
            txtDVT.Clear();
        }
        #endregion

        #region Phuong thức tìm kiếm tên đơn vị tính
        void Search_TenDVT()
        {
            try
            {
                clsDatabase.OpenConnection();
                com = new SqlCommand("sp_getTenDVT", clsDatabase.con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter("@tendvtinh", txtTim.Text.Trim()));
                SqlDataReader reader = com.ExecuteReader();
                dt = new DataTable();
                dt.Load(reader);
                this.dgvDVT.DataSource = dt;
            }
            catch (Exception) { }
        }
        #endregion

        private void frmDVT_Load(object sender, EventArgs e)
        {
            clsDatabase.OpenConnection();
            loadDataDVT();
            btnLuu.Enabled = false;
            clsDatabase.CloseConnection();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
        
            resetField();
            txtDVT.Enabled = true;
            txtDVT.Focus();
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtDVT.Text.Equals(""))
            {
                MessageBox.Show("Mã đơn vị tính không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(txtTen.Text.Equals(""))
            {
                MessageBox.Show("Tên đơn vị tính không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    clsDatabase.OpenConnection();
                    com = new SqlCommand("sp_themdvt", clsDatabase.con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@id", SqlDbType.Int).Value = txtDVT.Text;
                    com.Parameters.Add("@tendvtinh", SqlDbType.NVarChar).Value = txtTen.Text;
                    com.ExecuteNonQuery();
                    MessageBox.Show("Thêm đơn vị tính mới thành công !", "Thông báo", MessageBoxButtons.OK);
                    loadDataDVT();
                    resetField();
                    txtDVT.Enabled = false;
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnLuu.Enabled = false;
                    com.Dispose();
                    clsDatabase.CloseConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Mã đơn vị tính trùng. Thao tác không thành công !" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDVT.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTen.Text.Equals(""))
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa đơn vị tính này không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                try
                {
                    clsDatabase.OpenConnection();
                    string strDelete = "Delete From DVT Where id = '" + txtDVT.Text + "' ";
                    SqlCommand com = new SqlCommand(strDelete, clsDatabase.con);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công !", "Thông báo", MessageBoxButtons.OK);
                    loadDataDVT();
                    com.Dispose();
                    resetField();
                    clsDatabase.CloseConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ! Mã đơn vị tính đang được sử dụng !", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTen.Text.Equals("") && txtDVT.Text.Equals(""))
            {
                MessageBox.Show("Bạn chưa chọn dòng nào để sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtTen.Text.Equals(""))
            {
                MessageBox.Show("Tên đơn vị tính không được bỏ trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDVT.Focus();
            }
            else
            {
                try
                {
                    txtDVT.Enabled = false;
                    clsDatabase.OpenConnection();
                    string strUpdate = "Update DVT Set Tendvt = N'" + txtTen.Text + "' Where id = '" + txtDVT.Text + "'";
                    SqlCommand com = new SqlCommand(strUpdate, clsDatabase.con);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thông tin thành công !", "Thông báo", MessageBoxButtons.OK);
                    loadDataDVT();
                    com.Dispose();
                    resetField();
                    clsDatabase.CloseConnection();
                }
                catch (Exception ex)
                {
                   // MessageBox.Show("LỖI ! BẠN CHƯA CHỌN DỮ LIÊU NÀO ĐỂ SỬA !", "LỖI", MessageBoxButtons.OK);
                }
            }
        }

        private void dgvDVT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDVT.Focus();
                return;
            }
            else if (dgvDVT.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    int i = dgvDVT.CurrentCell.RowIndex; //i là số dòng đang click vào
                    txtDVT.Text = dgvDVT.Rows[i].Cells[0].Value.ToString();
                    txtTen.Text = dgvDVT.Rows[i].Cells[1].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            this.Search_TenDVT();
        }
        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            this.Search_TenDVT();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            resetField();
            txtDVT.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void txtDVT_KeyPress(object sender, KeyPressEventArgs e)
        {

                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }        
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DVT", clsDatabase.con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                dgvDVT.DataSource = dt;
            }
            catch (Exception)
            {

            }
        }
    }    
}
