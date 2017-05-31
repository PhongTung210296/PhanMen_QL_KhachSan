using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using PhanMemQuanLyKhachSanV1.Model;

namespace PhanMemQuanLyKhachSanV1.Controller
{
    class NhanVienCtl
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
            cmd.CommandText = "select * from NhanVien";
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
        public bool AddNhanVien(NhanVienObj nvobj)
        {
            cmd.CommandText = "Insert into NhanVien values ('" + nvobj.MaNV + "',N'" + nvobj.TenNhanVien + "','" + nvobj.MaChucVu + "','" + nvobj.GioiTinh + "','" + nvobj.NgaySinh + "','" + nvobj.DiaChi + "','" + nvobj.SDT + "');";
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
        public bool DelNhanVien(string ma)
        {
            cmd.CommandText = "delete KhachHang where MaKH= '" + ma + "'";
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
        public bool UpdateNhanVien(NhanVienObj nvobj)
        {
            cmd.CommandText = " update NhanVien set TenNhanVien=N'" + nvobj.TenNhanVien + "',MaChucVu='" + nvobj.MaChucVu + "',GioiTinh='" + nvobj.GioiTinh + "',NgaySinh='" + nvobj.NgaySinh + "',DiaChi='" + nvobj.DiaChi + "',SDT='" + nvobj.SDT + "' where MaNV='" + nvobj.MaNV + "'";
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
