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
    public partial class frmTonKho : DevExpress.XtraEditors.XtraForm
    {

        private DataTable dt;
        private SqlDataAdapter da;
        private SqlCommand com;
        public frmTonKho()
        {
            InitializeComponent();
        }

        #region Load dữ liệu lên DataGridView
        void loadDataGridView()
        {
            string sql = "SELECT Mahh, Tenhh, Soluonghh, (Giaxuat * Soluonghh) AS [TK] FROM HangHoa";
            dt = clsDatabase.GetDataToTable(sql);
            dgvTonKho.DataSource = dt;
            dgvTonKho.AllowUserToAddRows = false;
            dgvTonKho.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        #endregion

        private void frmTonKho_Load(object sender, EventArgs e)
        {
            clsDatabase.OpenConnection();
            loadDataGridView();
            clsDatabase.CloseConnection();
        }
    
    
    }
}