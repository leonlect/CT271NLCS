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
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        private SqlCommand com;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsDatabase.OpenConnection();
            string sql = "SELECT taikhoan, matkhau FROM users WHERE taikhoan = N'" + txtTaiKhoan.Text.Trim() + "' AND matkhau =  N'" + txtMatKhau.Text.Trim() + "'";
            com = new SqlCommand(sql, clsDatabase.con);
            SqlDataReader reader = com.ExecuteReader();
            if(reader.Read() == true)
            {
                clsDatabase.CloseConnection();
                this.Hide();
                Form main = new frmMain();
                MessageBox.Show("Kết nối cơ sở dữ liệu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                main.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTaiKhoan.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}