using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace PhanMemQuanLyKhachSanV1.Model
{
    class ConnectToSql
    {
        #region availible
        /// <summary>
        /// Đây là các thuộc tính của lớp connection
        /// </summary>
        private SqlConnection conn;
        private string error;
        #endregion

       
        #region Contruction
        /// <summary>
        /// Đây là hàm contructor của class sqlconnect
        /// </summary>
        public ConnectToSql()
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-7KSKII1;Initial Catalog=QlKhachSan;Integrated Security=True");      
        }
        #endregion


        #region method
        /// <summary>
        /// Hàm trả lỗi
        /// </summary>
        public string Erro
        {
            get { return error; }
            set { error = value;}
        }

        /// <summary>
        /// Hàm mở kết nối
        /// </summary>
        public void OpenConnect()
        {
            try
            {
                if(conn.State==ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch(Exception ex)
            {
                error = ex.Message;
            }
        }

        /// <summary>
        /// Hàm đóng kết nối
        /// </summary>
        public void CloseConnection()
        {
            try 
            {
                if(conn.State== ConnectionState.Open)
                {
                    conn.Close();
                }
            }catch(Exception ex)
            {
                error = ex.Message;
            }
        }

        /// <summary>
        /// Hàm lấy ra chuỗi kết nối
        /// </summary>
        public SqlConnection strConn
        {
            get { return conn; }
        }
        #endregion
    }
    
}
