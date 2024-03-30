using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_NoiThat.Model
{
    public class Donhang
    {
        public int MaDonHang { get; set; }
        public string NgayTao { get; set; }
        public string TinhTrang { get; set; }
        public int MaKH { get; set; }
        public string TenKhachHang { get; set; }

    }
    public class CTDH
    {
        public int maCTHD { get; set; }
        public int maDH { get; set; }
       
        public int soLuong { get; set; }
        public int donGia { get; set; }
        public int thanhTien { get; set; }
        public string  kichCo { get; set; }
        public string mauSac { get; set; }

        public int maSP { get; set; }
        public string tenSanPham { get; set; }
    }
}
