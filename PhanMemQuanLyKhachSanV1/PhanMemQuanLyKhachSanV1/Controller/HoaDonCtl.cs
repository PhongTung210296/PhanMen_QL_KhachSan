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

  
        public bool AddHoaDon(HoaDonObj hdobj)
        {
            cmd.CommandText = "Insert into HoaDon values ('" + hdobj.MaHD + "','" + hdobj.MaKH + "','" + hdobj.MaNV + "','" + hdobj.NgayLap + "','" + hdobj.NgayDi + "','" + hdobj.MaPhong + "','" + hdobj.TraTruoc + "','" + hdobj.DonVi + "','" + hdobj.MaPhieuDichVu + "')";
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
            cmd.CommandText = "delete HoaDon where MaHD= '" + ma + "'";
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

       
        public bool UpdateHoaDon(HoaDonObj hdobj)
        {
            cmd.CommandText = " update HoaDon set MaKH='" + hdobj.MaKH + "', MaNV='" + hdobj.MaNV + "',NgayLap='" + hdobj.NgayLap + "',NgayDi='" + hdobj.NgayDi + "',MaPhong='" + hdobj.MaPhong + "',TraTruoc='" + hdobj.TraTruoc + "',DonVi='" + hdobj.DonVi + "',MaPhieDichVu='" + hdobj.MaPhieuDichVu + "' where MaHD='" + hdobj.MaHD + "'";
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
