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
    class PhongCtl
    {
        ConnectToSql con = new ConnectToSql();
        SqlCommand cmd = new SqlCommand();


        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "select * from Phong";
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


        public bool AddPhong(PhongObj pobj)
        {
            cmd.CommandText = "Insert into Phong values ('" + pobj.MaPhong + "',N'" + pobj.TenPhong + "',N'" + pobj.TinhTrang + "','" + pobj.GiaPhong + "','" + pobj.MaPhanLoai + "','" + pobj.DonVi + "')";
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


        public bool DelPhong(string ma)
        {
            cmd.CommandText = "delete Phong where MaPhong= '" + ma + "'";
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


        public bool UpdatePhong(PhongObj pobj)
        {
            cmd.CommandText = " update Phong set TenPhong=N'" + pobj.TenPhong + "',TinhTrang='" + pobj.TinhTrang + "',GiaPhong='" + pobj.GiaPhong + "',MaPL='" + pobj.MaPhanLoai + "',DonVi='" + pobj.DonVi + "' where MaPhong='" + pobj.MaPhong + "'";
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
