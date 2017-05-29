using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQuanLyKhachSanV1.Model
{
    class HoaDonObj
    {
        public string MaHD { get; set; }
        public string MaKH { get; set; }
        public string MaNV { get; set; }
        public DateTime NgayLap { get; set; }
        public DateTime NgayDi { get; set; }
        public string MaPhong { get; set; }
        public string TraTruoc { get; set; }
        public string DonVi { get; set; }
        public string MaPhieuDichVu { get; set; }
        public HoaDonObj() { }
        public HoaDonObj(string MaHD,string MaKH,string MaNV, DateTime NgayLap,DateTime NgayDi, string MaPhong,string TraTruoc, string DonVi, string MaPhieuDichVu)
        {
            this.MaHD = MaHD;
            this.MaKH = MaKH;
            this.MaNV = MaNV;
            this.NgayLap = NgayLap;
            this.NgayDi = NgayDi;
            this.MaPhong = MaPhong;
            this.TraTruoc = TraTruoc;
            this.DonVi = DonVi;
            this.MaPhieuDichVu = MaPhieuDichVu;
        }
    }
}
