namespace FurnitureStore_API_PM.Model
{
    public class Donhang
    {
        public int MaDonHang { get; set; }
        public string NgayTao { get; set; }
        public string TinhTrang { get; set; }
        public int MaKH { get; set; }
        public List<ChiTietDonHang> chiTietDonHang {get; set;}
    }

    public class Donhangg
    {
        public int MaDonHang { get; set; }
        public string NgayTao { get; set; }
        public string TinhTrang { get; set; }
        public int MaKH { get; set; }
        public string TenKhachHang { get; set; }

    }


}
