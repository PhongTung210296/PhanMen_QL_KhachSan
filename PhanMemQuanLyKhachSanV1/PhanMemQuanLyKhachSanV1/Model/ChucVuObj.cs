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
        public ChucVuObj(string MaChucVu, string TenChucVu)
        {
            this.MaChucVu = MaChucVu;
            this.TenChucVu = TenChucVu;
        }
    }
}
