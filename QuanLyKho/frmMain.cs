using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace QuanLyKho
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void giớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongTin frmtt = new frmThongTin();
            frmtt.ShowDialog();
        }

        private void đơnVịTínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDVT frmdvt = new frmDVT();
            frmdvt.Show();
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHangHoa frmDMHangHoa = new frmHangHoa();
            frmDMHangHoa.Show();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNCC frmdmncc = new frmNCC();
            frmdmncc.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKH frmdmkh = new frmKH();
            frmdmkh.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                MessageBox.Show("Cám ơn bạn đã sử dụng chương trình !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }

        }

        private void xuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuXuatKho frmpxk = new frmPhieuXuatKho();
            frmpxk.Show();
        }

        private void nhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuNhapKho frmpnk = new frmPhieuNhapKho();
            frmpnk.Show();
        }

        private void lbKH_Click(object sender, EventArgs e)
        {
            frmKH frmdmkh = new frmKH();
            frmdmkh.Show();
        }

        private void lbHH_Click(object sender, EventArgs e)
        {
            frmHangHoa frmDMHangHoa = new frmHangHoa();
            frmDMHangHoa.Show();
        }

        private void lbNCC_Click(object sender, EventArgs e)
        {
            frmNCC frmdmncc = new frmNCC();
            frmdmncc.Show();
        }

        private void lbNahpKho_Click(object sender, EventArgs e)
        {
            frmPhieuNhapKho frmpnk = new frmPhieuNhapKho();
            frmpnk.Show();
        }

        private void lbXuatKho_Click(object sender, EventArgs e)
        {
            frmPhieuXuatKho frmpxk = new frmPhieuXuatKho();
            frmpxk.Show();
        }

        private void tồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTonKho frmtk = new frmTonKho();
            frmtk.Show();
        }

        private void nhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBCPhieuNhapKho nk = new frmBCPhieuNhapKho();
            nk.Show();
        }

        private void xuấtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBCPhieuXuatKho xk = new frmBCPhieuXuatKho();
            xk.Show();
        }

        private void labelX1_Click(object sender, EventArgs e)
        {
            frmBCNhapHang nxt = new frmBCNhapHang();
            nxt.ShowDialog();
        }

        private void báoCáoNhậpXuấtTồnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBCNhapHang nh = new frmBCNhapHang();
            nh.ShowDialog();
        }

        private void labelX2_Click(object sender, EventArgs e)
        {
            frmBCXuatHang xh = new frmBCXuatHang();
            xh.ShowDialog();
        }
    }
}
