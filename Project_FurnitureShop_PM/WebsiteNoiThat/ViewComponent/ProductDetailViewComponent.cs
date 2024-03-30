using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using Newtonsoft.Json;
using WebsiteNoiThat.Models;
using WebsiteNoiThat.Controllers;
using System.Text;

namespace WebsiteNoiThat.ViewComponents
{
    public class ProductDetailViewComponent : ViewComponent
    {
        Uri baseAddress = new Uri("https://localhost:7053/api");
        private readonly HttpClient _client;
        public ProductDetailViewComponent()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync(int masp)
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/SanPham/GetSanPhamByIdSanPham?id={masp}");
            List<SanPham> sanPham = new List<SanPham>();
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                sanPham = JsonConvert.DeserializeObject<List<SanPham>>(data);

            }
            return View(sanPham);
        }

        private ActionResult RedirectToActionResult(string v)
        {
            throw new NotImplementedException();
        }
    }
}
