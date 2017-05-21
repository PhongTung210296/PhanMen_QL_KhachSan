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
    public partial class frmHoaDon : Form
    {
        HoaDonCtl hdctl = new HoaDonCtl();
        HoaDonObj hdobj = new HoaDonObj();
        int flag = 0;
        public frmHoaDon()
        {
            InitializeComponent();
        }
        public void dis_en(bool e)
        {
            txtMaHD.Enabled = e;
            dtNgayTT.Enabled = e;
            txtDatTruoc.Enabled = e;
            txtDonVi.Enabled = e;
            cbbMaNV.Enabled = e;
            btnHuy.Enabled = e;
            btnLuu.Enabled = e;
            btnThem.Enabled = !e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;
        }

        private void clean()
        {
            txtMaHD.Clear();
            txtDonVi.Clear();
            txtDatTruoc.Clear();
            // cbbMaNV.Clear();
            dtNgayTT.Value = DateTime.Now;
        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = hdctl.GetData();
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dis_en(false);

        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try
                {
                    txtMaHD.Text = dgvHoaDon.CurrentRow.Cells[0].Value.ToString();
                    dtNgayTT.Text = dgvHoaDon.CurrentRow.Cells[1].Value.ToString();
                    txtDatTruoc.Text = dgvHoaDon.CurrentRow.Cells[2].Value.ToString();
                    txtDonVi.Text = dgvHoaDon.CurrentRow.Cells[3].Value.ToString();
                    cbbMaNV.Text = dgvHoaDon.CurrentRow.Cells[4].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void GanDuLieu(HoaDonObj hd1obj)
        {
            hd1obj.MaHD = txtMaHD.Text.ToString().Trim();
            hd1obj.NgayThanhToan = dtNgayTT.Value;
            hd1obj.SoTienDatTruoc = txtDatTruoc.Text.ToString().Trim();
            hd1obj.DonVi = txtDonVi.Text.ToString().Trim();
            hd1obj.MaNV = cbbMaNV.Text.ToString().Trim();
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
                    if (hdctl.DelHoaDon(txtMaHD.Text.Trim()))
                    {
                        MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmHoaDon_Load(sender, e);
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
            GanDuLieu(hdobj);
            if (flag == 0)   // thêm
            {
                if (hdctl.AddHoaDon(hdobj))
                {
                    MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmHoaDon_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Thêm không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else            // sửa
            {
                if (hdctl.UpdateHoaDon(hdobj))
                {
                    MessageBox.Show("Sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmHoaDon_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Sửa không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmHoaDon_Load(sender, e);
            dis_en(false);
        }
    }
}
