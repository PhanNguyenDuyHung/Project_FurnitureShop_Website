using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebsiteNoiThat.Models;

namespace WebsiteNoiThat.ViewComponents
{
	public class AccountDetailViewComponent : ViewComponent
	{
		Uri baseAddress = new Uri("https://localhost:7053/api");
		private readonly HttpClient _client;
		public AccountDetailViewComponent()
		{
			_client = new HttpClient();
			_client.BaseAddress = baseAddress;

		}

		[HttpGet]
		public async Task<IViewComponentResult> InvokeAsync(int makh)
		{
			HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/KhachHang/GetKhachHangById?id={makh}");
			KhachHang khachHang = new KhachHang();
			if (response.IsSuccessStatusCode)
			{
				string data = await response.Content.ReadAsStringAsync();
				khachHang = JsonConvert.DeserializeObject<KhachHang>(data);

			}
			return View(khachHang);
		}
	}
}
