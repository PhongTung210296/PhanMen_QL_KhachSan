using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQuanLyKhachSanV1.Model
{
    class PhanLoaiPhongObj
    {
        public string MaPL { get; set; }
        public string TenLoaiPhong { get; set; }
        public string TrangBi { get; set; }
        public PhanLoaiPhongObj() { }
        public PhanLoaiPhongObj(string MaPL, string TenLoaiPhong, string TrangBi)
        {
            this.MaPL = MaPL;
            this.TenLoaiPhong = TenLoaiPhong;
            this.TrangBi = TrangBi;
        }
    }
}
