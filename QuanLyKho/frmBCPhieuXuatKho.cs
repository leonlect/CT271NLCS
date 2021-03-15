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
    public partial class frmBCPhieuXuatKho : DevExpress.XtraEditors.XtraForm
    {

        private DataTable dt;
        private SqlDataAdapter da;
        private SqlCommand com;
        public frmBCPhieuXuatKho()
        {
            InitializeComponent();
        }


        #region load dữ liệu lên DataGridView
        void loadDataGridView()
        {
            string sql = "SELECT * FROM PhieuXuatKho";
            dt = clsDatabase.GetDataToTable(sql);
            dgvTKXK.DataSource = dt;
            dgvTKXK.AllowUserToAddRows = false;
            dgvTKXK.EditMode = DataGridViewEditMode.EditProgrammatically;
        }


        #endregion

        #region Phuong thức tìm kiếm từ ngày đến ngày
        void Search_PXK()
        {
            try
            {
                clsDatabase.OpenConnection();
                com = new SqlCommand("sp_getPXKbyDate", clsDatabase.con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter("@tungay", dtTuNgay.Value));
                com.Parameters.Add(new SqlParameter("@denngay", dtDenNgay.Value));
                SqlDataReader reader = com.ExecuteReader();
                dt = new DataTable();
                dt.Load(reader);
                this.dgvTKXK.DataSource = dt;
            }
            catch (Exception) { }
        }
        #endregion


        private void frmBCXuatKho_Load(object sender, EventArgs e)
        {
            clsDatabase.OpenConnection();
            loadDataGridView();
            clsDatabase.CloseConnection();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (dtTuNgay.Text.Equals(""))
            {
                MessageBox.Show("Nhập ngày bắt đầu cần tìm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtTuNgay.Focus();
                return;
            }
            if (dtDenNgay.Text.Equals(""))
            {
                MessageBox.Show("Nhập ngày kết thúc cần tìm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtDenNgay.Focus();
                return;
            }
            Search_PXK();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtPXK.Text = "";
            dtTuNgay.Text = "";
            dtDenNgay.Text = "";
            loadDataGridView();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtPXK.Text == "")
            {
                MessageBox.Show("Click lên 1 dòng tương ứng để chọn 1 phiếu xuất cần hiển thị !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmPhieuXuatKho frm = new frmPhieuXuatKho();
                frm.txtMaPXK.Text = txtPXK.Text;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }

        private void dgvTKXK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPXK.Text = dgvTKXK.CurrentRow.Cells[0].Value.ToString();
        }
    
    
    }
}