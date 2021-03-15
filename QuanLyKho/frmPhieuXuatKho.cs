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
using System.Globalization;



namespace QuanLyKho
{
    public partial class frmPhieuXuatKho : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dt;
        private SqlDataAdapter da;
        private SqlCommand com;
        public frmPhieuXuatKho()
        {
            InitializeComponent();
        }

        #region Load dữ liệu lên DataGridView
        void loadDataGridView()
        {
            string sql = "SELECT a.Mahh, b.Tenhh, a.Soluongxuat, b.Giaxuat, a.Thanhtien FROM ChiTietPhieuXuat AS A, HangHoa AS B WHERE a.Sttpxk = N'" + txtMaPXK.Text + "' AND a.Mahh = b.Mahh";
            dt = clsDatabase.GetDataToTable(sql);
            dgvPhieuXuat.DataSource = dt;
            dgvPhieuXuat.AllowUserToAddRows = false;
            dgvPhieuXuat.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        #endregion

        #region Load phiếu xuất kho khi xuất lên
        private void frmPhieuXuatKho_Load(object sender, EventArgs e)
        {
            clsDatabase.OpenConnection();
            txtTenKH.ReadOnly = true;
            txtDiachi.ReadOnly = true;
            txtDienthoai.ReadOnly = true;
            txtTenHang.ReadOnly = true;
            txtDongia.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtTongtien.ReadOnly = true;
            txtTongtien.Text = "0";
            clsDatabase.FillCombo("SELECT Makh, Tenkh FROM KhachHang", cboMaKH, "Makh", "Makh");
            cboMaKH.SelectedIndex = -1;
            clsDatabase.FillCombo("SELECT Mahh, Tenhh FROM HangHoa", cboMaHang, "Mahh", "Mahh");
            cboMaHang.SelectedIndex = -1;
            if (txtMaPXK.Text != "")
            {
                loadInfoPXK();
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
            txtMaPXK.Text = "";
            dtNgayXuat.Value = DateTime.Now;
            cboMaKH.Text = "";
            cboMaHang.Text = "";
            txtDongia.Text = "";
            txtTongtien.Text = "0";
            txtThanhTien.Text = "0";
            txtSoluong.Text = "";
            txtMaPXK.BackColor = System.Drawing.SystemColors.ControlLight;
        }

        #endregion

        #region resetValuesHang
        void resetValuesHang()
        {
            cboMaHang.Text = "";
            txtTenHang.Text = "";
            txtSoluong.Text = "";
            txtThanhTien.Text = "0";
            txtTonKho.Text = "";
            txtDongia.Text = "";
        }
        #endregion

        #region Method hiển thị thông tin phiếu xuất kho khi click vào và truyền lên các control loadInfoPXK()
        void loadInfoPXK() //LoadInfoHoaDon
        {
            clsDatabase.OpenConnection();
            string str;
            str = "SELECT Datepxk FROM PhieuXuatKho WHERE Sttpxk = N'" + txtMaPXK.Text + "'";
            dtNgayXuat.Value = DateTime.Parse(clsDatabase.GetFieldValues(str));
            str = "SELECT Makh FROM PhieuXuatKho WHERE Sttpxk = N'" + txtMaPXK.Text + "'";
            cboMaKH.SelectedValue = clsDatabase.GetFieldValues(str);
            str = "SELECT Tongtienpxk FROM PhieuXuatKho WHERE Sttpxk = N'" + txtMaPXK.Text + "'";
            txtTongtien.Text = clsDatabase.GetFieldValues(str);
        }
        #endregion

        #region Method hiển thị tên hàng và đơn giá khi chọn từ combobox cboMaHang_SelectedIndexChanged
        private void cboMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsDatabase.OpenConnection();
            string str;
            if (cboMaHang.Text == "")
            {
                txtTenHang.Clear();
                txtDongia.Clear();
                txtTonKho.Clear();
            }
            str = "SELECT Tenhh FROM HangHoa WHERE Mahh = N'" + cboMaHang.SelectedValue + "'";
            txtTenHang.Text = clsDatabase.GetFieldValues(str);
            str = "SELECT Giaxuat FROM HangHoa WHERE Mahh = N'" + cboMaHang.SelectedValue + "'";
            txtDongia.Text = clsDatabase.GetFieldValues(str);
            str = "SELECT Soluonghh FROM HangHoa WHERE Mahh = N'" + cboMaHang.SelectedValue + "'";
            txtTonKho.Text = clsDatabase.GetFieldValues(str);
            //clsDatabase.CloseConnection();
        }
        #endregion

        #region Method hiển thị thông tin khách hàng khi chọn từ combobox cboMaKH_SelectedIndexChanged
        private void cboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsDatabase.OpenConnection();
            string str;
            if (cboMaKH.Text == "")
            {
                txtTenKH.Text = "";
                txtDiachi.Text = "";
                txtDienthoai.Text = "";
            }
            str = "SELECT Tenkh FROM KhachHang WHERE Makh = N'" + cboMaKH.SelectedValue + "'";
            txtTenKH.Text = clsDatabase.GetFieldValues(str);
            str = "SELECT Diachikh FROM KhachHang WHERE Makh = N'" + cboMaKH.SelectedValue + "'";
            txtDiachi.Text = clsDatabase.GetFieldValues(str);
            str = "SELECT Sdtkh FROM KhachHang WHERE Makh = N'" + cboMaKH.SelectedValue + "'";
            txtDienthoai.Text = clsDatabase.GetFieldValues(str);
            //    clsDatabase.CloseConnection();
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

        #region Xử lý sự kiện nút Thêm phiếu xuất kho
        private void btnThem_Click(object sender, EventArgs e)
        {
            resetField();
            txtMaPXK.BackColor = Color.White;
            txtMaPXK.Enabled = true;
            txtMaPXK.Focus();
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            loadDataGridView();
        }

        #endregion

        #region Xử lý sự kiện nút Thêm (thêm vào PhieuXuatKho và ChiTietPhieuXuat)
        private void btnLuu_Click(object sender, EventArgs e)
        {
            clsDatabase.OpenConnection();
            string sql;
            double sl, slcon, tong, Tongmoi;
            if (txtMaPXK.Text.Equals(""))
            {
                MessageBox.Show("Mã phiếu xuất kho không được để trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPXK.Focus();
                return;
            }
            try
            {
                #region Đoạn này là chèn dữ liệu Sttpxk, Datepxk, Makh, Tongtienpxk vào bảng PXK trước
                sql = "SELECT Sttpxk FROM PhieuXuatKho WHERE Sttpxk = N'" + txtMaPXK.Text + "'";

                /*                if (clsDatabase.checkKey(sql))
                                {
                                    MessageBox.Show("Mã phiếu xuất kho đã tồn tại. Nhập lại phiếu khác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtMaPXK.Focus();
                                    return;
                                }*/

                if (!clsDatabase.checkKey(sql))
                {
                    if (cboMaKH.Text.Equals(""))
                    {
                        MessageBox.Show("Bạn phải chọn mã khách hàng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cboMaKH.Focus();
                        return;
                    }
                    //@mapxk, @ngayxuat, @makh, @Tong
                    com = new SqlCommand("sp_themPXK", clsDatabase.con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@mapxk", SqlDbType.NVarChar).Value = txtMaPXK.Text;
                    com.Parameters.Add("@ngayxuat", SqlDbType.DateTime).Value = dtNgayXuat.Text;
                    com.Parameters.Add("@makh", SqlDbType.NVarChar).Value = cboMaKH.SelectedValue;
                    com.Parameters.Add("@Tong", SqlDbType.Float).Value = float.Parse(txtTongtien.Text.ToString());
                    com.ExecuteNonQuery();
                    // MessageBox.Show("Thêm PXK thành công !");
                }
                #endregion

                #region Đoạn tiếp theo chèn vào bảng ChiTietPhieuXuatKho để lưu thông tin mặt hàng
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

                sql = "SELECT Mahh FROM ChiTietPhieuXuat WHERE Mahh = N'" + cboMaHang.SelectedValue + "' AND Sttpxk = N'" + txtMaPXK.Text.Trim() + "'";
                if (clsDatabase.checkKey(sql))
                {
                    MessageBox.Show("Mã hàng này đã tồn tại. Chọn lại mã khác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetValuesHang();
                    cboMaHang.Focus();
                    return;
                }

                //// Kiểm tra xem số lượng hàng tồn !!!
                sl = Convert.ToDouble(clsDatabase.GetFieldValues("SELECT Soluonghh FROM HangHoa WHERE Mahh = N'" + cboMaHang.SelectedValue + "'"));
                if (Convert.ToDouble(txtSoluong.Text) > sl)
                {
                    MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSoluong.Text = "";
                    txtSoluong.Focus();
                    return;
                }

                sql = "INSERT INTO ChiTietPhieuXuat(Sttpxk,Mahh,Soluongxuat,Giaxuat, Thanhtien) VALUES(N'" + txtMaPXK.Text.Trim() + "',N'" + cboMaHang.SelectedValue + "'," + txtSoluong.Text + "," + txtDongia.Text + "," + txtThanhTien.Text + ")";
                clsDatabase.RunSQL(sql);
                loadDataGridView();
                //Cập nhật lại số lượng mặt hàng trong bảng Hàng hóa
                slcon = sl - Convert.ToDouble(txtSoluong.Text);
                sql = "UPDATE HangHoa SET Soluonghh = " + slcon + " WHERE Mahh = N'" + cboMaHang.SelectedValue + "'";
                clsDatabase.RunSQL(sql);
                //Cập nhật lại tổng tiền cho phiếu xuất kho
                tong = Convert.ToDouble(clsDatabase.GetFieldValues("SELECT Tongtienpxk FROM PhieuXuatKho WHERE Sttpxk = N'" + txtMaPXK.Text + "'"));
                Tongmoi = tong + Convert.ToDouble(txtThanhTien.Text);
                sql = "UPDATE PhieuXuatKho SET Tongtienpxk = " + Tongmoi + "WHERE Sttpxk = N'" + txtMaPXK.Text + "'";
                clsDatabase.RunSQL(sql);
                txtTongtien.Text = Tongmoi.ToString();
                resetValuesHang();
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = true;
                #endregion
            }// Try
            catch (Exception)
            {
                MessageBox.Show("Mã phiếu xuất kho đã tồn tại. Nhập lại mã khác !");
            } //catch

        }

        #endregion

        #region Xử lý sự kiện nút Hủy phiếu xuất kho
        private void btnXoa_Click(object sender, EventArgs e)
        {
            clsDatabase.OpenConnection();
            double sl, slton, slxoa;
            if (txtMaPXK.Text.Equals(""))
            {
                MessageBox.Show("Bạn chưa chọn mã phiếu xuất kho nào để xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaPXK.Focus();
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa phiếu xuất kho này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                string sql = "SELECT Mahh, Soluongxuat FROM ChiTietPhieuXuat WHERE Sttpxk = N'" + txtMaPXK.Text + "'";
                DataTable matHang = clsDatabase.GetDataToTable(sql);
                for (int i = 0; i <= matHang.Rows.Count - 1; i++)
                {
                    //Cập nhật số lượng lại các mặt hàng
                    sl = Convert.ToDouble(clsDatabase.GetFieldValues("SELECT Soluonghh FROM HangHoa WHERE Mahh = N'" + matHang.Rows[i][0].ToString() + "'"));
                    slxoa = Convert.ToDouble(matHang.Rows[i][1].ToString());
                    slton = sl + slxoa;
                    sql = "UPDATE HangHoa SET Soluonghh = " + slton + " WHERE Mahh = N'" + matHang.Rows[i][0].ToString() + "'";
                    clsDatabase.RunSQL(sql);
                }

                //Xóa từ chi tiết phiếu xuất
                sql = "DELETE ChiTietPhieuXuat WHERE Sttpxk = N'" + txtMaPXK.Text + "'";
                clsDatabase.RunSQL(sql);

                //Xóa phiếu xuất kho
                sql = "DELETE PhieuXuatKho WHERE Sttpxk = N'" + txtMaPXK.Text + "'";
                clsDatabase.RunSQL(sql);
                resetField();
                loadDataGridView();
                btnThem.Enabled = true;
                btnXoa.Enabled = false;
                MessageBox.Show("Xóa phiếu xuất kho thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsDatabase.CloseConnection();
            }
        }
        #endregion

        #region Xử lý sự kiện nút Tìm kiếm cho PXK
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPXK.Focus();
                return;
            }
            if (cboMaPXK.Text == "")
            {
                MessageBox.Show("Chọn một phiếu xuất kho để tìm kiếm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaPXK.Focus();
                return;
            }
            txtMaPXK.Text = cboMaPXK.Text;
            loadInfoPXK();
            loadDataGridView();
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
            cboMaPXK.SelectedIndex = -1;
        }
        #endregion

        #region Sự kiện dropdown của combobox Mã phiếu xuất kho
        private void cboMaPXK_DropDown(object sender, EventArgs e)
        {
            clsDatabase.FillCombo("SELECT Sttpxk FROM PhieuXuatKho", cboMaPXK, "Sttpxk", "Sttpxk");
            cboMaPXK.SelectedIndex = -1;
        }
        #endregion

        #region Sự kiện double-click vào một dòng trên GridView để xóa mặt hàng
        private void dgvPhieuXuat_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            clsDatabase.OpenConnection();
            string mhXoa, sql;
            Double thanhTienXoa, slXoa, sl, slton, tong, tongmoi;
            if (dgvPhieuXuat.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa mặt hàng này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Delete and update Soluonghh
                mhXoa = dgvPhieuXuat.CurrentRow.Cells[0].Value.ToString();
                //MessageBox.Show(mhXoa);
                slXoa = Convert.ToDouble(dgvPhieuXuat.CurrentRow.Cells[2].Value.ToString());
                thanhTienXoa = Convert.ToDouble(dgvPhieuXuat.CurrentRow.Cells[4].Value.ToString());
                sql = "DELETE ChiTietPhieuXuat WHERE Sttpxk = N'" + txtMaPXK.Text + "' AND Mahh = N'" + mhXoa + "'";
                clsDatabase.RunSQL(sql);
                //Cap nhat lai so luong cho cac mat hang
                sl = Convert.ToDouble(clsDatabase.GetFieldValues("SELECT Soluonghh FROM HangHoa WHERE Mahh = N'" + mhXoa + "'"));
                slton = sl + slXoa;
                sql = "UPDATE HangHoa SET Soluonghh = " + slton + " WHERE Mahh = N'" + mhXoa + "'";
                clsDatabase.RunSQL(sql);


                // Cập nhật lại tổng tiền cho hóa đơn bán
                tong = Convert.ToDouble(clsDatabase.GetFieldValues("SELECT Tongtienpxk FROM PhieuXuatKho WHERE Sttpxk = N'" + txtMaPXK.Text + "'"));
                tongmoi = tong - thanhTienXoa;
                sql = "UPDATE PhieuXuatKho SET Tongtienpxk =" + tongmoi + " WHERE Sttpxk = N'" + txtMaPXK.Text + "'";
                clsDatabase.RunSQL(sql);
                txtTongtien.Text = tongmoi.ToString();
                loadDataGridView();
                clsDatabase.CloseConnection();

            }
        }

        #endregion

        #region Xử lý sự kiện nút Hủy thao tác
        private void btnHuyThaoTac_Click(object sender, EventArgs e)
        {
            resetField();
            resetValuesHang();
            loadDataGridView();
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
        }


        #endregion    }

        #region Xử lý sự kiện nút Đóng
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion



    }
}