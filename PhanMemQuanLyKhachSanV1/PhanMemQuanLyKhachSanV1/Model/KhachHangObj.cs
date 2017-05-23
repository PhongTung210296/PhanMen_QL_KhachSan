using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQuanLyKhachSanV1.Model
{
    class KhachHangObj
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public string SoCMND { get; set; }
        public string SDT { get; set; }
        public string QuocTich { get; set; }
        public KhachHangObj() { }
        public KhachHangObj(string MaKh, string TenKh, DateTime NgaySinh, string DiaChi, string GioiTinh, string SoCMND, string SDT, string QuocTich)
        {
            this.MaKH = MaKH;
            this.TenKH = TenKH;
            this.NgaySinh = NgaySinh;
            this.DiaChi = DiaChi;
            this.GioiTinh = GioiTinh;
            this.SoCMND = SoCMND;
            this.SDT = SDT;
            this.QuocTich = QuocTich;
        }
    }
}
