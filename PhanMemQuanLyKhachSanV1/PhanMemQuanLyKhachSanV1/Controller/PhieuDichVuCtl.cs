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
    class PhieuDichVuCtl
    {
        ConnectToSql con = new ConnectToSql();
        SqlCommand cmd = new SqlCommand();

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
