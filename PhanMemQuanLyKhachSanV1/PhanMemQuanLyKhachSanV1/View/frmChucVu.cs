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
    public partial class frmChucVu : Form
    {
        ChucVuCtl cvctl = new ChucVuCtl();
        ChucVuObj cvobj = new ChucVuObj();
        int flag = 0;
        public frmChucVu()
        {
            InitializeComponent();
        }

        private void cbbMaCV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dtNgaySinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmChucVu_Load(object sender, EventArgs e)
        {
            dgvChucVu.DataSource = cvctl.GetData();
            dgvChucVu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dis_en(false);
        }

        public void dis_en(bool e)
        {
            txtMaCV.Enabled = e;
            txtHoTenCV.Enabled = e;
            btnHuy.Enabled = e;
            btnLuu.Enabled = e;
            btnThem.Enabled = !e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;
        }

        public void LoadData()
        {
            txtMaCV.Text = dgvChucVu.CurrentRow.Cells[0].Value.ToString();
            txtHoTenCV.Text = dgvChucVu.CurrentRow.Cells[1].Value.ToString();
        }

        private void clean()
        {
            txtMaCV.Clear();
            txtHoTenCV.Clear();
        }




        private void dgvChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try
                {
                    txtMaCV.Text = dgvChucVu.CurrentRow.Cells[0].Value.ToString();
                    txtHoTenCV.Text = dgvChucVu.CurrentRow.Cells[1].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }



        private void GanDuLieu(ChucVuObj cv1obj)
        {
            cv1obj.MaChucVu = txtMaCV.Text.ToString().Trim();
            cv1obj.TenChucVu = txtHoTenCV.Text.ToString().Trim();
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
                    if (cvctl.DelChucVu(txtMaCV.Text.Trim()))
                    {
                        MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmChucVu_Load(sender, e);
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
            GanDuLieu(cvobj);
            if (flag == 0)   // thêm
            {
                if (cvctl.AddChucVu(cvobj))
                {
                    MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmChucVu_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Thêm không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else            // sửa
            {
                if (cvctl.UpdateChucVu(cvobj))
                {
                    MessageBox.Show("Sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmChucVu_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Sửa không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmChucVu_Load(sender, e);
            dis_en(false);
        }

    }
}
