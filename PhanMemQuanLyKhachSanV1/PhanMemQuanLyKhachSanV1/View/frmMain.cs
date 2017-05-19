using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhanMemQuanLyKhachSanV1.View;
namespace PhanMemQuanLyKhachSanV1.View
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmPhong phong= new frmPhong();
            phong.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            frmNhanVien nv = new frmNhanVien();
            nv.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            frmPhieuDichVu phieudv = new frmPhieuDichVu();
            phieudv.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            frmHoaDon hoadon = new frmHoaDon();
            hoadon.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmPhanLoaiPhong pl = new frmPhanLoaiPhong();
            pl.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            frmChucVu cv = new frmChucVu();
            cv.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có thật sự muốn thoát !", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

    }
}
