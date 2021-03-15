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

    public partial class frmPhieuNhapKho : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dt;
        private SqlDataAdapter da;
        private SqlCommand com;
        public frmPhieuNhapKho()
        {
            InitializeComponent();
        }

        #region Load dữ liệu lên DataGridView
        void loadDataGridView()
        {
            string sql = "SELECT a.Mahh, b.Tenhh, a.Soluongnhap, a.Gianhap, a.Thanhtien FROM ChiTietPhieuNhap AS A, HangHoa AS B WHERE a.Sttpnk = N'" + txtMaPNK.Text + "' AND a.Mahh = b.Mahh";
            dt = clsDatabase.GetDataToTable(sql);
            dgvPhieuNhap.DataSource = dt;
            dgvPhieuNhap.AllowUserToAddRows = false;
            dgvPhieuNhap.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        #endregion

        #region Load phiếu nhập kho khi bật lên
        private void frmPhieuNhapKho_Load(object sender, EventArgs e)
        {
            clsDatabase.OpenConnection();
            txtTenHang.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtTongtien.ReadOnly = true;
            txtTongtien.Text = "0";

            clsDatabase.FillCombo("SELECT Mahh, Tenhh FROM HangHoa", cboMaHang, "Mahh", "Mahh");
            cboMaHang.SelectedIndex = -1;
            if (txtMaPNK.Text != "")
            {
                loadInfoPNK();
                btnXoa.Enabled = true;
            }
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            loadDataGridView();
            // clsDatabase.CloseConnection();
        }

        #endregion

        #region resetField
        void resetField()
        {
            txtMaPNK.Text = "";
            dtNgayNhap.Value = DateTime.Now;
            cboMaHang.Text = "";
            txtDongia.Text = "";
            txtTongtien.Text = "0";
            txtThanhTien.Text = "0";
            txtSoluong.Text = "";
            txtMaPNK.BackColor = System.Drawing.SystemColors.ControlLight;
        }

        #endregion

        #region resetValuesHang
        void resetValuesHang()
        {
            cboMaHang.Text = "";
            txtTenHang.Text = "";
            txtSoluong.Text = "";
            txtThanhTien.Text = "0";
            txtDongia.Text = "";
        }
        #endregion

        #region Method hiển thị thông tin phiếu nhập kho khi click vào và truyền lên các control loadInfoPNK()
        void loadInfoPNK() //LoadInfoHoaDon
        {
            clsDatabase.OpenConnection();
            string str;
            str = "SELECT Datepnk FROM PhieuNhapKho WHERE Sttpnk = N'" + txtMaPNK.Text + "'";
            dtNgayNhap.Value = DateTime.Parse(clsDatabase.GetFieldValues(str));
            str = "SELECT Tongtien FROM PhieuNhapKho WHERE Sttpnk = N'" + txtMaPNK.Text + "'";
            txtTongtien.Text = clsDatabase.GetFieldValues(str);
        }

        #endregion

        #region Method hiển thị tên hàng khi chọn từ combobox cboMaHang_SelectedIndexChanged
        private void cboMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsDatabase.OpenConnection();
            string str;
            if (cboMaHang.Text == "")
            {
                txtTenHang.Clear();
                txtDongia.Clear();
            }
            str = "SELECT Tenhh FROM HangHoa WHERE Mahh = N'" + cboMaHang.SelectedValue + "'";
            txtTenHang.Text = clsDatabase.GetFieldValues(str);
            //clsDatabase.CloseConnection();
        }

        #endregion

        #region Method chỉ nhận kiểu số ở textbox Số lượng
        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
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
        #endregion

        #region Method chỉ nhận kiểu số ở textbox Đơn giá
        private void txtDongia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        #endregion 

        #region Method thay đổi số lượng thì thành tiền thay đổi theo txtSoluongTextChanged
        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg;
            if (txtSoluong.Text.Equals(""))
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtDongia.Text.Equals(""))
                dg = 0;
            else
                dg = Convert.ToDouble(txtDongia.Text);
            tt = sl * dg;
            txtThanhTien.Text = tt.ToString();
        }



        #endregion

        #region Method thay đổi đơn giá thì thành tiền thay đổi theo txtDongiaTextChanged
        private void txtDongia_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg;
            if (txtDongia.Text.Equals(""))
                dg = 0;
            else
                dg = Convert.ToDouble(txtDongia.Text);
            if (txtSoluong.Text.Equals(""))
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            tt = sl * dg;
            txtThanhTien.Text = tt.ToString();
        }

        #endregion

        #region Xử lý sự kiện thêm phiếu nhập kho
        private void btnThem_Click(object sender, EventArgs e)
        {
            resetField();
            txtMaPNK.BackColor = Color.White;
            txtMaPNK.Enabled = true;
            txtMaPNK.Focus();
            txtDongia.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            loadDataGridView();
        }


        #endregion

        #region Xử lý sự kiện nút Thêm (thêm vào PhieuNhapKho và ChiTietPhieuNhap)
        private void btnLuu_Click(object sender, EventArgs e)
        {
            clsDatabase.OpenConnection();
            string sql;
            double sl, slcon, tong, Tongmoi;
            if (txtMaPNK.Text.Equals(""))
            {
                MessageBox.Show("Mã phiếu nhập kho không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPNK.Focus();
                return;
            }
            #region Đoạn này là chèn dữ liệu Sttpnk, Datepnk, Tongtien vào bảng PNK trước
            sql = "SELECT Sttpnk FROM PhieuNhapKho WHERE Sttpnk = N'" + txtMaPNK.Text + "'";
            if (!clsDatabase.checkKey(sql))
            {
                /*                if (cboMaHang.Text.Equals(""))
                                {
                                    MessageBox.Show("Bạn phải chọn mã hàng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    cboMaHang.Focus();
                                    return;
                                }*/
                //@mapxk, @ngayxuat, @makh, @Tong
                com = new SqlCommand("sp_themPNK", clsDatabase.con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@mapnk", SqlDbType.NVarChar).Value = txtMaPNK.Text;
                com.Parameters.Add("@ngaynhap", SqlDbType.DateTime).Value = dtNgayNhap.Text;
                com.Parameters.Add("@Tong", SqlDbType.Float).Value = float.Parse(txtTongtien.Text.ToString());
                com.ExecuteNonQuery();
                //  MessageBox.Show("Thêm PNK thành công !");
                #endregion
            }

            #region Đoạn tiếp theo chèn vào bảng ChiTietPhieuNhap để lưu thông tin mặt hàng
            if (cboMaHang.Text.Equals(""))
            {
                MessageBox.Show("Bạn phải chọn mã hàng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHang.Focus();
                return;
            }

            if (txtSoluong.Text.Equals("") || txtSoluong.Text == "0")
            {
                MessageBox.Show("Bạn phải nhập số lượng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }

            sql = "SELECT Mahh FROM ChiTietPhieuNhap WHERE Mahh = N'" + cboMaHang.SelectedValue + "' AND Sttpnk = N'" + txtMaPNK.Text.Trim() + "'";
            if (clsDatabase.checkKey(sql))
            {
                MessageBox.Show("Mã hàng này đã tồn tại. Chọn lại mã khác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                resetValuesHang();
                cboMaHang.Focus();
                return;
            }

            sql = "INSERT INTO ChiTietPhieuNhap(Sttpnk,Mahh,Soluongnhap,Gianhap, Thanhtien) VALUES(N'" + txtMaPNK.Text.Trim() + "',N'" + cboMaHang.SelectedValue + "'," + txtSoluong.Text + "," + txtDongia.Text + "," + txtThanhTien.Text + ")";
            clsDatabase.RunSQL(sql);
            loadDataGridView();

            //Cập nhật lại số lượng mặt hàng trong bảng Hàng hóa
            sl = Convert.ToDouble(clsDatabase.GetFieldValues("SELECT Soluonghh FROM HangHoa WHERE Mahh = N'" + cboMaHang.SelectedValue + "'"));
            slcon = sl + Convert.ToDouble(txtSoluong.Text);
            sql = "UPDATE HangHoa SET Soluonghh = " + slcon + " WHERE Mahh = N'" + cboMaHang.SelectedValue + "'";
            clsDatabase.RunSQL(sql);

            //Cập nhật lại tổng tiền cho phiếu xuất kho
            tong = Convert.ToDouble(clsDatabase.GetFieldValues("SELECT Tongtien FROM PhieuNhapKho WHERE Sttpnk = N'" + txtMaPNK.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtThanhTien.Text);
            sql = "UPDATE PhieuNhapKho SET Tongtien = " + Tongmoi + "WHERE Sttpnk = N'" + txtMaPNK.Text + "'";
            clsDatabase.RunSQL(sql);

            txtTongtien.Text = Tongmoi.ToString();
            resetValuesHang();
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
            #endregion
        } // ngoac cua ham
        #endregion

        #region Xử lý sự kiện nút Hủy phiếu nhập kho
        private void btnXoa_Click(object sender, EventArgs e)
        {
            clsDatabase.OpenConnection();
            double sl, slton, slxoa;
            if (txtMaPNK.Text.Equals(""))
            {
                MessageBox.Show("Bạn chưa chọn phiếu nhập kho nào để xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaPNK.Focus();
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa phiếu nhập kho này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                string sql = "SELECT Mahh, Soluongnhap FROM ChiTietPhieuNhap WHERE Sttpnk = N'" + txtMaPNK.Text + "'";
                DataTable matHang = clsDatabase.GetDataToTable(sql);
                for (int i = 0; i <= matHang.Rows.Count - 1; i++)
                {
                    //Cập nhật số lượng lại các mặt hàng
                    sl = Convert.ToDouble(clsDatabase.GetFieldValues("SELECT Soluonghh FROM HangHoa WHERE Mahh = N'" + matHang.Rows[i][0].ToString() + "'"));
                    slxoa = Convert.ToDouble(matHang.Rows[i][1].ToString());
                    slton = sl - slxoa;
                    sql = "UPDATE HangHoa SET Soluonghh = " + slton + " WHERE Mahh = N'" + matHang.Rows[i][0].ToString() + "'";
                    clsDatabase.RunSQL(sql);
                }

                //Xóa từ chi tiết phiếu xuất
                sql = "DELETE ChiTietPhieuNhap WHERE Sttpnk = N'" + txtMaPNK.Text + "'";
                clsDatabase.RunSQL(sql);

                //Xóa phiếu xuất kho
                sql = "DELETE PhieuNhapKho WHERE Sttpnk = N'" + txtMaPNK.Text + "'";
                clsDatabase.RunSQL(sql);
                resetField();
                loadDataGridView();
                btnThem.Enabled = true;
                btnXoa.Enabled = false;
                MessageBox.Show("Xóa phiếu nhập kho thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsDatabase.CloseConnection();
            }

        }











        #endregion

        #region Xử lý sự kiện nút Tìm kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPNK.Focus();
                return;
            }
            if (cboMaPNK.Text == "")
            {
                MessageBox.Show("Chọn một phiếu nhập kho để tìm kiếm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaPNK.Focus();
                return;
            }
            txtMaPNK.Text = cboMaPNK.Text;
            loadInfoPNK();
            loadDataGridView();
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
            cboMaPNK.SelectedIndex = -1;
        }






        #endregion

        #region Sự kiện dropdown của combobox Mã phiếu xuất kho
        private void cboMaPNK_DropDown(object sender, EventArgs e)
        {
            clsDatabase.FillCombo("SELECT Sttpnk FROM PhieuNhapKho", cboMaPNK, "Sttpnk", "Sttpnk");
            cboMaPNK.SelectedIndex = -1;
        }



        #endregion

        private void dgvPhieuXuat_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            clsDatabase.OpenConnection();
            string mhXoa, sql;
            Double thanhTienXoa, slXoa, sl, slton, tong, tongmoi;
            if (dgvPhieuNhap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa mặt hàng này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Delete and update Soluonghh
                mhXoa = dgvPhieuNhap.CurrentRow.Cells[0].Value.ToString();
                //MessageBox.Show(mhXoa);
                slXoa = Convert.ToDouble(dgvPhieuNhap.CurrentRow.Cells[2].Value.ToString());
                thanhTienXoa = Convert.ToDouble(dgvPhieuNhap.CurrentRow.Cells[4].Value.ToString());
                sql = "DELETE ChiTietPhieuNhap WHERE Sttpnk = N'" + txtMaPNK.Text + "' AND Mahh = N'" + mhXoa + "'";
                clsDatabase.RunSQL(sql);

                //Cap nhat lai so luong cho cac mat hang
                sl = Convert.ToDouble(clsDatabase.GetFieldValues("SELECT Soluonghh FROM HangHoa WHERE Mahh = N'" + mhXoa + "'"));
                slton = sl - slXoa;
                sql = "UPDATE HangHoa SET Soluonghh = " + slton + " WHERE Mahh = N'" + mhXoa + "'";
                clsDatabase.RunSQL(sql);


                // Cập nhật lại tổng tiền cho hóa đơn bán
                tong = Convert.ToDouble(clsDatabase.GetFieldValues("SELECT Tongtien FROM PhieuNhapKho WHERE Sttpnk = N'" + txtMaPNK.Text + "'"));
                tongmoi = tong - thanhTienXoa;
                sql = "UPDATE PhieuNhapKho SET Tongtien =" + tongmoi + " WHERE Sttpnk = N'" + txtMaPNK.Text + "'";
                clsDatabase.RunSQL(sql);
                txtTongtien.Text = tongmoi.ToString();
                loadDataGridView();
                clsDatabase.CloseConnection();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuyThaoTac_Click(object sender, EventArgs e)
        {
            resetField();
            resetValuesHang();
            loadDataGridView();
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
        }
    }
}