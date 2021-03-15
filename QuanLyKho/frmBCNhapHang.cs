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
    public partial class frmBCNhapHang : DevExpress.XtraEditors.XtraForm
    {

        private DataTable dt;
        private SqlDataAdapter da;
        private SqlCommand com;
        public frmBCNhapHang()
        {
            InitializeComponent();
        }


        
        #region load dữ liệu lên DataGridView
        void loadDataGridViewNHAP()
        {
            string sql = "SELECT a.Mahh, b.Tenhh, SUM(a.Soluongnhap) AS Nhap FROM ChiTietPhieuNhap AS a, HangHoa AS b WHERE a.Mahh = b.Mahh GROUP BY a.Mahh, b.Tenhh";
            dt = clsDatabase.GetDataToTable(sql);
            dgvNhap.DataSource = dt;
            dgvNhap.AllowUserToAddRows = false;
            dgvNhap.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        #endregion


        #region Phuong thức tìm kiếm từ ngày đến ngày
        void Search_SLuongNK()
        {
            try
            {
                clsDatabase.OpenConnection();
                com = new SqlCommand("getAllSLuongNhap", clsDatabase.con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter("@tungay", dtTuNgay.Value));
                com.Parameters.Add(new SqlParameter("@denngay", dtDenNgay.Value));
                SqlDataReader reader = com.ExecuteReader();
                dt = new DataTable();
                dt.Load(reader);
                this.dgvNhap.DataSource = dt;
            }
            catch (Exception) { }
        }
        #endregion



        private void frmNXT_Load(object sender, EventArgs e)
        {
            clsDatabase.OpenConnection();
            loadDataGridViewNHAP();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dtDenNgay.Text = "";
            dtTuNgay.Text = "";
            loadDataGridViewNHAP();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
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
            Search_SLuongNK();
        }
    }
}