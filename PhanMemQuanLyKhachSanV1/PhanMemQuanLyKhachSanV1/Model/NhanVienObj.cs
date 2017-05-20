using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQuanLyKhachSanV1.Model
{
    class NhanVienObj
    {
        public string MaNV { get; set; }
        public string TenNhanVien { get; set; }
        public string MaChucVu { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public NhanVienObj() { }
        public NhanVienObj(string MaNV, string TenNhanVien, string MaChucVu, string GioiTinh, DateTime NgaySinh, string DiaChi, string SDT)
        {
            this.MaNV = MaNV;
            this.TenNhanVien = TenNhanVien;
            this.MaChucVu = MaChucVu;
            this.GioiTinh = GioiTinh;
            this.DiaChi = DiaChi;
            this.SDT = SDT;
        }
    }
}
