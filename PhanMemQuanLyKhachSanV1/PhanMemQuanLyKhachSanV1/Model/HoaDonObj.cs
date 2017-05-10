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
        public DateTime NgayThanhToan { get; set; }
        public string SoTienDatTruoc { get; set; }
        public string DonVi { get; set; }
        public string MaNV { get; set;}
        public HoaDonObj() { }
        public HoaDonObj( string MaHD, DateTime NgayThanhToan, string SoTienDatTruoc,string DonVi,string MaNV)
        {
            this.MaHD = MaHD;
            this.NgayThanhToan = NgayThanhToan;
            this.SoTienDatTruoc = SoTienDatTruoc;
            this.DonVi = DonVi;
            this.MaNV = MaNV;
        }
    }
}
