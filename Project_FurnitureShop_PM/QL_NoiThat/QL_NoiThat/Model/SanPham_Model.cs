using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_NoiThat.Model
{
    public class SanPham_Model
    {
        public int MaSP { get; set; }

        public string TenSanPham { get; set; }

        public decimal GiaBan { get; set; }

        public string MauSac { get; set; }

        public string MoTa { get; set; }

        public int SoLuongTon { get; set; }

        public string Hinh1 { get; set; }
        
        public string KichThuoc { get; set; }

        public int MaLoai { get; set; }

        public int MaXuatXu { get; set; }


        public int MaChatLieu { get; set; }
    }

	public class SanPham
	{
		public int MaSP { get; set; }

		public string TenSanPham { get; set; }

	}
    public class Loai_Model
    {
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
    }
    public class ChatLieu_Model
    {
        public int MaChatLieu { get; set; }
        public string TenChatLieu { get; set; }
    }
    public class XuatXu_Model
    {
        public int MaXuatXu { get; set; }
        public string TenXuatXu { get; set; }
    }

    public class update_sl
    {
        public int id { get; set; }

        public int sl { get; set; }
    }

}
