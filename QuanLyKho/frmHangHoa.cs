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
    public partial class frmHangHoa : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dt;
        private SqlDataAdapter da;
        private SqlCommand com;
        public frmHangHoa()
        {
            InitializeComponent();
        }

        #region Load dữ liệu lên DataGridView
        void loadDataGridView()
        {
            string sql = "SELECT Mahh, Tenhh, idDVT, B.Tendvt, A.Mancc, C.Tenncc, Soluonghh, Giaxuat FROM HangHoa AS A, DVT AS B, NhaCungCap AS C WHERE A.idDVT = B.id AND A.Mancc = C.Mancc";
            dt = clsDatabase.GetDataToTable(sql);
            dgvHH.DataSource = dt;
        }
        #endregion

        #region Load hàng hóa khi form mở lên
        private void frmHangHoa_Load(object sender, EventArgs e)
        {

            clsDatabase.OpenConnection();
            //Nạp dữ liệu lên combobox Đơn vị tính
            clsDatabase.FillCombo("SELECT id, Tendvt FROM DVT", cboDVT, "id", "Tendvt");
            //Nạp dữ liệu lên combobox Nhà cung cấp
            clsDatabase.FillCombo("SELECT Mancc, Tenncc FROM NhaCungCap", cboNCC, "Mancc", "Tenncc");
            cboDVT.Text = "";
            cboNCC.Text = "";
            loadDataGridView();
            dgvHH.ClearSelection();
            btnLuu.Enabled = false;
            clsDatabase.CloseConnection();
        }
        #endregion

        #region ResetField
        void resetField()
        {
            txtMahh.Clear();
            txtTenhh.Clear();
            cboDVT.Text = "";
            cboNCC.Text = "";
            txtMahh.BackColor = System.Drawing.SystemColors.ControlLight;
        }
        #endregion

        #region Method tìm kiếm tên hàng hóa
        void Search_tenHang()
        {
            try
            {
                clsDatabase.OpenConnection();
                com = new SqlCommand("sp_getTenHangHoa", clsDatabase.con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter("@tenhang", txtTimTH.Text.Trim()));
                SqlDataReader reader = com.ExecuteReader();
                dt = new DataTable();
                dt.Load(reader);
                this.dgvHH.DataSource = dt;
            }
            catch (Exception) { }
        }
        #endregion

        #region Method tìm kiếm mã hàng hóa
        void Search_maHang()
        {
            try
            {
                clsDatabase.OpenConnection();
                com = new SqlCommand("sp_getMaHangHoa", clsDatabase.con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter("@mahang", txtTimMH.Text.Trim()));
                SqlDataReader reader = com.ExecuteReader();
                dt = new DataTable();
                dt.Load(reader);
                this.dgvHH.DataSource = dt;
            }
            catch (Exception) { }
        }
        #endregion

        #region Xử lý sự kiện nút Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            resetField();
            txtMahh.BackColor = Color.White;
            txtMahh.Enabled = true;
            txtMahh.Focus();
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
            if (dgvHH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMahh.Text.Equals(""))
            {
                MessageBox.Show("Bạn chưa chọn dòng nào đê sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenhh.Text.Trim().Equals(""))
            {
                MessageBox.Show("Tên hàng hóa không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenhh.Focus();
                return;
            }
            if (cboDVT.Text.Trim().Equals(""))
            {
                MessageBox.Show("Đơn vị tính không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboDVT.Focus();
                return;
            }
            if (cboNCC.Text.Trim().Equals(""))
            {
                MessageBox.Show("Nhà cung cấp không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboNCC.Focus();
                return;
            }
            try
            {
                clsDatabase.OpenConnection();
                com = new SqlCommand("sp_updateHangHoa", clsDatabase.con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@mahang", SqlDbType.NVarChar).Value = txtMahh.Text.Trim();
                com.Parameters.Add("@tenhang", SqlDbType.NVarChar).Value = txtTenhh.Text.Trim();
                com.Parameters.Add("@madvt", SqlDbType.Int).Value = cboDVT.SelectedValue;
                com.Parameters.Add("@macungcap", SqlDbType.Int).Value = cboNCC.SelectedValue;
                com.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thông tin hàng hóa thành công !", "Thông báo", MessageBoxButtons.OK);
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
            if (dgvHH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMahh.Text.Equals(""))
            {
                MessageBox.Show("Bạn chưa chọn dòng nào đê xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa mặt hàng này không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    clsDatabase.OpenConnection();
                    string strDelete = "Delete From HangHoa Where Mahh = '" + txtMahh.Text + "' ";
                    SqlCommand com = new SqlCommand(strDelete, clsDatabase.con);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Xóa mặt hàng này thành công !", "Thông báo", MessageBoxButtons.OK);
                    loadDataGridView();
                    com.Dispose();
                    resetField();
                    clsDatabase.CloseConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ! Mã hàng này đang liên kết với phiếu xuất kho hoặc phiếu nhập kho !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Xử lý sự kiện nút Hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            resetField();
            txtMahh.Enabled = false;
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
            if (txtMahh.Text.Trim().Equals(""))
            {
                MessageBox.Show("Mã hàng không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMahh.Focus();
                return;
            }
            if (txtTenhh.Text.Trim().Equals(""))
            {
                MessageBox.Show("Tên hàng không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenhh.Focus();
                return;
            }
            if (cboDVT.Text.Trim().Equals(""))
            {
                MessageBox.Show("Đơn vị tính không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboDVT.Focus();
                return;
            }
            if (cboNCC.Text.Trim().Equals(""))
            {
                MessageBox.Show("Nhà cung cấp không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboNCC.Focus();
                return;
            }
            sql = "SELECT Mahh FROM HangHoa WHERE Mahh = N'" + txtMahh.Text.Trim() + "'";
            if (clsDatabase.checkKey(sql))
            {
                MessageBox.Show("Mã hàng này đã tồn tại, bạn phải chọn mã hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMahh.Focus();
                return;
            }
            clsDatabase.OpenConnection();
            com = new SqlCommand("sp_themHangHoa", clsDatabase.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@mahang", SqlDbType.NVarChar).Value = txtMahh.Text.Trim();
            com.Parameters.Add("@tenhang", SqlDbType.NVarChar).Value = txtTenhh.Text.Trim();
            com.Parameters.Add("@madvt", SqlDbType.Int).Value = cboDVT.SelectedValue;
            com.Parameters.Add("@macungcap", SqlDbType.Int).Value = cboNCC.SelectedValue;
            com.ExecuteNonQuery();
            MessageBox.Show("Thêm hàng hóa mới thành công !", "Thông báo", MessageBoxButtons.OK);
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

        #region Sự kiện khi click vào 1 dòng của DataGridView
        private void dgvHH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string maDvt;
            string maNcc;
            string sql1;
            string sql2;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMahh.Focus();
            }
            else if (dgvHH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    clsDatabase.OpenConnection();
                    int i = dgvHH.CurrentCell.RowIndex;
                    txtMahh.Text = dgvHH.Rows[i].Cells[0].Value.ToString();
                    txtTenhh.Text = dgvHH.Rows[i].Cells[1].Value.ToString();
                    maDvt = dgvHH.Rows[i].Cells[2].Value.ToString();
                    sql1 = "SELECT Tendvt FROM DVT WHERE id = N'" + maDvt + "'";
                    cboDVT.Text = clsDatabase.GetFieldValues(sql1);
                    maNcc = dgvHH.Rows[i].Cells[4].Value.ToString();
                    sql2 = "SELECT Tenncc FROM NhaCungCap WHERE Mancc = N'" + maNcc + "'";
                    cboNCC.Text = clsDatabase.GetFieldValues(sql2);
                    clsDatabase.CloseConnection();
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
                txtTimMH.Clear();
                txtTimTH.Clear();
                loadDataGridView();
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region Sự kiện nhập lên textbox TimTH để tìm mặt hàng theo tên
        private void txtTimTH_TextChanged(object sender, EventArgs e)
        {
            this.Search_tenHang();
        }
        #endregion

        #region Sự kiện nhập lên textbox TimMH để tìm mặt hàng theo mã hàng
        private void txtTimMH_TextChanged(object sender, EventArgs e)
        {
            this.Search_maHang();
        } 
        #endregion
    }
}
