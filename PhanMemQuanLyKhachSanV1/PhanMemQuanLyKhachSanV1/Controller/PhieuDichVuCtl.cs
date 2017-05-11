using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemQuanLyKhachSanV1.Model;

namespace PhanMemQuanLyKhachSanV1.Controller
{
    class PhieuDichVuCtl
    {
        ConnectToSql con = new ConnectToSql();
        SqlCommand cmd = new SqlCommand();

        /// <summary>
        /// Hàm lấy dữ liệu . Trả về 1 data table
        /// </summary>
        /// <returns></returns>
        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "select * from PhieuDichVu";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.strConn;
            try
            {
                con.OpenConnect();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
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

        /// <summary>
        /// Hàm Thêm nhân viên vào danh sách
        /// </summary>
        /// <param name="nvobj">đối tượng cần thêm vào ds</param>
        public bool AddPhieuDichVu(PhieuDichVuObj pdvobj)
        {
            cmd.CommandText = "Insert into PhieuDichVu values ('" + pdvobj.MaPhieuDichVu + "','" + pdvobj.MaPhieuDangKy + "',N'" + pdvobj.TenDichVu + "','" + pdvobj.GiaDichVu + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.strConn;
            try
            {
                con.OpenConnect();
                cmd.ExecuteNonQuery();
                con.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                cmd.Dispose();
                con.CloseConnection();
            }
            return true;
        }

        /// <summary>
        /// Hàm xóa một nhân viên ra khỏi danh sách
        /// </summary>
        /// <param name="ma"> mã nhân viên cần xóa</param>
        public bool DelPhieuDichVu(string ma)
        {
            cmd.CommandText = "delete PhieuDichVu where MaPieuDichVu= '" + ma + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.strConn;
            try
            {
                con.OpenConnect();
                cmd.ExecuteNonQuery();
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                cmd.Dispose();
                con.CloseConnection();
            }
            return true;
        }

        /// <summary>
        /// Hàm sửa thông tin một nhân viên
        /// </summary>
        /// <param name="khobj"> đối tượng nhân viên cần sửa</param>
        public bool UpdatePhieuDichVu(PhieuDichVuObj pdvobj)
        {
            cmd.CommandText = " update PhieuDichVu set MaPhieuDangKy=N'" + pdvobj.MaPhieuDangKy + "',TenDichVu='" + pdvobj.TenDichVu + "',GiaDichVu='" + pdvobj.GiaDichVu + "' where MaPhieuDichVu='" + pdvobj.MaPhieuDichVu + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.strConn;
            try
            {
                con.OpenConnect();
                cmd.ExecuteNonQuery();
                con.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                cmd.Dispose();
                con.CloseConnection();
            }
            return true;
        }
    }
}
