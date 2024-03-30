using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebsiteNoiThat.Models;

namespace WebsiteNoiThat.Controllers
{
    public class HomeController : Controller
    {

        Uri baseAddress = new Uri("https://localhost:7053/api");
        private readonly HttpClient _client;
        public HomeController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ProductByCategory(string categoryId)
        {

            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/SanPham/GetSanPhambyidLoaiHang?idloai={categoryId}");
            List<SanPham> listKH = new List<SanPham>();
            if (response.IsSuccessStatusCode)
            {
                
                string data = await response.Content.ReadAsStringAsync();
                if (data != "[]")
                {
                    listKH = JsonConvert.DeserializeObject<List<SanPham>>(data);
                   

                }
                else
                {
                    ViewBag.ThongBao = "Sản phẩm đang nhập hàng";
                    return View();
                }

            }
            return View(listKH);
        }


    }
}