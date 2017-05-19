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
          
        }
     

       

      

        private void dgvChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void GanDuLieu(ChucVuObj cv1obj)
        {
          
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
          
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
          
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
           
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
           
        }

    }
}
