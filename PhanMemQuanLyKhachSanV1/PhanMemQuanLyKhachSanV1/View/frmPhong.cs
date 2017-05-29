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
    public partial class frmPhong : Form
    {
     
        public frmPhong()
        {
            InitializeComponent();
        }
        PhongCtl pctl = new PhongCtl();
        PhongObj pobj = new PhongObj();
        int flag = 0;
        public void dis_en(bool e)
        {
            txtMaPhong.Enabled = e;
            txtTenPhong.Enabled = e;
            txtTinhTrang.Enabled = e;
            cbbGia.Enabled = e;
            cbbMaPL.Enabled = e;
            txtDonVi.Enabled = e;
            btnHuy.Enabled = e;
            btnLuu.Enabled = e;
            btnThem.Enabled = !e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;
        }
        private void GanDuLieu(PhongObj p1obj)
        {
            p1obj.MaPhong = txtMaPhong.Text.ToString().Trim();
            p1obj.TenPhong = txtTenPhong.Text.ToString().Trim();
            p1obj.TinhTrang = txtTinhTrang.Text.ToString().Trim();
            p1obj.DonVi = txtDonVi.Text.ToString().Trim();
            p1obj.GiaPhong = cbbGia.Text.ToString().Trim();
            p1obj.MaPhanLoai = cbbMaPL.Text.ToString().Trim();
        }

        private void clean()
        {
            txtMaPhong.Clear();
            txtTenPhong.Clear();
            txtTinhTrang.Clear();
            txtDonVi.Clear();
        }

      

        private void frmPhong_Load(object sender, EventArgs e)
        {
            this.phanLoaiPhongTableAdapter.Fill(this.qlKhachSanDataSet.PhanLoaiPhong);
            dgvPhong.DataSource = pctl.GetData();
            dgvPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dis_en(false);
        }

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try
                {
                    txtMaPhong.Text = dgvPhong.CurrentRow.Cells[0].Value.ToString();
                    txtTenPhong.Text = dgvPhong.CurrentRow.Cells[1].Value.ToString();
                    txtTinhTrang.Text = dgvPhong.CurrentRow.Cells[2].Value.ToString();
                    cbbGia.Text = dgvPhong.CurrentRow.Cells[3].Value.ToString();
                    cbbMaPL.Text = dgvPhong.CurrentRow.Cells[4].Value.ToString();
                    txtDonVi.Text = dgvPhong.CurrentRow.Cells[5].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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
                    if (pctl.DelPhong(txtMaPhong.Text.Trim()))
                    {
                        MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmPhong_Load(sender, e);
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
            GanDuLieu(pobj);
            if (flag == 0)   // thêm
            {
                if (pctl.AddPhong(pobj))
                {
                    MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmPhong_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Thêm không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else            // sửa
            {
                if (pctl.UpdatePhong(pobj))
                {
                    MessageBox.Show("Sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmPhong_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Sửa không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmPhong_Load(sender, e);
            dis_en(false);
        }
    }
}
