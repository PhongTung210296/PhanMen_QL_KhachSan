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
    class KhachHangCtl
    {
        ConnectToSql con = new ConnectToSql();
        SqlCommand cmd = new SqlCommand();


        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "select * from KhachHang";
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


        public bool AddKhachHang(KhachHangObj khobj)
        {
            cmd.CommandText = "Insert into KhachHang values ('" + khobj.MaKH + "',N'" + khobj.TenKH + "','" + khobj.NgaySinh + "','" + khobj.DiaChi + "','" + khobj.GioiTinh + "','" + khobj.SoCMND + "','" + khobj.SDT + "','" + khobj.QuocTich + "')";
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


        public bool DelKhachHang(string ma)
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


        public bool UpdateKhachHang(KhachHangObj khobj)
        {
            cmd.CommandText = " update KhachHang set TenKH=N'" + khobj.TenKH + "',NgaySinh='" + khobj.NgaySinh + "',DiaChi=N'" + khobj.DiaChi + "',GioiTinh='" + khobj.GioiTinh + "',SoCMND='" + khobj.SoCMND + "',SDT='" + khobj.SDT + "',QuocTich='" + khobj.QuocTich + "' where MaKH='" + khobj.MaKH + "'";
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
