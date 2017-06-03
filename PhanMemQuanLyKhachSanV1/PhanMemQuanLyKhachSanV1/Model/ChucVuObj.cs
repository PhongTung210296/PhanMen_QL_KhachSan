using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQuanLyKhachSanV1.Model
{
    class ChucVuObj
    {
        public string MaChucVu { get; set; }
        public string TenChucVu { get; set; }
        public ChucVuObj() { }
        public ChucVuObj(string maChucVu, string tenChucVu)
        {
            this.MaChucVu = maChucVu;
            this.TenChucVu = tenChucVu;
        }
    }
}
