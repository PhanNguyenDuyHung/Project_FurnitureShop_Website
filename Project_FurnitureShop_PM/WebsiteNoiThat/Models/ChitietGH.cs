namespace WebsiteNoiThat.Models
{
    public class ChitietGH
    {
        public int MACTGH { get; set; }
        public int Soluong { get; set; }
        public double Dongia { get; set; }
        public string Mausac { get; set; }
        public int MaGH { get; set; }
        public int MaSP { get; set; }
        public string TenSP { get; set; }

        public string Hinh1 { get; set; }
        public string Kichthuoc { get; set; }
        public double Thanhtien { get { return Dongia * Soluong; } }
        public int Soluongton { get; set; }
    }
}
