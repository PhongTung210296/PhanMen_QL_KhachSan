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
using PhanMemQuanLyKhachSanV1.Model;
using PhanMemQuanLyKhachSanV1.Controller;
namespace PhanMemQuanLyKhachSanV1.View
{
    public partial class KhachHang : Form
    {
        KhachHangCtl khctl = new KhachHangCtl();
        KhachHangObj khobj = new KhachHangObj();
        int flag = 0;
        public KhachHang()
        {
            InitializeComponent();
        }

        public void dis_en(bool e)
        {
            txtMaKH.Enabled = e;
            txtHoTen.Enabled = e;
            dtNgaySinh.Enabled = e;
            txtDiaChi.Enabled = e;
            groupBox5.Enabled = e;
            txtCMT.Enabled = e;
            txtSDT.Enabled = e;
            txtQuocTich.Enabled = e;
            btnHuy.Enabled = e;
            btnLuu.Enabled = e;
            btnThem.Enabled = !e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = khctl.GetData();
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dis_en(false);
        }

        private void clean()
        {
            txtMaKH.Clear();
            txtHoTen.Clear();
            txtQuocTich.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtCMT.Clear();
            dtNgaySinh.Value = DateTime.Now;
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try
                {
                    txtMaKH.Text = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();
                    txtHoTen.Text = dgvKhachHang.CurrentRow.Cells[1].Value.ToString();
                    dtNgaySinh.Text = dgvKhachHang.CurrentRow.Cells[2].Value.ToString();
                    txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells[3].Value.ToString();
                    bool Gt;
                    if (dgvKhachHang.CurrentRow.Cells[4].Value.ToString().Trim() == "Nam")
                        Gt = true;
                    else
                        Gt = false;
                    if (Gt)
                        rbtNam.Checked = true;
                    else
                        rbtNu.Checked = true;
                    txtCMT.Text = dgvKhachHang.CurrentRow.Cells[5].Value.ToString();
                    txtSDT.Text = dgvKhachHang.CurrentRow.Cells[6].Value.ToString();
                    txtQuocTich.Text = dgvKhachHang.CurrentRow.Cells[7].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void GanDuLieu(KhachHangObj kh1obj)
        {
            kh1obj.MaKH = txtMaKH.Text.ToString().Trim();
            kh1obj.TenKH = txtHoTen.Text.ToString().Trim();
            kh1obj.NgaySinh = dtNgaySinh.Value;
            kh1obj.DiaChi = txtDiaChi.Text.ToString().Trim();
            if (rbtNam.Checked)
            {
                kh1obj.GioiTinh = "Nam";
            }
            if (rbtNu.Checked)
            {
                kh1obj.GioiTinh = "Nu";
            }
            kh1obj.SoCMND = txtCMT.Text.ToString().Trim();
            kh1obj.SDT = txtSDT.Text.ToString().Trim();
            kh1obj.QuocTich = txtQuocTich.Text.ToString().Trim();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 0;
            clean();
            dis_en(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 1;
            dis_en(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có thật sự muốn xóa ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            {
                if (dr == DialogResult.Yes)
                {
                    if (khctl.DelKhachHang(txtMaKH.Text.Trim()))
                    {
                        MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        KhachHang_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Xóakhông thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            GanDuLieu(khobj);
            if (flag == 0)   // thêm
            {
                if (khctl.AddKhachHang(khobj))
                {
                    MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    KhachHang_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Thêm không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else            // sửa
            {
                if (khctl.UpdateKhachHang(khobj))
                {
                    MessageBox.Show("Sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    KhachHang_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Sửa không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            KhachHang_Load(sender, e);
            dis_en(false);
        }
    }
}
