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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        NhanVienCtl nvctl = new NhanVienCtl();
        NhanVienObj nvobj = new NhanVienObj();
        int flag = 0;
        public void dis_en(bool e)
        {
            txtMaNV.Enabled = e;
            txtHoTen.Enabled = e;
            dtNgaySinh.Enabled = e;
            txtDiaChi.Enabled = e;
            groupBox5.Enabled = e;
            cbbMaCV.Enabled = e;
            txtSDT.Enabled = e;
            btnHuy.Enabled = e;
            btnLuu.Enabled = e;
            btnThem.Enabled = !e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = nvctl.GetData();
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dis_en(false);
        }
        private void clean()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            dtNgaySinh.Value = DateTime.Now;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try
                {
                    txtMaNV.Text = dgvNhanVien.CurrentRow.Cells[0].Value.ToString();
                    txtHoTen.Text = dgvNhanVien.CurrentRow.Cells[1].Value.ToString();
                    cbbMaCV.Text = dgvNhanVien.CurrentRow.Cells[2].Value.ToString();
                    bool Gt;
                    if (dgvNhanVien.CurrentRow.Cells[3].Value.ToString().Trim() == "Nam")
                        Gt = true;
                    else
                        Gt = false;
                    if (Gt)
                        rbtNam.Checked = true;
                    else
                        rbtNu.Checked = true;
                    dtNgaySinh.Text = dgvNhanVien.CurrentRow.Cells[4].Value.ToString();
                    txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells[5].Value.ToString();
                    txtSDT.Text = dgvNhanVien.CurrentRow.Cells[6].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void GanDuLieu(NhanVienObj nv1obj)
        {
            nv1obj.MaNV = txtMaNV.Text.ToString().Trim();
            nv1obj.TenNhanVien = txtHoTen.Text.ToString().Trim();
            nv1obj.MaChucVu = cbbMaCV.Text.ToString().Trim();
            nv1obj.NgaySinh = dtNgaySinh.Value;
            nv1obj.DiaChi = txtDiaChi.Text.ToString().Trim();
            if (rbtNam.Checked)
            {
                nv1obj.GioiTinh = "Nam";
            }
            if (rbtNu.Checked)
            {
                nv1obj.GioiTinh = "Nu";
            }
            nv1obj.SDT = txtSDT.Text.ToString().Trim();
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
                    if (nvctl.DelNhanVien(txtMaNV.Text.Trim()))
                    {
                        MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmNhanVien_Load(sender, e);
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
            GanDuLieu(nvobj);
            if (flag == 0)   // thêm
            {
                if (nvctl.AddNhanVien(nvobj))
                {
                    MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmNhanVien_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Thêm không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else            // sửa
            {
                if (nvctl.UpdateNhanVien(nvobj))
                {
                    MessageBox.Show("Sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmNhanVien_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Sửa không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmNhanVien_Load(sender, e);
            dis_en(false);
        }


    }
}
