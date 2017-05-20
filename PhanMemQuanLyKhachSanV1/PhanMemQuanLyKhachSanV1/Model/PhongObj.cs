using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQuanLyKhachSanV1.Model
{
    class PhongObj
    {
        public string MaPhong { get; set; }
        public string TenPhong { get; set; }
        public string TinhTrang { get; set; }
        public string GiaPhong { get; set; }
        public string MaPhanLoai { get; set; }
        public string DonVi { get; set; }
        public PhongObj() { }
        public PhongObj(string MaPhong, string TenPhong, string TinhTrang, string GiaPhong, string MaPhanLoai, string DonVi)
        {
            this.MaPhong = MaPhong;
            this.TenPhong = TenPhong;
            this.TinhTrang = TinhTrang;
            this.GiaPhong = GiaPhong;
            this.MaPhanLoai = MaPhanLoai;
            this.DonVi = DonVi;
        }
    }
}
