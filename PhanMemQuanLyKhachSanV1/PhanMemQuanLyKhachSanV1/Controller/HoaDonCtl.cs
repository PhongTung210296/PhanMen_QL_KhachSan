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
    class HoaDonCtl
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
            cmd.CommandText = "select * from HoaDon";
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
        /// <param name="hdobj">đối tượng cần thêm vào ds</param>
        public bool AddHoaDon(HoaDonObj hdobj)
        {
            cmd.CommandText = "Insert into HoaDon values ('" + hdobj.MaHD + "','" + hdobj.NgayThanhToan + "','" + hdobj.SoTienDatTruoc + "','" + hdobj.DonVi + "','" + hdobj.MaNV + "')";
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
        public bool DelHoaDon(string ma)
        {
            cmd.CommandText = "delete HoaDon where MaKH= '" + ma + "'";
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
        /// <param name="hdobj"> đối tượng nhân viên cần sửa</param>
        public bool UpdateHoaDon(HoaDonObj hdobj)
        {
            cmd.CommandText = " update HoaDon set NgayThanhToan='" + hdobj.NgayThanhToan + "',SoTienDatTruoc='" + hdobj.SoTienDatTruoc + "',DonVi='" + hdobj.DonVi + "',MaNV='" + hdobj.MaNV + "' where MaHD='" + hdobj.MaHD + "'";
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
