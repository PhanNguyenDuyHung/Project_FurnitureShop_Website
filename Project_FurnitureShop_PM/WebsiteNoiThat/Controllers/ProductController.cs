using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebsiteNoiThat.Models;

namespace WebsiteNoiThat.Controllers
{
	public class ProductController : Controller
	{

		Uri baseAddress = new Uri("https://localhost:7053/api");
		private readonly HttpClient _client;
		public ProductController()
		{
			_client = new HttpClient();
			_client.BaseAddress = baseAddress;

		}



		public async Task<IActionResult> Index(string idLoaiHang)
		{
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/LoaiHang/GetLoaiHangbyID?id={idLoaiHang}");
            List<LoaiHang> listSP = new List<LoaiHang>();
            if (response.IsSuccessStatusCode)
            {

                string data = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(data) || data!="[0]")
                {
                    listSP = JsonConvert.DeserializeObject<List<LoaiHang>>(data);


                }
                

            }
            return View(listSP);
        }


        public async Task<IActionResult> Details(int masp)
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/SanPham/GetSanPhamByIdSanPham?id={masp}");
            List<SanPham> listSP = new List<SanPham>();
            if (response.IsSuccessStatusCode)
            {

                string data = await response.Content.ReadAsStringAsync();
                listSP = JsonConvert.DeserializeObject<List<SanPham>>(data);
            }
            return View(listSP);
        }

        [HttpPost]
        public async Task<IActionResult> addToCart(int maKH, int maSP, decimal donGia, string mauSac, string size, string url)
        {
            int aaa = maSP;
            // Step 1: Lấy thông tin sản phẩm từ API
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/SanPham/GetSanPhamByIdSanPham?id={maSP}");
            if (!response.IsSuccessStatusCode)
            {
                // Xử lý lỗi khi không lấy được thông tin sản phẩm
                // Ví dụ: Redirect hoặc trả về view thông báo lỗi
                return RedirectToPage("Error");
            }
            else
            {
                List<SanPham> sanPham = null;
                string data = await response.Content.ReadAsStringAsync();
                sanPham = JsonConvert.DeserializeObject<List<SanPham>>(data);
            }
            HttpResponseMessage responseMaGH = await _client.GetAsync(_client.BaseAddress + $"/GioHang/GetGioHangByMaKH?makh={maKH}");
            if (!response.IsSuccessStatusCode)
            {
                // Xử lý lỗi khi không lấy được thông tin sản phẩm
                // Ví dụ: Redirect hoặc trả về view thông báo lỗi
                return RedirectToPage("Error");
            }
            List<GioHang> gioHang = null;
            string dataGH = await responseMaGH.Content.ReadAsStringAsync();
            gioHang = JsonConvert.DeserializeObject<List<GioHang>>(dataGH);
            GioHang gh = new GioHang();
            gh = gioHang[0];
            // Step 2: Tạo đối tượng ChiTietGioHang

            ChiTietGioHang chiTietGioHang = new ChiTietGioHang
            {
                MaGH = gh.MaGH,
                Dongia = donGia,
                MaSP = maSP,
                MauSac = mauSac,
                SoLuong = 1,
                ThanhTien = donGia * 1,
                KichThuoc = size
            };
            // Step 3: Thêm vào giỏ hàng (lưu vào cơ sở dữ liệu, session, hoặc giỏ hàng của khách hàng)
            // Ví dụ: Lưu vào cơ sở dữ liệu
            ChiTietGioHang ctgh = new ChiTietGioHang();
            ctgh = chiTietGioHang;
            var content = new StringContent(JsonConvert.SerializeObject(ctgh), Encoding.UTF8, "application/json");
            HttpResponseMessage postresponse = await _client.PostAsync(_client.BaseAddress + "/GioHang/CreateCTGH1", content);
            if (postresponse.IsSuccessStatusCode)
            {
                // Yêu cầu thành công, xử lý kết quả nếu cần
                string responseBody = await postresponse.Content.ReadAsStringAsync();
                // Xử lý nội dung phản hồi
            }
            else
            {
                // Xử lý lỗi nếu yêu cầu không thành công
                // Ví dụ: Log lỗi, xem postResponse.ReasonPhrase để biết lý do lỗi
            }
            TempData["SuccessMessage"] = "Sản phẩm đã được thêm thành công.";
            return RedirectToAction("Details", "Product", new { masp = aaa });
        }






    }
}
