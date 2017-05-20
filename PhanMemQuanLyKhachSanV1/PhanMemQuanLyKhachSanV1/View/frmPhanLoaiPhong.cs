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
    public partial class frmPhanLoaiPhong : Form
    {
        public frmPhanLoaiPhong()
        {
            InitializeComponent();
        }
        PhanLoaiPhongCtl plctl = new PhanLoaiPhongCtl();
        PhanLoaiPhongObj plobj = new PhanLoaiPhongObj();
        int flag = 0;
        private void frmPhanLoaiPhong_Load(object sender, EventArgs e)
        {
            dgvPhanLoai.DataSource = plctl.GetData();
            dgvPhanLoai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dis_en(false);
        }

        public void dis_en(bool e)
        {
            txtMaPL.Enabled = e;
            txtTenLP.Enabled = e;
            txtTrangBi.Enabled = e;
            btnHuy.Enabled = e;
            btnLuu.Enabled = e;
            btnThem.Enabled = !e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;
        }

        public void LoadData()
        {
            txtMaPL.Text = dgvPhanLoai.CurrentRow.Cells[0].Value.ToString();
            txtTenLP.Text = dgvPhanLoai.CurrentRow.Cells[1].Value.ToString();
            txtTrangBi.Text = dgvPhanLoai.CurrentRow.Cells[2].Value.ToString();
        }

        private void clean()
        {
            txtMaPL.Clear();
            txtTenLP.Clear();
            txtTrangBi.Clear();
        }
        private void GanDuLieu(PhanLoaiPhongObj pl1obj)
        {
            pl1obj.MaPL = txtMaPL.Text.ToString().Trim();
            pl1obj.TenLoaiPhong = txtTenLP.Text.ToString().Trim();
            pl1obj.TrangBi = txtTrangBi.Text.ToString().Trim();
        }



        private void dgvPhanLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try
                {
                    txtMaPL.Text = dgvPhanLoai.CurrentRow.Cells[0].Value.ToString();
                    txtTenLP.Text = dgvPhanLoai.CurrentRow.Cells[1].Value.ToString();
                    txtTrangBi.Text = dgvPhanLoai.CurrentRow.Cells[2].Value.ToString();
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
                    if (plctl.DelPhanLoaiPhong(txtMaPL.Text.Trim()))
                    {
                        MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmPhanLoaiPhong_Load(sender, e);
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
            GanDuLieu(plobj);
            if (flag == 0)   // thêm
            {
                if (plctl.AddPhanLoaiPhong(plobj))
                {
                    MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmPhanLoaiPhong_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Thêm không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else            // sửa
            {
                if (plctl.UpdatePhanLoaiPhong(plobj))
                {
                    MessageBox.Show("Sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmPhanLoaiPhong_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Sửa không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmPhanLoaiPhong_Load(sender, e);
            dis_en(false);
        }
    }
}
