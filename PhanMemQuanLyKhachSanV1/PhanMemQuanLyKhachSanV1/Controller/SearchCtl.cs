using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemQuanLyKhachSanV1.Model;
using System.Data.SqlClient;
using System.Data;
namespace PhanMemQuanLyKhachSanV1.Controller
{
    class SearchCtl
    {
        ConnectToSql con = new ConnectToSql();
        SqlCommand cmd = new SqlCommand();

        public bool SeachKhachHang(KhachHangObj khobj)
        {
            cmd.CommandText = "select from KhachHang where TenKH LIKE " + khobj.TenKH + " ";
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
