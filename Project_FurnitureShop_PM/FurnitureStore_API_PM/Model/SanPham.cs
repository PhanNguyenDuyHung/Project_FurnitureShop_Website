﻿namespace FurnitureStore_API_PM.Model
{
    public class SanPham
    {

        public int MaSP { get; set; }

        public string TenSanPham { get; set; }

        public decimal GiaBan { get; set; }

        public string? MauSac { get; set; }

        public string MoTa { get; set; }

        public int SoLuongTon { get; set; }

        public string? Hinh1 { get; set; }
        public string? Hinh2 { get; set; }
        public string? Hinh3 { get; set; }
        public string? KichThuoc { get; set; }

        public int MaLoai { get; set; }

        public int MaXuatXu { get; set; }


        public int MaChatLieu { get; set; }

    }

    public class SanPham_model
    {
        public int MaSP { get; set; }

        public string TenSanPham { get; set; }

    }

    public class update_sl
    {
        public int id { get; set; }

        public int sl { get; set; }
    }
}
