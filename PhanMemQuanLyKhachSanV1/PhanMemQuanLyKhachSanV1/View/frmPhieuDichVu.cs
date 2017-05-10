using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhanMemQuanLyKhachSanV1.Controller;
using PhanMemQuanLyKhachSanV1.Model;

namespace PhanMemQuanLyKhachSanV1.View
{
    public partial class frmPhieuDichVu: Form
    {
        public frmPhieuDichVu()
        {
            InitializeComponent();
        }
        PhieuDichVuCtl pdvctl = new PhieuDichVuCtl();
        PhieuDichVuObj pdvobj = new PhieuDichVuObj();
        int flag = 0;

        private void frmPhieuDichVu_Load(object sender, EventArgs e)
        {
            dgvPhieuDichVu.DataSource = pdvctl.GetData();
            dgvPhieuDichVu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dis_en(false);
            // LoadData();
        }

        public void dis_en(bool e)
        {
            txtMaPhieuDV.Enabled = e;
            txtTenDV.Enabled = e;
            cbbMaPhieuDK.Enabled = e;
            txtGiaGiaoDich.Enabled = e;
            btnHuy.Enabled = e;
            btnLuu.Enabled = e;
            btnThem.Enabled = !e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;
        }

        //public void LoadData()
        //{
        //    txtMaPhieuDV.Text = dgvPhieuDichVu.CurrentRow.Cells[0].Value.ToString();
        //    cbbMaPhieuDK.Text = dgvPhieuDichVu.CurrentRow.Cells[1].Value.ToString();
        //    txtTenDV.Text = dgvPhieuDichVu.CurrentRow.Cells[2].Value.ToString();     
        //    txtGiaGiaoDich.Text = dgvPhieuDichVu.CurrentRow.Cells[3].Value.ToString();
        //}

        private void clean()
        {
            txtMaPhieuDV.Clear();
            txtGiaGiaoDich.Clear();
            txtTenDV.Clear();
        }

        private void dgvPhieuDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try
                {
                    txtMaPhieuDV.Text = dgvPhieuDichVu.CurrentRow.Cells[0].Value.ToString();
                    cbbMaPhieuDK.Text = dgvPhieuDichVu.CurrentRow.Cells[1].Value.ToString();
                    txtTenDV.Text = dgvPhieuDichVu.CurrentRow.Cells[2].Value.ToString();
                    txtGiaGiaoDich.Text = dgvPhieuDichVu.CurrentRow.Cells[3].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void GanDuLieu(PhieuDichVuObj pdv1obj)
        {
            pdv1obj.MaPhieuDichVu = txtMaPhieuDV.Text.ToString().Trim();
            pdv1obj.MaPhieuDangKy = cbbMaPhieuDK.Text.ToString().Trim();
            pdv1obj.GiaDichVu = txtMaPhieuDV.Text.ToString().Trim();
            pdv1obj.TenDichVu = txtTenDV.Text.ToString().Trim();
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
                    if (pdvctl.DelPhieuDichVu(txtMaPhieuDV.Text.Trim()))
                    {
                        MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmPhieuDichVu_Load(sender, e);
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
            GanDuLieu(pdvobj);
            if (flag == 0)   // thêm
            {
                if (pdvctl.AddPhieuDichVu(pdvobj))
                {
                    MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmPhieuDichVu_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Thêm không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else            // sửa
            {
                if (pdvctl.UpdatePhieuDichVu(pdvobj))
                {
                    MessageBox.Show("Sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmPhieuDichVu_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Sửa không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmPhieuDichVu_Load(sender, e);
            dis_en(false);
        }
    }
}
