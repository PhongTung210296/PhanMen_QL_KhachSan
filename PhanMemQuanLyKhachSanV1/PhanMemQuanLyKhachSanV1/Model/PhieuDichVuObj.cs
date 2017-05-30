using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQuanLyKhachSanV1.Model
{
    class PhieuDichVuObj
    {
        public string MaPhieuDichVu { get; set; }
        public string MaPhieuDangKy { get; set; }
        public string TenDichVu { get; set; }
        public string GiaDichVu { get; set; }
        public PhieuDichVuObj() { }
        public PhieuDichVuObj(string MaPhieuDichVu, string MaPhieuDangKy, string TenDichVu, string GiaDichVu)
        {
            this.MaPhieuDangKy = MaPhieuDangKy;
            this.MaPhieuDichVu = MaPhieuDichVu;
            this.TenDichVu = TenDichVu;
            this.GiaDichVu = GiaDichVu;
        }
    }
}
