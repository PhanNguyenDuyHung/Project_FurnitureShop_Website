﻿namespace WebsiteNoiThat.Models
{
    public class DonHang
    {
        public int MaDH { get; set; }
        public DateTime NgayTao { get; set; }
        public string TinhTrang { get; set; }
        public int MaKH { get; set; }
    }

    public class DonHangg
    {
        public int MaDH { get; set; }
        public string NgayTao { get; set; }
        public string TinhTrang { get; set; }
        public string TenSanPham { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public int ThanhTien { get; set; }
        public string KichCo { get; set; }
        public string MauSac { get; set; }
    }
}
