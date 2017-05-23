using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using PhanMemQuanLyKhachSanV1.Model;
using PhanMemQuanLyKhachSanV1.Controller;

namespace PhanMemQuanLyKhachSanV1.View
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
        }

        ConnectToSql con = new ConnectToSql();
        SqlCommand cmd = new SqlCommand();

        private DataTable timKiem()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = " select *  from KhachHang where TenKH LIKE '" + txtSeach.Text.ToString() + "' ";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.strConn;
            try
            {
                con.OpenConnect();
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                con.CloseConnection();
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                cmd.Dispose();
                con.CloseConnection();
            }
            return dt;
        }
        private void frmSearch_Load(object sender, EventArgs e)
        {
            dgvSeach.DataSource = timKiem();
            dgvSeach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void seach_Click(object sender, EventArgs e)
        {
            timKiem();
            dgvSeach.DataSource = timKiem();
            dgvSeach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
