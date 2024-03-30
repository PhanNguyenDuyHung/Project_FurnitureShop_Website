namespace FurnitureStore_API_PM.Model
{
    public class ChiTietGH
    {
        public int MACTGH { get; set; }
        public int Soluong { get; set; }
        public double Dongia { get; set; }
        public string Mausac { get; set; }
        public int MaGH { get; set; }
        public string TenSP { get; set; }
        public int MaSP { get; set; }
        public string Kichthuoc { get; set; }
        public string Hinh1 { get; set; }
        public int Soluongton { get; set; }
    }


    public class ChiTietGioHang
    {
        public int MaCTGH { get; set; }
        public decimal? ThanhTien { get; set; }
        public int SoLuong { get; set; }
        public decimal Dongia { get; set; }
        public string? MauSac { get; set; }
        public int MaGH { get; set; }
        public int MaSP { get; set; }

        public string KichThuoc { get; set; }

    }
}
