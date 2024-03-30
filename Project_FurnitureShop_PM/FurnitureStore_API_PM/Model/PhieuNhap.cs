namespace FurnitureStore_API_PM.Model
{
    public class PhieuNhap
    {
        public int MaNhapHang { get; set; }
        public string NgayNhap { get; set; }
        public int MaNCC { get; set; }
        public Decimal TongTien { get; set; }
    }
    public class PhieuNhap_date
    {

        public DateTime NgayNhap { get; set; }
        public int MaNCC { get; set; }
    }

    public class SanPham_banchay
    {
        public int MaSP { get; set; }
        public int SoLuongTon { get; set; }
    }


    public class SanPham_Sl
    {
        public string TenSanPham { get; set; }
        public int SoLuongTon { get; set; }
    }

    public class PhieuNhapHT
    {
        public int MaNhapHang { get; set; }
        public string NgayNhap { get; set; }
        public string TenNCC { get; set; }
        public string SDT { get; set; }
        public Decimal TongTien { get; set; }
    }


    public class NhaCungCap
    {
        public int MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string SDTNCC { get; set; }
        public string DiaChiNCC { get; set; }
    }

    public class NhaCC
    {
        public int MaNCC { get; set; }
        public string TenNCC { get; set; }
    }

    public class SanPhamm
    {
        public int MaSP { get; set; }
        public string TenSanPham { get; set; }
        public int SoLuongTon { get; set; }
    }

    public class ChiTietPN
    {
        public int MaThongKeNhap { get; set; }
        public int MaSP { get; set; }
        public string TenSanPham { get; set; }
        public int SoLuong { get; set; }
        public int DonGiaNhap { get; set; }

        public int MaNhapHang { get; set; }
    }


    public class CreateChiTietPN
    {
        public int MaSP { get; set; }
        public int SoLuong { get; set; }
        public int DonGiaNhap { get; set; }
        public int MaNhapHang { get; set; }
    }

    public class UpdateChiTietPN
    {
        public int MaThongKeNhap { get; set; }
        public int MaSP { get; set; }
        public int SoLuong { get; set; }
        public int DonGiaNhap { get; set; }
    }
    public class doanhso
    {
        public int Thang { get; set; }
        public int DonGia { get; set; }
    }
    public class doanhsoquy
    {
        public string Quy { get; set; }
        public int DonGia { get; set; }
    }

    public class user
    {
        public string name { get; set; }

        public string pass { get; set; }

    }


}
