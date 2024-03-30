using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mime;
using WebsiteNoiThat.Models;

namespace WebsiteNoiThat.Controllers
{
    public class GiohangController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7053/api");
        private readonly HttpClient _client;
        public GiohangController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

        }




        [HttpPost]
        public async Task<IActionResult> checkout([FromBody] object data)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync(_client.BaseAddress + $"/giohang/checkout", data);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index(string idKH)
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/giohang/index?idKH={idKH}");
            List<ChitietGH> listSP = new List<ChitietGH>();
            if (response.IsSuccessStatusCode)
            {

                string data = await response.Content.ReadAsStringAsync();
                
                if (!string.IsNullOrEmpty(data) || data != "[0]")
                {
                    listSP = JsonConvert.DeserializeObject<List<ChitietGH>>(data);


                }


            }
			return View(listSP);
        }
        
        public async Task<IActionResult> delete(int mactgh, int idkh)
        {
            await _client.DeleteAsync(_client.BaseAddress + $"/giohang/delete?mactgh={mactgh}&idkh={idkh}");
            return Redirect($"/giohang?idKH={idkh}");
        }

        

    



    }
}
